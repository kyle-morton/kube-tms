using KubeCustomer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KubeCustomer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        private readonly ICustomerService _service;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService service)
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
