using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace KubeTMS.Core.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAsync();
        Task<Customer> GetDetailsAsync(int id);
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
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetDetailsAsync(int id)
        {
            var url = _config["ApiUrls:Customers"] + "customers/" + id;
            Console.WriteLine("--> Getting Customer: " + url);

            Customer customer = null;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    customer = JsonSerializer.Deserialize<Customer>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return customer;
        }
    }
}