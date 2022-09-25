using MagicVillaWebAPI.Models.Dto;

namespace MagicVillaWebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>
            {
                new VillaDto {Id=1, Name="Pool View",Occupancy=4,Sqft=4 },
                new VillaDto { Id = 2, Name = "Beach View",Occupancy=3,Sqft=3 }
            };
    }
}
