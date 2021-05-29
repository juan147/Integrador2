using CitasWebApp.Models;
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
    }
}