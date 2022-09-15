using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Models.DataModels
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Colocar el numero de Cedula.")]
        public int Cedula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del Cliente es requerido.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "La longitud del Nombre debe ser entre 3 y 40 catacteres.")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Los Apellidos del Cliente son requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La longitud de los Apellidos deben ser entre 3 y 100 catacteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento de requerida.")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Correo Electrónico del Cliente es requerido.")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "El largo del Cliente debe ser entre 5 y 250 catacteres.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido")]
        public int Telefono { get; set; }
    }


}

