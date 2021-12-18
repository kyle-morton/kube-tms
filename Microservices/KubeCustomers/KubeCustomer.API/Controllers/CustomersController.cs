using KubeCustomer.Core.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KubeCustomer.Core.Dtos;
using KubeCustomer.Core.Domain;

namespace KubeCustomer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _service.GetAsync();
            return Ok(_mapper.Map<List<CustomerReadDto>>(customers));
        }
                
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<ActionResult<CustomerReadDto>> GetCommandForPlatform(int customerId) 
        {
            var customer = await _service.GetAsync(customerId);
            if (customer == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateDto dto) 
        {
            var customer = _mapper.Map<Customer>(dto);
            customer = await _service.CreateAsync(customer);

            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }
    }
}
