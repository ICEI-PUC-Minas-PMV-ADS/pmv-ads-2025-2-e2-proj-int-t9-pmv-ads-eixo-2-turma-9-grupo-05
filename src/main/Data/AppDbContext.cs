using EcoTrash.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoTrash.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Empresa> Empresas { get; set; } = null!;
        public DbSet<Pesagem> Pesagens { get; set; } = null!;
        public DbSet<LocalColeta> Locais { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Empresa>()
                .HasIndex(e => e.CNPJ)
                .IsUnique();

            modelBuilder.Entity<Empresa>()
                .HasIndex(e => e.Email)
                .IsUnique();

            
            modelBuilder.Entity<Pesagem>().ToTable("Pesagens");
            modelBuilder.Entity<LocalColeta>().ToTable("Locais");
        }
    }
}