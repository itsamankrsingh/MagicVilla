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

            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
        }
    }
}