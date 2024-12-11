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
    public class DonacionService : IDonacion
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://donarvida.azurewebsites.net/api/donacions";

        public DonacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Donacion>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Donacion>>(BaseUrl)
                   ?? new List<Donacion>();
        }

        public async Task<Donacion> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Donacion>($"{BaseUrl}/{id}")
                   ?? throw new InvalidOperationException("Donación no encontrada.");
        }

        public async Task<bool> CreateAsync(Donacion donacion)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, donacion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Donacion donacion)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{donacion.Id}", donacion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}