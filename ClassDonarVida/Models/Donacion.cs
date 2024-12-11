using ClassDonarVida.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDonarVida.Models
{
    public class Donacion 
    {
        public int Id { get; set; }
        public int DonanteId { get; set; }
        public Donante? Donante { get; set; }
        public DateOnly FechaDonacion { get; set; }
        public string TipoDonacion { get; set; }
        public int ProgramaDonacionId { get; set; }
        public ProgramaDonacion? ProgramaDonacion { get; set; }
    }
}
