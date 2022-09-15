using Examen.Contracts;
using Examen.DataAccess.Data;
using Examen.DataAccess.Repository;
using Examen.DataAccess.Repository.UnitOfWork;
using Examen.Models.DataModels;
using Examen.Models.DataTransferModels;
using Examen.Models.InputModels;
using Examen.Models.PlainModels;
using Examen.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class EmpleadoController : Controller
    {

        public EmpleadoController(IUnitOfWork<ApplicationDbContext> unitOfWork, ICartero cartero, IApplicationDbContext context)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.Repository<Empleado>();
            Cartero = cartero;
            Context = context;
        }

        readonly IUnitOfWork<ApplicationDbContext> UnitOfWork;
        readonly IRepository<Empleado> Repository;

        ICartero Cartero;
        IApplicationDbContext Context;

        public IActionResult Index(int id = 0)
        {

            return View(Repository.Listar());
        }


        public IActionResult Upsert(int? id)
        {


            Empleado Empleado
                = new Empleado
                {

                };


            if (id == null)
            {
                return View(Empleado);
            }

            Empleado = Repository.Obtener(id.GetValueOrDefault());
            if (Empleado == null)
            {
                return NotFound();
            }

            return View(Empleado);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Empleado Empleado)
        {
            

            if (ModelState.IsValid)
            {
                if (Empleado.Id == 0)
                {
                    Repository.Insertar(Empleado);
                    Cartero.Enviar
                    (
                        new CorreoElectronico
                        {
                            Destinatario = Empleado.CorreoElectronico,
                            Asunto = "Bienvenido a la Universidad Fidelitas",
                            Cuerpo = "Hola " + Empleado.Nombre + "\n" + "De parte de la Universidad Fidelitas esperamos que se encuentre muy bien." + "\n" +
                                     "Le damos una gran bienvenidad a la comunidad de Empleados de la Universidad fidelitas, esperamos que disfrute mucho todo el proceso de aprendizaje hasta llegar a ser un gran profesional!!!" + "\n" + "\n" +
                                     "Por favor si usted no ha creado una cuenta de Empleado con este correo electronico, notifiquelo a la Universidad Fidelitas"
                        }
                    );
                }
                else
                {
                    Repository.Actualizar(Empleado);
                }

                UnitOfWork.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(Empleado);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Empleado = Repository.Obtener(id);

            if (Empleado == null)
            {
                return Json(new { success = false, message = $"No se encuentra el Empleado con id {id}" });
            }

            Repository.Borrar(Empleado);
            UnitOfWork.Guardar();

            return Json(new { success = true, message = "Empleado eliminado exitosamente." });
        }

        //[HttpGet]
        //[Route("api/Empleado/upsert/cantones")]
        //public IActionResult ListarCantones(int provincia)
        //{
        //    List<Canton> cantones =
        //        Context.Cantones.Where(w => w.IdProvincia == provincia).ToList();

        //    var contentido =
        //        new
        //        {
        //            success = cantones != null || cantones.Count == 0,
        //            content = cantones,
        //            error =
        //                cantones == null || cantones.Count == 0
        //                    ? "No se han encontrado cantones para la provincia seleccionada."
        //                    : string.Empty
        //        };

        //    return Json(contentido);
        //}

        //[HttpGet]
        //[Route("api/Empleado/upsert/distritos")]
        //public IActionResult ListarDistritos(int canton)
        //{
        //    List<Distrito> distritos =
        //        Context.Distritos.Where(w => w.IdCanton == canton).ToList();

        //    var contentido =
        //        new
        //        {
        //            success = distritos != null || distritos.Count == 0,
        //            content = distritos,
        //            error =
        //                distritos == null || distritos.Count == 0
        //                    ? "No se han encontrado distritos para el canton seleccionado."
        //                    : string.Empty
        //        };

        //    return Json(contentido);
        //}

    }
}
