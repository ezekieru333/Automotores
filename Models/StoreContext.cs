using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Models
{
    public class StoreContext : IdentityDbContext //Se cambió DbContext por IdentityDbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        //Agregado por sugerencia de
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Individuo> Individuos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<DocumentoTipo> DocumentoTipos { get; set; }
        public DbSet<MotorTipo> MotorTipos { get; set; }
        public DbSet<Transmision> Transmisiones { get; set; }
    }
}
