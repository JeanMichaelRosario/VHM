using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Db
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Placa> Placas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }


        public ApiDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación uno a muchos entre Propietario y Placa
            modelBuilder.Entity<Propietario>()
                .HasMany(p => p.Placas)
                .WithOne()
                .HasForeignKey(p => p.PropietarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación uno a uno entre Placa y Vehiculo
            modelBuilder.Entity<Placa>()
                .HasOne(p => p.Vehiculo)
                .WithOne()
                .HasForeignKey<Placa>(p => p.VehiculoId);

            modelBuilder.Entity<Placa>().HasIndex(p => p.Number).IsUnique();
        }
    }
}
