using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeNaEstrada.Application.Interfaces;
using PeNaEstrada.Domain.Entities;
using PeNaEstrada.Server.DTOs;
using System.Security.Claims;

namespace PeNaEstrada.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class ExperienciasController : ControllerBase
    {
        private readonly IExperienciaRepository _repository;
        private readonly IWebHostEnvironment _environment; // Para saber onde é a pasta wwwroot

        public ExperienciasController(IExperienciaRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ExperienciaDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            
            string nomeArquivo = string.Empty;

            if (model.Imagem != null)
            {
                
                string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(model.Imagem.FileName);

                
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

                
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string filePath = Path.Combine(uploadsFolder, uniqueName);

                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Imagem.CopyToAsync(stream);
                }

                
                nomeArquivo = Path.Combine("uploads", uniqueName).Replace("\\", "/");
            }

            
            var experiencia = new Experiencia
            {
                UserId = userId,
                Descricao = model.Descricao,
                DataDaExperiencia = model.DataDaExperiencia,
                Local = model.Local,
                Tipo = model.Tipo,
                Nota = model.Nota,
                Publica = model.Publica,
                ImagemUrlPrincipal = nomeArquivo, 
                DataUpload = DateTime.UtcNow
            };

            
            await _repository.AddAsync(experiencia);

            return CreatedAtAction(nameof(Create), new { id = experiencia.Id }, experiencia);
        }
    }
}