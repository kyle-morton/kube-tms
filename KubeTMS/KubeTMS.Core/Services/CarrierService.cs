using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace KubeTMS.Core.Services
{
    public interface ICarrierService
    {
        Task<List<Carrier>> GetAsync();
    }

    public class CarrierService : ServiceBase, ICarrierService
    {
        private readonly IConfiguration _config;

        public CarrierService(KubeTMSDbContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task<List<Carrier>> GetAsync()
        {
            var url = _config["ApiUrls:Carriers"] + "carriers";
            Console.WriteLine("--> Getting Carriers: " + url);

            var carriers = new List<Carrier>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    carriers = JsonSerializer.Deserialize<List<Carrier>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return carriers;
        }

        //public async Task<List<Carrier>> GetAsync()
        //{
        //    return await _context.Carriers.ToListAsync();
        //}


    }
}
