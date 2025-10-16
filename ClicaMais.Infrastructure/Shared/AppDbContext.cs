using System.Security.Cryptography.X509Certificates;
using ClicaMais.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClicaMais.Infrastructure.Shared;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options) { }
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Saque> Saques { get; set; }
    public DbSet<Nivel> Niveis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jogador>().ToTable("Jogadores")
            .HasOne(j => j.NivelAtual)
            .WithMany()
            .HasForeignKey(j => j.NivelAtualId);
        modelBuilder.Entity<Saque>().ToTable("Saques");
        modelBuilder.Entity<Nivel>().ToTable("Niveis");
    
        base.OnModelCreating(modelBuilder);
    }
}