using CitasWebApp.Models;
using CitasWebApp.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasWebApp.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        hora _hora= new hora();
        horario _horario = new horario();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Schedule
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            List<ApplicationUser> users = UserManager.Users.Where(u => u.idTipo.Contains("2")).ToList();
            IEnumerable<hora> horas = _hora.ListarHoras();
            mymodel.doctores = users;
            mymodel.horas = horas;

            return View(mymodel);
        }

        [HttpPost]
        public JsonResult Modificar(HorarioViewModel obj)
        {

            bool respuesta = false;
            respuesta = _horario.GrabarHorario_x_Medico(new horario
            {
                id=obj.IdDoctor,
                idHora=obj.IdHora,
                lunes=obj.Lunes,
                martes=obj.Martes,
                miercoles=obj.Miercoles,
                jueves=obj.Jueves,
                viernes=obj.Viernes,
                sabado=obj.Sabado
            });

            return Json(new { operacion = respuesta, errMsg = "" });

        }
    }
}