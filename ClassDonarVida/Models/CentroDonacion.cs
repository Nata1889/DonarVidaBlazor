using ClassDonarVida.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDonarVida.Models
{
    public class CentroDonacion 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Capacidad { get; set; }
    }
}
