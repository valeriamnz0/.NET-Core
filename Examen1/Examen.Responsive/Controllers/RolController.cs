using Examen.DataAccess.Data;
using Examen.DataAccess.Repository;
using Examen.DataAccess.Repository.UnitOfWork;
using Examen.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Models.DataModels;

namespace Examen.Controllers
{
    public class RolController : Controller
    {
        public RolController(IUnitOfWork<ApplicationDbContext> unitOfWork, IApplicationDbContext context)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.Repository<Rol>();

            Context = context;
        }

        readonly IUnitOfWork<ApplicationDbContext> UnitOfWork;
        readonly IRepository<Rol> Repository;
        IApplicationDbContext Context;

        public IActionResult Index()
        {
            return View(Repository.Listar());
        }

        public IActionResult Upsert(int? id)
        {
            Rol Rol = new Rol();
            if (id == null)
            {
                return View(Rol);
            }

            Rol = Repository.Obtener(id.GetValueOrDefault());
            if (Rol == null)
            {
                return NotFound();
            }

            return View(Rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Rol Rol)
        {
            if (ModelState.IsValid)
            {
                if (Rol.Id == 0)
                {
                    Repository.Insertar(Rol);
                }
                else
                {
                    Repository.Actualizar(Rol);
                }

                UnitOfWork.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(Rol);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Rol = Repository.Obtener(id);

            if (Rol == null)
            {
                return Json(new { success = false, message = $"No se encuentra el Rol con id {id}" });
            }

            Repository.Borrar(Rol);
            UnitOfWork.Guardar();

            return Json(new { success = true, message = "Rol eliminado exitosamente." });
        }

        //public IActionResult ReporteMatriculadosRol(int? id)
        //{

        //    Matricula matricula = new Matricula();
        //    if (id == null)
        //    {
        //        return View(matricula);
        //    }

        //    List<Matricula> matriculas =
        //        Context.Matriculas.Where(w => w.IdRolMat == id).ToList();

        //    if (matriculas == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(matriculas);

        //}
    }
}

