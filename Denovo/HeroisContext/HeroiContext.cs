using Microsoft.EntityFrameworkCore;
using Models;

namespace Herois.Context;

public class HeroiContext : DbContext
{
    public HeroiContext(DbContextOptions<HeroiContext> options) : base(options)
    {
    }

    public DbSet<Heroi> Herois { get; set; }
    public DbSet<Batalha> Batalhas { get; set; }

    public DbSet<Arma> Armas { get; set; }

    public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

    public DbSet<IdentidadesSecretas> IdentidadesSecretas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroiBatalha>()
           .HasKey(hb => new { hb.HeroiId, hb.BatalhaId });

        modelBuilder.Entity<HeroiBatalha>()
            .HasOne(hb => hb.Heroi)
            .WithMany(h => h.HeroiBatalhas)
            .HasForeignKey(hb => hb.HeroiId);

        modelBuilder.Entity<HeroiBatalha>()
            .HasOne(hb => hb.Batalha)
            .WithMany(b => b.HeroiBatalhas)
            .HasForeignKey(hb => hb.BatalhaId);
    }
}