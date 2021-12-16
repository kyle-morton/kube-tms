using AutoMapper;
using KubeCustomer.Core.Domain;
using KubeCustomer.Core.Dtos;

namespace KubeCustomer.Core.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Source -> Target
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            

            // // map id of published platform to externalId
            // CreateMap<PlatformPublishDto, Platform>()
            //     .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));

            // CreateMap<GrpcPlatformModel, Platform>()
            //     .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.PlatformId))
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //     .ForMember(dest => dest.Commands, opt => opt.Ignore());
        }
    }
}