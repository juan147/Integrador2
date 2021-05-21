using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class especialidad
    {
        public IEnumerable<especialidad> ListarEspecialidades()
        {
            Entities db = new Entities();
            IEnumerable<especialidad> list;
            list = db.especialidad.ToList();

            return list;
        }

        public bool ModificarEspecialidad(especialidad obj)
        {
            bool respuesta = false;
            try {
                Entities db = new Entities();
                especialidad vespecialidad = db.especialidad.Find(obj.idEspecialidad);
                vespecialidad.descripcion = obj.descripcion;
                db.Entry(vespecialidad).State = EntityState.Modified;
                db.SaveChanges();
                respuesta = true;
            } catch
            {

            }

            return respuesta;
        }

        public bool CrearEspecialidad(especialidad obj)
        {
            bool respuesta = false;
            try
            {
                Entities db = new Entities();
                especialidad vespecialidad = new especialidad()
                {
                    descripcion= obj.descripcion,
                    estado="1"
                };
                db.especialidad.Add(vespecialidad);
                db.SaveChanges();
                respuesta = true;
            }
            catch
            {

            }

            return respuesta;
        }

        public bool DeshabilitarEspecialidad(especialidad obj)
        {
            bool respuesta = false;
            try
            {
                Entities db = new Entities();
                especialidad vespecialidad = db.especialidad.Find(obj.idEspecialidad);
                vespecialidad.estado = obj.estado;
                db.Entry(vespecialidad).State = EntityState.Modified;
                db.SaveChanges();
                respuesta = true;
            }
            catch
            {

            }

            return respuesta;
        }
    }
}