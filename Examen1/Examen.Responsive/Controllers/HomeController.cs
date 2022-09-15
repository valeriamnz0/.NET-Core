using Examen.Models.DataTransferModels;
using Examen.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Elemento> lista = new List<Elemento>();
            lista.Add(new Elemento(1, "Pan"));
            lista.Add(new Elemento(2, "Doble Torta 1/4 libra"));
            lista.Add(new Elemento(3, "Triple Queso Mozzarella"));
            lista.Add(new Elemento(4, "Triple Queso Suizo"));
            lista.Add(new Elemento(5, "Mayonesa"));
            lista.Add(new Elemento(6, "Barbacoa"));
            lista.Add(new Elemento(7, "Tocineta"));
            lista.Add(new Elemento(8, "Cebolla Caramelizada"));
            lista.Add(new Elemento(9, "Pepinillos"));
            lista.Add(new Elemento(10, "Jalapeños"));

            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
