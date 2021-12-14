using KubeTMS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KubeTMS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarriersController : ControllerBase
    {

        private readonly ILogger<CarriersController> _logger;
        private readonly ICarrierService _service;

        public CarriersController(ICarrierService service, ILogger<CarriersController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carriers = await _service.GetAsync();
            return Ok(carriers);
        }
    }
}
