using KubeTMS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KubeTMS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentsController : ControllerBase
    {

        private readonly ILogger<ShipmentsController> _logger;
        private readonly IShipmentService _service;

        public ShipmentsController(IShipmentService service, ILogger<ShipmentsController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shipments = await _service.GetAsync();
            return Ok(shipments);
        }
    }
}
