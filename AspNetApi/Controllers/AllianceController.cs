using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllianceController : ControllerBase
    {
        private readonly ILogger<AllianceController> _logger;
        private readonly IMongoDbService _mongoDbService;

        public AllianceController(ILogger<AllianceController> logger, IMongoDbService mongoDbService)
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
            var travianObjects = collection.AsQueryable().Select(x => new TravianObject(x.AllyId, x.AllyName)).ToArray();
            var result = travianObjects.DistinctBy(x => x.Id).OrderBy(x => x.Name).ToArray();
            return Ok(result);
        }
    }
}