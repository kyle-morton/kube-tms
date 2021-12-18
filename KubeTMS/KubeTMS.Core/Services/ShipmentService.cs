using AutoMapper;
using KubeTMS.Core.Data;
using KubeTMS.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KubeTMS.Core.Services
{

    public interface IShipmentService
    {
        Task<List<ShipmentReadDto>> GetAsync(); 
    }

    public class ShipmentService : ServiceBase, IShipmentService
    {
        public ShipmentService(KubeTMSDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<ShipmentReadDto>> GetAsync()
        {
            var shipments = await _context.Shipments
                .ToListAsync();

            var shipmentDtos = _mapper.Map<List<ShipmentReadDto>>(shipments);

            return shipmentDtos;
        }
    }

}
