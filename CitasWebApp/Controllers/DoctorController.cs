using CitasWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Dynamic;

namespace CitasWebApp.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private doctore _doctor;
        private especialidade _especialidad;

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
            _especialidad = new especialidade();
            _doctor = new doctore();
            dynamic mymodel = new ExpandoObject();
            ApplicationUser user = new ApplicationUser();
            if (id != null &&  id != "0")
            {
                user = UserManager.FindByEmail(id);
                _doctor = _doctor.ObtenerDoctor(user.Id);
            }
            mymodel.user = new RegisterViewModel
            {
                Email=user.Email,
                Name=user.UserName,
                LastName=user.apellidos,
                Phone=user.PhoneNumber,
                IdEspecialidad=_doctor.idEspecialidad
            };
            mymodel.specialty = _especialidad.ListarEspecialidades();

            return PartialView(mymodel);
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
                        var _user = await UserManager.FindByNameAsync(model.Email);
                        _doctor = new doctore();
                        _doctor.id = _user.Id;
                        _doctor.idEspecialidad = model.IdEspecialidad;
                        _doctor.CrearDoctor(_doctor);
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