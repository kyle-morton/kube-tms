using KubeTMS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KubeTMS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service, ILogger<CustomersController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _service.GetAsync();
            return Ok(customers);
        }
    }
}
