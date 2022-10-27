using System.ComponentModel.DataAnnotations;

namespace MagicVillaWebAPI.Models.Dto
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
