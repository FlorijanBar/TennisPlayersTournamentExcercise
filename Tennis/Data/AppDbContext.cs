using Microsoft.EntityFrameworkCore;
using Tennis.Models;

namespace Tennis.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Tournament> Tournaments { get; set;}
        public DbSet<PlayerTournament> PlayerTournaments { get; set; }

    }
}
