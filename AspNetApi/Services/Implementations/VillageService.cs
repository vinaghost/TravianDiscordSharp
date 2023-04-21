using AspNetApi.Services.Interface;
using MainCore.Models;
using MongoDB.Driver;
using System.Collections.Concurrent;

namespace AspNetApi.Services.Implementations
{
    public class VillageService : IVillageService
    {
        private readonly IMongoDbService _mongoDbService;

        public VillageService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public IEnumerable<Village> GetVillages(string world)
        {
            var collection = _mongoDbService.GetVillages(world);
            var filter = Builders<Village>.Filter.Empty;
            return collection.Find(filter).ToEnumerable();
        }

        public IEnumerable<VillageDistance> GetVillages(string world, Coordinates coord)
        {
            var villages = GetVillages(world).ToArray();

            var result = new VillageDistance[villages.Length];

            var partitioner = Partitioner.Create(0, villages.Length);
            Parallel.ForEach(partitioner, (range, loopState) =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    var village = villages[i];
                    var distance = coord.Distance(new Coordinates(village.X, village.Y));
                    result[i] = new VillageDistance(village, distance);
                }
            });
            var list = result.ToList();
            list.Sort();
            return list;
        }
    }
}