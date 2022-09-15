using Examen.Models.DataTransferModels;
using Examen.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Models.DataModels
{
    public class Empleado
    {
        public Empleado()
        {

        }

        public Empleado(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Colocar el numero de Cedula.")]
        public int Cedula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del Empleado es requerido.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "La longitud del Nombre debe ser entre 3 y 40 catacteres.")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Los Apellidos del Empleado son requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La longitud de los Apellidos deben ser entre 3 y 100 catacteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El Género es requerido.")]
        [Display(Name = "Género", GroupName = "genero")]
        public string Genero { get; set; }

        //[Required(ErrorMessage = "La Fecha de Nacimiento de requerida.")]
        //[Display(Name = "Fecha de Nacimiento")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Correo Electrónico del Empleado es requerido.")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "El largo del Correo Electrónico debe ser entre 5 y 250 catacteres.")]
        public string CorreoElectronico { get; set; }

        //[Required(ErrorMessage = "Debe selecionar una Provincia.")]
        //[Range(1, 7, ErrorMessage = "Debe seleccionar una Provincia.")]
        //public int Provincia { get; set; }

        //[Required(ErrorMessage = "Debe selecionar un Cantón.")]
        //public int Canton { get; set; }

        //[Required(ErrorMessage = "Debe selecionar un Distrito.")]
        //public int Distrito { get; set; }


    }
}
