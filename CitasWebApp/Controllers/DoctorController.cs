using CitasWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace CitasWebApp.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

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

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }


        // GET: Doctor
        public ActionResult Index()
        {
            List<ApplicationUser> users = UserManager.Users.Where(u => u.idTipo.Contains("2")).ToList();
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

            user.estado = estado == "0"? "1":"0";

            UserManager.Update(user);
            bool respuesta = true;

            return Json(new { operacion = respuesta, errMsg = "" });

        }

        [HttpGet]
        public JsonResult Listar()
        {
            List<ApplicationUser> users = UserManager.Users.Where(u => u.idTipo.Contains("2")).ToList();

            return Json(new { data = users }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public async Task<ActionResult> Registro(RegisterViewModel model)
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
                else
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email, idTipo = "2", nombres = model.Name, apellidos = model.LastName, estado = "1", PhoneNumber=model.Phone };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        return Content("ok");
                    }
                    AddErrors(result);
                }
            

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}