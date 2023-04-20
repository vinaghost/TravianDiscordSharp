using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorldController : ControllerBase
    {
        private readonly ILogger<WorldController> _logger;
        private readonly IMongoDbService _mongoDbService;

        public WorldController(ILogger<WorldController> logger, IMongoDbService mongoDbService)
        {
            _logger = logger;
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public IEnumerable<World> Get()
        {
            var collection = _mongoDbService.GetWorlds();
            var filter = Builders<World>.Filter.Empty;
            return collection.Find(filter).ToEnumerable();
        }
    }
}