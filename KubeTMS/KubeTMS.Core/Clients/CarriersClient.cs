using KubeTMS.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace KubeTMS.Core.Clients
{
    public interface ICarriersClient
    {
        Task<List<CarrierReadDto>> GetAsync();
        Task<CarrierReadDto> GetAsync(int id);
    }
    public class CarriersClient : ICarriersClient
    {

        private readonly IConfiguration _config;

        public CarriersClient(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<CarrierReadDto>> GetAsync()
        {
            var url = _config["ApiUrls:Carriers"] + "carriers";
            Console.WriteLine("--> Getting Carriers: " + url);

            var carriers = new List<CarrierReadDto>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    carriers = JsonSerializer.Deserialize<List<CarrierReadDto>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return carriers;
        }

        public async Task<CarrierReadDto> GetAsync(int id)
        {
            var url = _config["ApiUrls:Carriers"] + "carriers/" + id;
            Console.WriteLine("--> Getting Carrier: " + url);

            CarrierReadDto carrier = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseBody);
                    carrier = JsonSerializer.Deserialize<CarrierReadDto>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }

            return carrier;
        }
    }
}
