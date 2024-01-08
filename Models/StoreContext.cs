using Microsoft.EntityFrameworkCore;

namespace Automotores.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

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
