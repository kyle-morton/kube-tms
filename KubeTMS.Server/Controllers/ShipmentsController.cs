using Microsoft.AspNetCore.Mvc;

namespace KubeTMS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentsController : ControllerBase
    {

        private readonly ILogger<ShipmentsController> _logger;

        public ShipmentsController(ILogger<ShipmentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
