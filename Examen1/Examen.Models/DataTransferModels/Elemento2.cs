using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.DataTransferModels
{
    public class Elemento2 
    {
        public Elemento2()
        {

        }

        /// <summary>
        /// Construye una instancia del Elemento2.
        /// </summary>
        /// <param name="id">Id único del Elemento2.</param>
        /// <param name="nombre">Nombre del Elemento2.</param>
        public Elemento2(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        /// <summary>
        /// Asigna u Obtiene el Id del Elemento2.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Asigna u Obtiene el Nombre del Elemento2.
        /// </summary>
        public string Nombre { get; set; }
    }
}
