using System.ComponentModel.DataAnnotations;

namespace MagicVillaWeb.Models.Dto
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        [Required]
        public int VillaID { get; set; }
        public VillaDto Villa { get; set; }
    }
}
