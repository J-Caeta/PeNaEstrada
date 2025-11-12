using Microsoft.AspNetCore.Identity;

namespace PeNaEstrada.Infrastructure.Identity
{
    // Esta classe representa o nosso usuário no sistema.
    // Ela herda todas as propriedades do Identity (Email, PasswordHash, etc.)
    // Podemos adicionar campos extras (Ex: NomeCompleto, FotoPerfil) aqui no futuro.
    public class ApplicationUser : IdentityUser
    {
    }
}