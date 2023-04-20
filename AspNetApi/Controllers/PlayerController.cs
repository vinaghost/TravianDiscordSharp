using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IMongoDbService _mongoDbService;

        public PlayerController(ILogger<PlayerController> logger, IMongoDbService mongoDbService)
        {
            _logger = logger;
            _mongoDbService = mongoDbService;
        }

        [HttpGet("{world}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<TravianObject>), 200)]
        public IActionResult Get(string world)
        {
            var collection = _mongoDbService.GetVillages(world);
            var travianObjects = collection.AsQueryable().Select(x => new TravianObject(x.PlayerId, x.PlayerName)).ToArray();
            var result = travianObjects.DistinctBy(x => x.Id).OrderBy(x => x.Name).ToArray();
            return Ok(result);
        }

        [HttpGet("{world}/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Village>), 200)]
        public IActionResult Get(string world, int id)
        {
            var collection = _mongoDbService.GetVillages(world);
            var filter = Builders<Village>.Filter.Where(x => x.PlayerId == id);
            return Ok(collection.Find(filter).ToEnumerable());
        }
    }
}