using MagicVillaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Villa> VillasTable { get; set; }
    }
}
