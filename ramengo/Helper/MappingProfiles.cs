using AutoMapper;
using ramengo.Dto;
using ramengo.Models;

namespace ramengo.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Broth, BrothDto>();
            CreateMap<Protein, ProteinDto>();
        }
    }
}
