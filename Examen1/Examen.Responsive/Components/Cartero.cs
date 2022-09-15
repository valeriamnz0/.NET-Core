using Examen.Contracts;
using Examen.Models.ConfigurationModels;
using Examen.Models.PlainModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Examen.Components
{
    public class Cartero : ICartero
    {
        //public Cartero(IConfiguration configuration)
        //{
        //    Configuracion = 
        //        configuration.GetSection("ConfiguracionSmtp").Get<ConfiguracionSmtp>();
        //}

        public Cartero(IOptions<ConfiguracionSmtp> configuracion)
        {
            Configuracion = configuracion.Value;
        }

        ConfiguracionSmtp Configuracion;

        public void Enviar(CorreoElectronico correo)
        {
            var cliente =
                new SmtpClient
                {
                    Host = Configuracion.Servidor,
                    Port = Configuracion.Puerto,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials =
                        new NetworkCredential(Configuracion.Usuario, Configuracion.Contrasena)
                };

            var mensaje =
                new MailMessage
                {
                    From = new MailAddress(Configuracion.Remitente),
                    Subject = correo.Asunto,
                    Body = correo.Cuerpo,
                    IsBodyHtml = false
                };

            mensaje.To.Add(new MailAddress(correo.Destinatario));
            cliente.Send(mensaje);
        }
    }
}
