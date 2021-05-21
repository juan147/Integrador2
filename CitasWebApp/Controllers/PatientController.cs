using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitasWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CitasWebApp.Controllers
{
    public class PatientController : Controller
    {
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

        // GET: Patient
        public ActionResult Index()
        {
            List<ApplicationUser> users = UserManager.Users.Where(u => u.idTipo.Contains("1")).ToList();
            return View(users);
        }
        // GET: Doctor
        [HttpGet]
        public ActionResult Register(string id)
        {
            ApplicationUser user = new ApplicationUser();
            if (id != "0")
            {
                user = UserManager.FindByEmail(id);
            }

            return PartialView(user);
        }

        [HttpPost]
        public JsonResult Deshabilitar(string id, string estado)
        {
            ApplicationUser user = UserManager.FindByEmail(id);

            user.estado = estado == "0" ? "1" : "0";

            UserManager.Update(user);
            bool respuesta = true;

            return Json(new { operacion = respuesta, errMsg = "" });

        }

        [HttpGet]
        public JsonResult Listar()
        {
            List<ApplicationUser> users = UserManager.Users.Where(u => u.idTipo.Contains("1")).ToList();

            return Json(new { data = users }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Registro(RegisterViewModel model)
        {

            if (model.Id == "1")
            {
                ApplicationUser user = UserManager.FindByEmail(model.Email);

                user.nombres = model.Name;
                user.apellidos = model.LastName;
                user.PhoneNumber = model.Phone;

                UserManager.Update(user);

                return Content("ok");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

    }
}