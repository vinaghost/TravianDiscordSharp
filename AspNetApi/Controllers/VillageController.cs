using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VillageController : ControllerBase
    {
        private readonly ILogger<VillageController> _logger;
        private readonly IWorldService _worldService;
        private readonly IVillageService _villageService;

        public VillageController(ILogger<VillageController> logger, IWorldService worldService, IVillageService villageService)
        {
            _logger = logger;
            _worldService = worldService;
            _villageService = villageService;
        }

        [HttpGet("{world}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Village>), 200)]
        public IActionResult Get(string world)
        {
            if (!_worldService.IsVaild(world)) return Ok(new List<Village>());
            return Ok(_villageService.GetVillages(world));
        }

        [HttpGet("{world}/distance")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<VillageDistance>), 200)]
        public IActionResult Get(string world, int x, int y)
        {
            if (!_worldService.IsVaild(world)) return Ok(new List<VillageDistance>());
            return Ok(_villageService.GetVillages(world, new Coordinates(x, y)));
        }
    }
}