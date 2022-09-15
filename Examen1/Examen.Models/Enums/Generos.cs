using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.Enums
{
    public enum Generos
    {
        [Display(Name = "Masculino")]
        MASCULINO = 1,
        [Display(Name = "Femenino")]
        FEMENINO
    }
}
