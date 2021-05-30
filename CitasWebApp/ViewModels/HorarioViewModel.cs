using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasWebApp.ViewModels
{
    public class HorarioViewModel
    {
        public string IdDoctor { get; set; }
        public int IdHora { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
    }
}