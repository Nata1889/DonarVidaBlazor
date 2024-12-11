using ClassDonarVida.Models;
using ClassDonarVida.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassDonarVida.Services
{
    public class DonanteService : IDonanteService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://donarvida.azurewebsites.net/api/donantes";
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public DonanteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Donante>> GetAllAsync()
        {
            //    return await _httpClient.GetFromJsonAsync<IEnumerable<Donante>>(BaseUrl)
            //           ?? new List<Donante>();
            var response = await _httpClient.GetAsync(BaseUrl);
            var content = await response.Content.ReadAsStringAsync();
            if(!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }
            return JsonSerializer.Deserialize<List<Donante>>(content, _jsonSerializerOptions)
                   ?? new List<Donante>();
            //return await _httpClient.GetFromJsonAsync<List<Donante>>(BaseUrl)
            //       ?? new List<Donante>();

        }

        public async Task<Donante> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Donante>($"{BaseUrl}/{id}")
                   ?? throw new InvalidOperationException("Donante no encontrado.");
        }

        public async Task<bool> CreateAsync(Donante donante)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, donante);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Donante donante)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{donante.Id}", donante);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
