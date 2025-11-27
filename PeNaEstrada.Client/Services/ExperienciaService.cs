using System.Net.Http.Headers;
using System.Net.Http.Json;
using PeNaEstrada.Client.Models;

namespace PeNaEstrada.Client.Services
{
    public class ExperienciaService
    {
        private readonly HttpClient _http;

        public ExperienciaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CriarExperiencia(ExperienciaModel model)
        {
            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(model.Descricao), "Descricao");
            content.Add(new StringContent(model.DataDaExperiencia.ToString("o")), "DataDaExperiencia");
            content.Add(new StringContent(model.Local), "Local");
            content.Add(new StringContent(model.Tipo), "Tipo");
            content.Add(new StringContent(model.Nota.ToString()), "Nota");
            content.Add(new StringContent(model.Publica.ToString()), "Publica");

            if (model.Imagem != null)
            {

                var fileContent = new StreamContent(model.Imagem.OpenReadStream(maxAllowedSize: 70 * 1300 * 1300));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.Imagem.ContentType);

                content.Add(fileContent, "Imagem", model.Imagem.Name);
            }

            var response = await _http.PostAsync("api/experiencias", content);

            return response.IsSuccessStatusCode;
        }
    }
}