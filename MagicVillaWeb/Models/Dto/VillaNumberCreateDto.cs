using System.ComponentModel.DataAnnotations;

namespace MagicVillaWeb.Models.Dto
{
    public class VillaNumberCreateDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        [Required]
        public int VillaID { get; set; }
    }
}

