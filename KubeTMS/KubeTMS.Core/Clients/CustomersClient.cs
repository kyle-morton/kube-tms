using KubeTMS.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace KubeTMS.Core.Clients
{
    public interface ICustomersClient
    {
        Task<List<CustomerReadDto>> GetAsync();
        Task<CustomerReadDto> GetAsync(int id);
    }
    public class CustomersClient : ICustomersClient
    {

        private readonly IConfiguration _config;

        public CustomersClient(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<CustomerReadDto>> GetAsync()
        {
            var url = _config["ApiUrls:Customers"] + "customers";
            Console.WriteLine("--> Getting Customers: " + url);

            var customers = new List<CustomerReadDto>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    customers = JsonSerializer.Deserialize<List<CustomerReadDto>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return customers;
        }

        public async Task<CustomerReadDto> GetAsync(int id)
        {
            var url = _config["ApiUrls:Customers"] + "customers/" + id;
            Console.WriteLine("--> Getting Customer: " + url);

            CustomerReadDto customer = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    customer = JsonSerializer.Deserialize<CustomerReadDto>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return customer;
        }
    }
}
