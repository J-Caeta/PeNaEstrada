using PeNaEstrada.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeNaEstrada.Application.Interfaces
{
    // Este é o Padrão de Repositório
    // Ele define as operações de CRUD específicas para Experiencias
    public interface IExperienciaRepository
    {
        Task<Experiencia?> GetByIdAsync(int id);
        Task<IEnumerable<Experiencia>> GetByUserIdAsync(string userId);

        // (Vamos adicionar mais métodos aqui depois, como GetFeedPublicoAsync)

        Task AddAsync(Experiencia experiencia);
        void Update(Experiencia experiencia);
        void Delete(Experiencia experiencia);
    }
}