using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IWorldService _worldService;
        private readonly IPlayerService _playerService;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService, IWorldService worldService)
        {
            _logger = logger;
            _playerService = playerService;
            _worldService = worldService;
        }

        [HttpGet("{world}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<TravianObject>), 200)]
        public IActionResult Get(string world)
        {
            if (!_worldService.IsVaild(world)) return Ok(new List<TravianObject>());
            return Ok(_playerService.GetPlayers(world));
        }

        [HttpGet("{world}/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Village>), 200)]
        public IActionResult Get(string world, int id)
        {
            if (!_worldService.IsVaild(world)) return Ok(new List<Village>());
            return Ok(_playerService.GetVillages(world, id));
        }
    }
}