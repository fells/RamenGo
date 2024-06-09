using AutoMapper;
using ramengo.Dto;
using ramengo.Models;

namespace ramengo.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Broth, BrothDto>().ReverseMap();
            CreateMap<Protein, ProteinDto>().ReverseMap();
            CreateMap<Order, OrderRequestDto>().ReverseMap();
            CreateMap<Order, OrderResponseDto>().ReverseMap();
        }
    }
}
