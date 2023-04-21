using AspNetApi.Services.Interface;
using MainCore.Models;
using MongoDB.Driver;

namespace AspNetApi.Services.Implementations
{
    public class WorldService : IWorldService
    {
        private readonly IMongoDbService _mongoDbService;

        public WorldService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public IEnumerable<World> GetWorlds()
        {
            var collection = _mongoDbService.GetWorlds();
            var filter = Builders<World>.Filter.Empty;
            return collection.Find(filter).ToEnumerable();
        }

        public bool IsVaild(string world)
        {
            var worlds = GetWorlds();
            return worlds.Any(x => x.Url.Equals(world));
        }
    }
}