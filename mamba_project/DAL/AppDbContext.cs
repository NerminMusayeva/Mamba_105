using mamba_project.Models;
using Microsoft.EntityFrameworkCore;

namespace mamba_project.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<OurTeam> OurTeams { get; set; }
    }
}
