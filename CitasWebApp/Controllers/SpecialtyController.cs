using CitasWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CitasWebApp.Controllers
{
    public class SpecialtyController : Controller
    {
        especialidade objEspecialidad = new especialidade();

        // GET: Specialty
        public ActionResult Index()
        {
            
            IEnumerable<especialidade> list= objEspecialidad.ListarEspecialidades();

            return View(list);
        }

        [HttpPost]
        public JsonResult Modificar(string id, string descripcion)
        {
            objEspecialidad.idEspecialidad =int.Parse(id);
            objEspecialidad.descripcion = descripcion;

            bool respuesta = false;

            if (objEspecialidad.idEspecialidad==0)
            {
                respuesta = objEspecialidad.CrearEspecialidad(objEspecialidad);
            }
            else
            {
                respuesta = objEspecialidad.ModificarEspecialidad(objEspecialidad);
            }

            return Json(new { operacion=respuesta, errMsg = "" });

        }

        [HttpPost]
        public JsonResult Deshabilitar(string id, string estado)
        {
            objEspecialidad.idEspecialidad = int.Parse(id);
            objEspecialidad.estado = estado == "1"? "0" : "1";

            bool respuesta = objEspecialidad.DeshabilitarEspecialidad(objEspecialidad);

            return Json(new { operacion = respuesta, errMsg = "" });

        }

        [HttpGet]
        public JsonResult Listar()
        {
            IEnumerable<especialidade> list = objEspecialidad.ListarEspecialidades();

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

        }
    }
}