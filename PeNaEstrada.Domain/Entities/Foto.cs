// PeNaEstrada.Domain/Entities/Foto.cs

using System;

namespace PeNaEstrada.Domain.Entities
{
    // Esta entidade representa uma foto na galeria de uma experiência
    public class Foto
    {
        // Chave Primária
        public int Id { get; set; }

        // O caminho (URL) para a imagem salva
        public string ImagemUrl { get; set; }

        public DateTime DataUpload { get; set; }

        // --- Relação de Volta (N-para-1) ---

        // A Chave Estrangeira que aponta para a Experiencia
        public int ExperienciaId { get; set; }

        // A Propriedade de Navegação "de volta" para a Experiencia
        public virtual Experiencia Experiencia { get; set; }

        public Foto()
        {
            DataUpload = DateTime.UtcNow;
        }
    }
}