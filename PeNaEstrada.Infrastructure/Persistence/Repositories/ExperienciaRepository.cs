using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Application.Interfaces;
using PeNaEstrada.Domain.Entities;

namespace PeNaEstrada.Infrastructure.Persistence.Repositories
{
    public class ExperienciaRepository : IExperienciaRepository
    {
        private readonly ApplicationDbContext _context;

        public ExperienciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Experiencia experiencia)
        {
            await _context.Experiencias.AddAsync(experiencia);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<Experiencia?> GetByIdAsync(int id)
        {

            return await _context.Experiencias
                .Include(e => e.GaleriaDeFotos)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Experiencia>> GetByUserIdAsync(string userId)
        {
            return await _context.Experiencias
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.DataDaExperiencia)
                .ToListAsync();
        }

        public void Delete(Experiencia experiencia)
        {
            _context.Experiencias.Remove(experiencia);

            _context.SaveChanges();
        }

        public void Update(Experiencia experiencia)
        {
            _context.Experiencias.Update(experiencia);
            _context.SaveChanges();
        }
    }
}