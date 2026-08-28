using AutoMapper;
using Order.Api.Dtos.Order;
using Order.Api.Entities;

namespace Order.Api.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddressRequestDto, Address>();
        }
    }
}
