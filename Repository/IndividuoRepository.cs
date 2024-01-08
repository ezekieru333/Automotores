using Automotores.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Repository
{
    public class IndividuoRepository : IRepository<Individuo>
    {
        private StoreContext _context;

        public IndividuoRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Individuo>> Get()
            => await _context.Individuos.ToListAsync();

        public async Task<Individuo> GetById(int id)
            => await _context.Individuos.FindAsync(id);

        public async Task Add(Individuo individuo)
            => await _context.Individuos.AddAsync(individuo);

        public void Update(Individuo individuo)
        {
            _context.Individuos.Attach(individuo);
            _context.Individuos.Entry(individuo).State = EntityState.Modified;
        }

        public void Delete(Individuo individuo)
            => _context.Individuos.Remove(individuo);

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
