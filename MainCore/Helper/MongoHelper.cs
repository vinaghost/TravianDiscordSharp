using MainCore.Models;
using MongoDB.Driver;

namespace MainCore.Helper
{
    public static class MongoHelper
    {
        private const string databaseWorldName = "TravianWorldDatabase";
        private const string collectionWorld = "TravianOfficial";

        //private const string databaseVillageName = "TravianOfficialWorld";

        private static MongoClient _mongoClient;

        public static MongoClient GetClient()
        {
            if (_mongoClient is null)
            {
                var connectionString = EnvVarHelper.MogoDbConnection;
                _mongoClient = new MongoClient(connectionString);
            }
            return _mongoClient;
        }

        public static async Task<List<World>> GetWorldCollection()
        {
            var client = GetClient();
            var collection = client.GetDatabase(databaseWorldName).GetCollection<World>(collectionWorld);
            var filter = Builders<World>.Filter.Empty;

            return await collection.Find(filter).ToListAsync();
        }
    }
}