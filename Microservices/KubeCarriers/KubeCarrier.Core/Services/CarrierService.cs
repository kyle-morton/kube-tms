using KubeCarrier.Core.Data;
using KubeCarrier.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeCarrier.Core.Services
{
    public interface ICarrierService
    {
        Task<List<Carrier>> GetAsync();
    }

    public class CarrierService : ServiceBase, ICarrierService
    {
        public CarrierService(KubeCarrierDbContext context) : base(context)
        {
        }

        public async Task<List<Carrier>> GetAsync()
        {
            return await _context.Carriers.ToListAsync();
        }
    }
}
