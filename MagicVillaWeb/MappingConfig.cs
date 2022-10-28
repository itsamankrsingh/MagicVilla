using AutoMapper;
using MagicVillaWeb.Models.Dto;

namespace MagicVillaWeb
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaDto, VillaCreateDto>().ReverseMap();
            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
        }
    }
}