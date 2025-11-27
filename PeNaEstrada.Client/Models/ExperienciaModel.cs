using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace PeNaEstrada.Client.Models
{
    public class ExperienciaModel
    {
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime DataDaExperiencia { get; set; }

        [Required(ErrorMessage = "O local é obrigatório")]
        public string Local { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string Tipo { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5")]
        public int Nota { get; set; }

        public bool Publica { get; set; } = true; // valor padrão

        [Required(ErrorMessage = "A imagem é obrigatória")]
        public IBrowserFile? Imagem { get; set; }
    }
}