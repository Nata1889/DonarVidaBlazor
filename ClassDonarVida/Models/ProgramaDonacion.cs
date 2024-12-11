using ClassDonarVida.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDonarVida.Models
{
    public class ProgramaDonacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int CentroDonacionId { get; set; }
        public CentroDonacion? CentroDonacion { get; set; }
        public string TipoSangreSolicitada { get; set; }
    }
}
