using MagicVillaWebAPI.Data;
using MagicVillaWebAPI.Interfaces;
using MagicVillaWebAPI.Models;

namespace MagicVillaWebAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbersTable.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
