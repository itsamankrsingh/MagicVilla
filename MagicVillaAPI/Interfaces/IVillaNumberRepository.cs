using MagicVillaWebAPI.Models;

namespace MagicVillaWebAPI.Interfaces
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}