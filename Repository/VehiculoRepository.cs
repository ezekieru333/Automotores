using Automotores.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Repository
{
    public class VehiculoRepository : IRepository<Vehiculo>
    {
        private StoreContext _context;

        public VehiculoRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> Get()
            => await _context.Vehiculos.ToListAsync();

        public async Task<Vehiculo> GetById(int id)
            => await _context.Vehiculos.FindAsync(id);

        public async Task Add(Vehiculo vehiculo)
            => await _context.Vehiculos.AddAsync(vehiculo);

        public void Update(Vehiculo vehiculo)
        {
            _context.Vehiculos.Attach(vehiculo);
            _context.Vehiculos.Entry(vehiculo).State = EntityState.Modified;
        }

        public void Delete(Vehiculo vehiculo)
            => _context.Vehiculos.Remove(vehiculo);

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
