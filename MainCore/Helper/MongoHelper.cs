using MainCore.Models;
using MongoDB.Driver;

namespace MainCore.Helper
{
    public static class MongoHelper
    {
        private const string databaseWorldName = "TravianWorldDatabase";
        private const string databaseVillageName = "TravianOfficialWorld";
        private const string collectionWorld = "TravianOfficial";
        private static MongoClient _mongoClient;

        public static MongoClient GetClient()
        {
            if (_mongoClient is null)
            {
                var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
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

        public static async Task<List<Village>> GetVillageCollection(string world)
        {
            var client = GetClient();
            var collection = client.GetDatabase(databaseVillageName).GetCollection<Village>(world);
            var filter = Builders<Village>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }
    }
}