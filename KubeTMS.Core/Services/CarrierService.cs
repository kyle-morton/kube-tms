using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeTMS.Core.Services
{
    public interface ICarrierService
    {
        Task<List<Carrier>> GetAsync();
    }

    public class CarrierService : ServiceBase, ICarrierService
    {
        public CarrierService(KubeTMSDbContext context) : base(context)
        {
        }

        public async Task<List<Carrier>> GetAsync()
        {
            return await _context.Carriers.ToListAsync();
        }
    }
}
