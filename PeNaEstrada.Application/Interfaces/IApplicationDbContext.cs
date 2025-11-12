using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Domain.Entities; // Importa nossas Entidades
using System.Threading;
using System.Threading.Tasks;

namespace PeNaEstrada.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        // Define quais "tabelas" (DbSets) o Application pode ver
        DbSet<Experiencia> Experiencias { get; }
        DbSet<Foto> Fotos { get; }

        // Expõe o método SaveChangesAsync
        // Isso permite ao Application controlar quando salvar as mudanças (Unit of Work)
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}