using KubeTMS.Core.Clients;
using KubeTMS.Shared.Dtos;

namespace KubeTMS.Core.Services
{
    public interface ICarrierService
    {
        Task<List<CarrierReadDto>> GetAsync();
    }

    public class CarrierService : ICarrierService
    {
        private readonly ICarriersClient _client;

        public CarrierService(ICarriersClient client)
        {
            _client = client;
        }

        public async Task<List<CarrierReadDto>> GetAsync()
        {
            return await _client.GetAsync();
        }


    }
}
