using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorldController : ControllerBase
    {
        private readonly IWorldService _worldService;
        private readonly ILogger<WorldController> _logger;

        public WorldController(ILogger<WorldController> logger, IWorldService worldService)
        {
            _logger = logger;
            _worldService = worldService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<World>), 200)]
        public IActionResult Get()
        {
            return Ok(_worldService.GetWorlds());
        }
    }
}