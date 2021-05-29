using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class hora
    {
        public IEnumerable<hora> ListarHoras()
        {
            Entities db = new Entities();
            IEnumerable<hora> list;
            list = db.horas.ToList();

            return list;
        }
    }
}