using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.DataTransferModels
{
    public class Elemento 
    {
        public Elemento()
        {

        }

        /// <summary>
        /// Construye una instancia del Elemento.
        /// </summary>
        /// <param name="id">Id único del Elemento.</param>
        /// <param name="nombre">Nombre del Elemento.</param>
        public Elemento(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        /// <summary>
        /// Asigna u Obtiene el Id del Elemento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Asigna u Obtiene el Nombre del Elemento.
        /// </summary>
        public string Nombre { get; set; }
    }
}
