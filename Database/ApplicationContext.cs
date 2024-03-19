using Microsoft.EntityFrameworkCore;
using Database.Entities;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<CountryInfo> CountryInfos { get; set; } = null!;
        public DbSet<Entities.Color> Colors { get; set; } = null!;
        public DbSet<Line> Lines { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(model => model.CountryName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=countries.db");
        }
    }
}
