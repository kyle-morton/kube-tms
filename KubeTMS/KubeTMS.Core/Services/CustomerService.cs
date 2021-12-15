using System.Text.Json;
using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.Extensions.Configuration;

namespace KubeTMS.Core.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAsync();
    }

    public class CustomerService : ServiceBase, ICustomerService
    {
        private readonly IConfiguration _config;

        public CustomerService(KubeTMSDbContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task<List<Customer>> GetAsync()
        {
            var url = _config["ApiUrls:Customers"] + "customers";
            Console.WriteLine("--> Getting Customers: " + url);

            var customers = new List<Customer>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    customers = JsonSerializer.Deserialize<List<Customer>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return customers;
        }
    }
}