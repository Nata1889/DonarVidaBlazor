using ClassDonarVida.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassDonarVida.Models
{
    public class Donante 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string GrupoSanguineo { get; set; }
        public string FactorRH { get; set; }
        public string Contacto { get; set; } = string.Empty;

        public override string ToString()
        {
            return Nombre;
        }

    }


}
