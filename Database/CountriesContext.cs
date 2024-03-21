using Microsoft.EntityFrameworkCore;
using FlagLearner.Database.Entities;
using Color = FlagLearner.Database.Entities.Color;

namespace FlagLearner.Database;

public partial class CountriesContext : DbContext
{
    public CountriesContext()
    {
    }

    public CountriesContext(DbContextOptions<CountriesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; } = null!;
    public virtual DbSet<Country> Countries { get; set; } = null!;
    public virtual DbSet<CountryInfo> CountryInfos { get; set; } = null!;
    public virtual DbSet<Line> Lines { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\\\\\\\Froggling\\Projects\\FlagLearner\\FlagLearner\\Database\\Countries.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.ToTable("color");

            entity.HasIndex(e => e.CountryId, "color_country_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.ColorName)
                .HasColumnType("VARCHAR(16)")
                .HasColumnName("color_name");

            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.HasOne(d => d.Country)
                .WithMany(p => p.Colors)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.HasIndex(e => e.CountryInfoId, "country_country_info_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.CountryInfoId).HasColumnName("country_info_id");

            entity.Property(e => e.CountryName)
                .HasColumnType("VARCHAR(64)")
                .HasColumnName("country_name");

            entity.Property(e => e.ImageUrl)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("image_url");

            entity.HasOne(d => d.CountryInfo)
                .WithMany(p => p.Countries)
                .HasForeignKey(d => d.CountryInfoId);
        });

        modelBuilder.Entity<CountryInfo>(entity =>
        {
            entity.ToTable("countryinfo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.Area).HasColumnName("area");

            entity.Property(e => e.Capital)
                .HasColumnType("VARCHAR(32)")
                .HasColumnName("capital");

            entity.Property(e => e.Codes)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("codes");

            entity.Property(e => e.Continent)
                .HasColumnType("VARCHAR(32)")
                .HasColumnName("continent");

            entity.Property(e => e.Currency)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("currency");

            entity.Property(e => e.Domain)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("domain");

            entity.Property(e => e.Gdp)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("gdp");

            entity.Property(e => e.HighestPoint)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("highest_point");

            entity.Property(e => e.LowestPoint)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("lowest_point");

            entity.Property(e => e.Member)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("member");

            entity.Property(e => e.PhoneCode)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("phone_code");

            entity.Property(e => e.Population).HasColumnName("population");

            entity.Property(e => e.Sovereign)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("sovereign");
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.ToTable("line");

            entity.HasIndex(e => e.CountryId, "line_country_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(16)")
                .HasColumnName("line");

            entity.HasOne(d => d.Country)
                .WithMany(p => p.Lines)
                .HasForeignKey(d => d.CountryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
