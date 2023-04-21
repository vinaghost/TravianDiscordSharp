using AspNetApi.Services.Interface;
using MainCore.Helper;
using MainCore.Models;
using MongoDB.Driver;

namespace AspNetApi.Services.Implementations
{
    public class MongoDbService : IMongoDbService
    {
        private readonly MongoClient _mongoClient;

        private const string databaseWorldName = "TravianWorldDatabase";
        private const string databaseVillageName = "TravianOfficialWorld";
        private const string collectionWorld = "TravianOfficial";

        public MongoDbService()
        {
            var connectionString = EnvVarHelper.MogoDbConnection;
            _mongoClient = new MongoClient(connectionString);
        }

        public IMongoCollection<Village> GetVillages(string world)
        {
            var collection = _mongoClient.GetDatabase(databaseVillageName).GetCollection<Village>(world);
            return collection;
        }

        public IMongoCollection<World> GetWorlds()
        {
            var collection = _mongoClient.GetDatabase(databaseWorldName).GetCollection<World>(collectionWorld);
            return collection;
        }
    }
}