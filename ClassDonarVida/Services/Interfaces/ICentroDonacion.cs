using ClassDonarVida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDonarVida.Services.Interfaces
{
    public interface ICentroDonacion
    {
        Task<List<CentroDonacion>> GetAllAsync();
        Task<CentroDonacion> GetByIdAsync(int id);
        Task<bool> CreateAsync(CentroDonacion centro);
        Task<bool> UpdateAsync(CentroDonacion centro);
        Task<bool> DeleteAsync(int id);
    }
}
