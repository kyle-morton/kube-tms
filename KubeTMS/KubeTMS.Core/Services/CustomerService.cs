using KubeTMS.Core.Clients;
using KubeTMS.Shared.Dtos;

namespace KubeTMS.Core.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerReadDto>> GetAsync();
        Task<CustomerReadDto> GetDetailsAsync(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomersClient _client;

        public CustomerService(ICustomersClient client)
        {
            _client = client;
        }

        public async Task<List<CustomerReadDto>> GetAsync()
        {
            return await _client.GetAsync();
        }

        public async Task<CustomerReadDto> GetDetailsAsync(int id)
        {
            return await _client.GetAsync(id);
        }
    }
}