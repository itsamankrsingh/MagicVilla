using System.ComponentModel.DataAnnotations;

namespace MagicVillaWebAPI.Models.Dto
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        [Required]
        public int VillaID { get; set; }

    }
}
