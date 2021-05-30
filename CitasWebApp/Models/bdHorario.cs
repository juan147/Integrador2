using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class horario
    {
        public IEnumerable<horario> ObtenerHorario_x_Medico(string id)
        {
            Entities db = new Entities();
            IEnumerable<horario> list;
            list = db.horarios.Where(x => x.id == id).ToList();

            return list;
        }

        public bool GrabarHorario_x_Medico(horario obj)
        {
            Entities db = new Entities();
            horario horario = new horario()
            {
                id= obj.id,
                idHora= obj.idHora,
                lunes= obj.lunes,
                martes= obj.martes,
                miercoles= obj.miercoles,
                jueves= obj.jueves,
                viernes= obj.viernes,
                sabado= obj.sabado
            };
            db.horarios.Add(horario);
            db.SaveChanges();

            return true;
        }

        public bool EliminarHorario_x_Medico(string id)
        {
            Entities db = new Entities();
            IEnumerable<horario> objList = ObtenerHorario_x_Medico(id);
            db.horarios.RemoveRange(objList);
            db.SaveChanges();

            return true;
        }
    }
}