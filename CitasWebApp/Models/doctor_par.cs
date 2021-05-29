using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class doctore
    {
        public bool CrearDoctor(doctore obj)
        {
            bool respuesta = false;
            try
            {
                Entities db = new Entities();
                doctore vdoctore = new doctore()
                {
                    id = obj.id,
                    idEspecialidad = obj.idEspecialidad
                };
                db.doctores.Add(vdoctore);
                db.SaveChanges();
                respuesta = true;
            }
            catch
            {

            }

            return respuesta;
        }

        public doctore ObtenerDoctor(string id)
        {
            Entities db = new Entities();
            doctore objeto;
            objeto = db.doctores.Find(id);

            return objeto;
        }
    }
}