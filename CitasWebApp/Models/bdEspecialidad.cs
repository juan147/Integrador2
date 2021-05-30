using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class especialidade
    {
        public IEnumerable<especialidade> ListarEspecialidades()
        {
            Entities db = new Entities();
            IEnumerable<especialidade> list;
            list = db.especialidades.ToList();

            return list;
        }

        public bool ModificarEspecialidad(especialidade obj)
        {
            bool respuesta = false;
            try {
                Entities db = new Entities();
                especialidade vespecialidad = db.especialidades.Find(obj.idEspecialidad);
                vespecialidad.descripcion = obj.descripcion;
                db.Entry(vespecialidad).State = EntityState.Modified;
                db.SaveChanges();
                respuesta = true;
            } catch
            {

            }

            return respuesta;
        }

        public bool CrearEspecialidad(especialidade obj)
        {
            bool respuesta = false;
            try
            {
                Entities db = new Entities();
                especialidade vespecialidad = new especialidade()
                {
                    descripcion= obj.descripcion,
                    estado="1"
                };
                db.especialidades.Add(vespecialidad);
                db.SaveChanges();
                respuesta = true;
            }
            catch
            {

            }

            return respuesta;
        }

        public bool DeshabilitarEspecialidad(especialidade obj)
        {
            bool respuesta = false;
            try
            {
                Entities db = new Entities();
                especialidade vespecialidad = db.especialidades.Find(obj.idEspecialidad);
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