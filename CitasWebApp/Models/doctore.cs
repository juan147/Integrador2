//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CitasWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class doctore
    {
        public string id { get; set; }
        public Nullable<int> idEspecialidad { get; set; }
    
        public virtual especialidade especialidade { get; set; }
    }
}
