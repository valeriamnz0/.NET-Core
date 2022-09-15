using Examen.Contracts;
using Examen.Models.ConfigurationModels;
using Examen.Models.PlainModels;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Text.Json;

namespace Examen.Components
{
    public class RecaptchaValidator : IRecaptchaValidator
    {
        public RecaptchaValidator(IOptions<ConfiguracionRecaptcha> configuracion)
        {
            Configuracion = configuracion.Value;
        }
        ConfiguracionRecaptcha Configuracion;
        public bool Validate(string response)
        {
            //nos conectamos a Google para ver si el token es válido
            string address =
                string.Format
                    ("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", Configuracion.SecretKey, response);
            Uri uri = new Uri(address);
            try
            {
                WebClient client = new WebClient();
                string result = client.DownloadString(uri);
                var options =
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    };
                RecaptchaModel model = JsonSerializer.Deserialize<RecaptchaModel>(result, options);
                if (!model.Success)
                {
                    string exceptionMessage = string.Empty;
                    foreach (var errorCode in model.ErrorCodes)
                    {
                        exceptionMessage += string.Concat(errorCode, "\n");
                    }
                    throw new Exception(exceptionMessage);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
