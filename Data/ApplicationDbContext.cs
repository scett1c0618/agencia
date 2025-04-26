using Microsoft.EntityFrameworkCore;
using appAgencia.Models;

namespace appAgencia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regiones { get; set; }
        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las relaciones
            modelBuilder.Entity<Destino>()
                .HasOne(d => d.Region)
                .WithMany(r => r.Destinos)
                .HasForeignKey(d => d.id_region);
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}