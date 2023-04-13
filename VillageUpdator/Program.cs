using MainCore.Helper;
using MainCore.Models;
using MainCore.Parsers;
using MongoDB.Driver;

namespace VillageUpdator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var databaseWorlds = await GetWorldsFromDatabase();
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 3 };
            await Parallel.ForEachAsync(databaseWorlds, parallelOptions, async (world, token) =>
            {
                var villageLines = await GetMapSql(world.Url);
                if (villageLines is null) return;
                var database = await CreateWorld(world.Url);

                var villages = MapSqlParser.GetVillages(villageLines);
                await AddVillage(database, world.Url, villages);
                Console.WriteLine($"[Thread: {Environment.CurrentManagedThreadId}] World {world.Url} has {villages.Count} villages");
            });

            Console.WriteLine($"Total {databaseWorlds.Count} world updated");
            HttpClientHelper.Dispose();
        }

        private static async Task<List<World>> GetWorldsFromDatabase()
        {
            var client = MongoHelper.GetClient();
            var collection = client.GetDatabase("TravianWorldDatabase").GetCollection<World>("TravianOfficial");
            return await collection.AsQueryable().ToListAsync();
        }

        private static async Task<string> GetMapSql(string worldUrl)
        {
            try
            {
                var result = await HttpClientHelper.GetClient().GetStringAsync($"https://{worldUrl}/map.sql");
                return result;
            }
            catch
            {
                return null;
            }
        }

        private static async Task<IMongoDatabase> CreateWorld(string world)
        {
            var client = MongoHelper.GetClient();
            var database = client.GetDatabase("TravianOfficialWorld");
            await database.DropCollectionAsync(world);
            await database.CreateCollectionAsync(world);
            return database;
        }

        private static async Task AddVillage(IMongoDatabase database, string world, List<Village> villages)
        {
            var collection = database.GetCollection<Village>(world);
            await collection.InsertManyAsync(villages);
        }
    }
}