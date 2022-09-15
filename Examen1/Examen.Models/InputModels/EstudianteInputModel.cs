using Examen.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.InputModels
{
    public class EmpleadoInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Saludo es requerido.")]
        public int Saludo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del Empleado es requerido.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "El largo del Nombre debe ser entre 3 y 40 catacteres.")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Apellidos del Empleado es requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El largo de los Apellidos debe ser entre 3 y 100 catacteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El Género es requerido.")]
        [Display(Name = "Género", GroupName = "genero")]
        public Generos Genero { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento de requerida.")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), minimum: "1900-01-01", maximum: "2020-12-31", ErrorMessage = "La Fecha de Nacimiento debe ser un día entre el 1 de Enero de 1900 y el 31 de Diciembre del 2020.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Correo Electrónico del Empleado es requerido.")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "El largo del Correo Electrónico debe ser entre 5 y 250 catacteres.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Provincia.")]
        [Range(1, 7, ErrorMessage = "Debe seleccionar una Provincia.")]
        public int Provincia { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Cantón.")]
        public int Canton { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Distrito.")]
        public int Distrito { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Las Señas de la Dirección del Empleado son requeridas.")]
        [Display(Name = "Señas")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "El largo de las Señas de la Dirección debe ser entre 5 y 500 catacteres.")]
        public string Senas { get; set; }
    }
}
