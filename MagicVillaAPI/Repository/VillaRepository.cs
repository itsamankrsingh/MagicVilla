using MagicVillaWebAPI.Data;
using MagicVillaWebAPI.Interfaces;
using MagicVillaWebAPI.Models;

namespace MagicVillaWebAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillasTable.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
