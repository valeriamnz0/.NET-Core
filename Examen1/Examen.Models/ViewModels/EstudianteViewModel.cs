using Examen.Models.DataTransferModels;
using Examen.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        public EmpleadoViewModel()
        {
            Provincias = new List<Elemento>();
            Saludos = new List<Elemento2>();
        }

        public EmpleadoInputModel Empleado { get; set; }

        public List<Elemento> Provincias { get; set; }

        public List<Elemento2> Saludos { get; set; }
        //public object Saludos { get; set; } Ver porque esto estaba aqui
    }
}
