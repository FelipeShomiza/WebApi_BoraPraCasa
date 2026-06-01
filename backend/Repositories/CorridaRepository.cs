using CorridaAPI.Data;
using CorridaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorridaAPI.Repositories
{
    public class CorridaRepository : ICorridaRepository
    {
        private readonly AppDbContext _context;

        public CorridaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Corrida>> GetAllAsync()
        {
            return await _context.Corridas.ToListAsync();
        }

        public async Task<Corrida?> GetByIdAsync(int id)
        {
            return await _context.Corridas.FindAsync(id);
        }

        public async Task AddAsync(Corrida corrida)
        {
            _context.Corridas.Add(corrida);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Corrida corrida)
        {
            _context.Corridas.Update(corrida);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var corrida = await _context.Corridas.FindAsync(id);

            if (corrida != null)
            {
                _context.Corridas.Remove(corrida);
                await _context.SaveChangesAsync();
            }
        }
    }
}