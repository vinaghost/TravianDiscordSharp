using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Concurrent;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VillageController : ControllerBase
    {
        private readonly ILogger<VillageController> _logger;
        private readonly IMongoDbService _mongoDbService;

        public VillageController(ILogger<VillageController> logger, IMongoDbService mongoDbService)
        {
            _logger = logger;
            _mongoDbService = mongoDbService;
        }

        [HttpGet("{world}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Village>), 200)]
        public IActionResult Get(string world)
        {
            var collection = _mongoDbService.GetVillages(world);
            var filter = Builders<Village>.Filter.Empty;
            return Ok(collection.Find(filter).ToEnumerable());
        }

        [HttpGet("{world}/distance")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<VillageDistance>), 200)]
        public IActionResult Get(string world, int x, int y)
        {
            var collection = _mongoDbService.GetVillages(world);
            var filter = Builders<Village>.Filter.Empty;
            var villages = collection.Find(filter).ToList();

            var coord = new Coordinates(x, y);
            var result = new VillageDistance[villages.Count];

            var partitioner = Partitioner.Create(0, villages.Count);
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

            return Ok(list);
        }
    }
}