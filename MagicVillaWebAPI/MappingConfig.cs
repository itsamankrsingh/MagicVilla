using AutoMapper;
using MagicVillaWebAPI.Models;
using MagicVillaWebAPI.Models.Dto;

namespace MagicVillaWebAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>();
            CreateMap<VillaDto, Villa>();
            CreateMap<Villa, VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

        }
    }
}
