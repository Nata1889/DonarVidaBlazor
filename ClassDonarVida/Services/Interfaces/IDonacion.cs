using ClassDonarVida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDonarVida.Services.Interfaces
{
    public interface IDonacion
    {
        Task<List<Donacion>> GetAllAsync();
        Task<Donacion> GetByIdAsync(int id);
        Task<bool> CreateAsync(Donacion donacion);
        Task<bool> UpdateAsync(Donacion donacion);
        Task<bool> DeleteAsync(int id);
    }
}
