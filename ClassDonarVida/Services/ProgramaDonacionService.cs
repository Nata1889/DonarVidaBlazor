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
    public class ProgramaDonacionService : IProgramaDonacion
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://donarvida.azurewebsites.net/api/programadonacions";

        public ProgramaDonacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProgramaDonacion>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProgramaDonacion>>(BaseUrl)
                   ?? new List<ProgramaDonacion>();
        }

        public async Task<ProgramaDonacion> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProgramaDonacion>($"{BaseUrl}/{id}")
                   ?? throw new InvalidOperationException("Programa de donación no encontrado.");
        }

        public async Task<bool> CreateAsync(ProgramaDonacion programa)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, programa);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(ProgramaDonacion programa)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{programa.Id}", programa);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
