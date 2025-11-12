using System;
using System.Collections.Generic;

namespace PeNaEstrada.Domain.Entities
{
    // Esta é a nossa entidade "Agregada Raiz" (Aggregate Root)
    // Ela representa o principal conceito de negócio.
    public class Experiencia
    {
        // Chave Primária
        public int Id { get; set; }

        // Chave estrangeira para o usuário (do .NET Identity)
        // Usamos string, pois o ID padrão do IdentityUser é uma string (GUID)
        public string UserId { get; set; }

        public string Descricao { get; set; }
        public DateTime DataDaExperiencia { get; set; }
        public string Local { get; set; }

        // (Futuramente, podemos trocar "string" por um "Enum" aqui)
        public string Tipo { get; set; } // trilha, hospedagem, etc.

        public int Nota { get; set; } // 1 a 5
        public bool Publica { get; set; }
        public DateTime DataUpload { get; set; }

        // --- Propriedades de Navegação (Relações) ---

        // Uma Experiencia tem UMA foto principal (Capa)
        // Usamos string (URL) para a foto principal, conforme seu plano.
        public string ImagemUrlPrincipal { get; set; }

        // Uma Experiencia pode ter MUITAS outras fotos (Galeria)
        // Esta é a Relação 1-para-N
        public virtual ICollection<Foto> GaleriaDeFotos { get; set; }

        // (Opcional, mas recomendado para o Feed)
        // public virtual ICollection<Curtida> Curtidas { get; set; }
        // public virtual ICollection<Comentario> Comentarios { get; set; }


        // Construtor para inicializar as listas (boa prática)
        public Experiencia()
        {
            GaleriaDeFotos = new HashSet<Foto>();
            // Curtidas = new HashSet<Curtida>();
            // Comentarios = new HashSet<Comentario>();
            DataUpload = DateTime.UtcNow; // Garante que a data de upload seja definida
        }
    }
}