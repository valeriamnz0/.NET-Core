using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models.ConfigurationModels
{
    public class ConfiguracionSmtp
    {
        public string Remitente { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string Servidor { get; set; }

        public int Puerto { get; set; }
    }
}
