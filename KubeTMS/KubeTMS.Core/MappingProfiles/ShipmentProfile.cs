using AutoMapper;
using KubeTMS.Shared.Domain;
using KubeTMS.Shared.Dtos;

namespace KubeTMS.Core.MappingProfiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            // Source -> Target
            CreateMap<Shipment, ShipmentReadDto>();
        }
    }
}
