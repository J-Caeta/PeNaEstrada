using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Infrastructure.Identity; // Importa nossa classe ApplicationUser

namespace PeNaEstrada.Infrastructure.Persistence
{
    // Nossa classe de Contexto herda de IdentityDbContext,
    // e informamos que ele deve usar nossa classe ApplicationUser.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // O construtor recebe as "options" (como a string de conexão)
        // do nosso projeto Server e as passa para a classe base do EF Core.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // --- NOSSAS TABELAS DO DOMAIN IRÃO AQUI ---
        // Ex: public DbSet<Experiencia> Experiencias { get; set; }
        // (Adicionaremos isso quando modelarmos o Domain)

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Aqui podemos configurar o modelo (Ex: nomes de tabelas, chaves)
            // se precisarmos de algo além do padrão.
        }
    }
}