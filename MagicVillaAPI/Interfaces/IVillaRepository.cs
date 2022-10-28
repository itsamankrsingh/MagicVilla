using MagicVillaWebAPI.Models;

namespace MagicVillaWebAPI.Interfaces
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}