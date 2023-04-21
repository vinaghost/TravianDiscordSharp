using AspNetApi.Services.Interface;
using MainCore.Models;
using MongoDB.Driver;

namespace AspNetApi.Services.Implementations
{
    public class AllianceService : IAllianceService
    {
        private readonly IMongoDbService _mongoDbService;

        public AllianceService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public IEnumerable<TravianObject> GetAlliances(string world)
        {
            var collection = _mongoDbService.GetVillages(world);
            var travianObjects = collection.AsQueryable().Select(x => new TravianObject(x.AllyId, x.AllyName)).ToArray();
            var result = travianObjects.DistinctBy(x => x.Id).OrderBy(x => x.Name);
            return result;
        }
    }
}