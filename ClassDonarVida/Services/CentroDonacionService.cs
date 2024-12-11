using ClassDonarVida.Models;
using ClassDonarVida.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassDonarVida.Services
{
    public class CentroDonacionService : ICentroDonacion
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://donarvida.azurewebsites.net/api/centrodonacions";
        public CentroDonacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CentroDonacion>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CentroDonacion>>(BaseUrl)
                   ?? new List<CentroDonacion>();
        }

        public async Task<CentroDonacion> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CentroDonacion>($"{BaseUrl}/{id}")
                   ?? throw new InvalidOperationException("Centro no encontrado.");
        }

        public async Task<bool> CreateAsync(CentroDonacion centro)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, centro);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(CentroDonacion centro)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{centro.Id}", centro);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
