using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(p =>
            {
                p.ToTable("Technologies").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] progLanguageEntitySeeds = { new(1, "C#"), new(2, "C"), new(3, "Java"), new(4, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(progLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1, 1, "ASP.NET"), new(2, 3, "Spring"), new(3, 3, "Maven"), new(4, 4, "Django"), new(5, 4, "Flask") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
        }
    }
}