using System.ComponentModel.DataAnnotations;

namespace PeNaEstrada.Server.DTOs
{
    public class ExperienciaDto
    {
      
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime DataDaExperiencia { get; set; }

        [Required(ErrorMessage = "O local é obrigatório")]
        public string Local { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string Tipo { get; set; } = string.Empty; 

        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5")]
        public int Nota { get; set; }

        public bool Publica { get; set; }

       
        [Required(ErrorMessage = "Experiência sem mídia não dá..")]
        public IFormFile Imagem { get; set; }
    }
}