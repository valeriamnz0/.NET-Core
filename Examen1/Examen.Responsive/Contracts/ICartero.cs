using Examen.Models.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Contracts
{
    public interface ICartero
    {
        void Enviar(CorreoElectronico correo);
    }
}
