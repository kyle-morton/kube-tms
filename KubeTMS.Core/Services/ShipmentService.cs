using KubeTMS.Core.Data;
using KubeTMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace KubeTMS.Core.Services
{

    public interface IShipmentService
    {
        Task<List<Shipment>> GetAsync(); 
    }

    public class ShipmentService : ServiceBase, IShipmentService
    {
        public ShipmentService(KubeTMSDbContext context) : base(context)
        {
        }

        public async Task<List<Shipment>> GetAsync()
        {
            return await _context.Shipments
                .Include(s => s.Carrier)
                .ToListAsync();
        }
    }

}
