using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Models.InputModels
{
    public class Fpassword
    {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        
    }
}
