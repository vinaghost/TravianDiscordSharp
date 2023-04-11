using HtmlAgilityPack;
using MainCore.Helper;
using MainCore.Models;
using MainCore.Parsers;
using MongoDB.Driver;

namespace WorldUpdator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var getterToolsWorldsTask = GetWorldsFromGetterTools();
            var databaseWorldsTask = GetWorldsFromDatabase();
            var words = await Task.WhenAll(getterToolsWorldsTask, databaseWorldsTask);
            await UpdateDatabase(words);

            HttpClientHelper.Dispose();
        }

        private static async Task<HtmlDocument> GetGetterToolPage()
        {
            var httpClient = HttpClientHelper.GetClient();

            var response = await httpClient.GetAsync("https://www.gettertools.com/en/");
            var content = await response.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            return doc;
        }

        private static async Task<List<World>> GetWorldsFromGetterTools()
        {
            var doc = await GetGetterToolPage();

            var listWorld = new List<World>();

            var regions = GetterToolsParser.GetWorldRegions(doc);

            foreach (var region in regions)
            {
                var name = GetterToolsParser.GetWorldRegion(region);
                var worlds = GetterToolsParser.GetWorlds(region);
                foreach (var world in worlds)
                {
                    var worldUrl = GetterToolsParser.GetWorldUrl(world);
                    if (worldUrl.Contains("kingdoms")) continue;
                    var worldStartDate = GetterToolsParser.GetWorldStartDate(world);

                    listWorld.Add(new World(worldUrl, worldStartDate));
                }
            }
            return listWorld;
        }

        private static async Task<List<World>> GetWorldsFromDatabase()
        {
            var client = MongoHelper.GetClient();
            var collection = client.GetDatabase("TravianWorldDatabase").GetCollection<World>("TravianOfficial");
            return await collection.AsQueryable().ToListAsync();
        }

        private static async Task UpdateDatabase(List<World>[] worlds)
        {
            var getterToolsWorlds = worlds[0];
            var databaseWorlds = worlds[1];

            var newWorlds = getterToolsWorlds.ExceptBy(databaseWorlds.Select(x => x.Url), x => x.Url).ToList();
            var oldWorlds = databaseWorlds.ExceptBy(getterToolsWorlds.Select(x => x.Url), x => x.Url).ToList();

            var client = MongoHelper.GetClient();
            var collection = client.GetDatabase("TravianWorldDatabase").GetCollection<World>("TravianOfficial");

            await collection.InsertManyAsync(newWorlds);

            var filter = Builders<World>.Filter.In("_id", oldWorlds.Select(x => x.Id));
            await collection.DeleteManyAsync(filter);
        }
    }
}