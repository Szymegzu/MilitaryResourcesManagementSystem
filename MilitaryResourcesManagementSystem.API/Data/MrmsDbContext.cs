using Microsoft.EntityFrameworkCore;
using MilitaryResourcesManagementSystem.API.Models.Domain;

namespace MilitaryResourcesManagementSystem.API.Data
{
    public class MrmsDbContext : DbContext
    {
        public MrmsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Soldiers)
                .WithOne(s => s.Unit)
                .HasForeignKey(s => s.UnitId);
        }
    }
}
