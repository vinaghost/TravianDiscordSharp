using AspNetApi.Services.Interface;
using MainCore.Models;
using MongoDB.Driver;

namespace AspNetApi.Services.Implementations
{
    public class PlayerService : IPlayerService
    {
        private readonly IMongoDbService _mongoDbService;

        public PlayerService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public IEnumerable<TravianObject> Get(string world)
        {
            var collection = _mongoDbService.GetVillages(world);
            var travianObjects = collection.AsQueryable().Select(x => new TravianObject(x.PlayerId, x.PlayerName)).ToArray();
            var result = travianObjects.DistinctBy(x => x.Id).OrderBy(x => x.Name);
            return result;
        }

        public IEnumerable<Village> GetVillages(string world, int id)
        {
            var collection = _mongoDbService.GetVillages(world);
            var filter = Builders<Village>.Filter.Where(x => x.PlayerId == id);
            return collection.Find(filter).SortBy(x => x.Pop).ToEnumerable();
        }
    }
}