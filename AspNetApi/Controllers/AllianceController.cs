using AspNetApi.Services.Interface;
using MainCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllianceController : ControllerBase
    {
        private readonly ILogger<AllianceController> _logger;
        private readonly IAllianceService _allianceService;
        private readonly IWorldService _worldService;

        public AllianceController(ILogger<AllianceController> logger, IWorldService worldService, IAllianceService allianceService)
        {
            _logger = logger;
            _worldService = worldService;
            _allianceService = allianceService;
        }

        [HttpGet("{world}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<TravianObject>), 200)]
        public IActionResult Get(string world)
        {
            if (!_worldService.IsVaild(world)) return Ok(new List<TravianObject>());

            return Ok(_allianceService.GetAlliances(world));
        }
    }
}