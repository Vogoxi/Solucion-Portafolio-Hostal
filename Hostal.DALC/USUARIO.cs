//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hostal.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        public USUARIO()
        {
            this.EMPLEADO = new HashSet<EMPLEADO>();
            this.PRIVILEGIO = new HashSet<PRIVILEGIO>();
        }
    
        public decimal ID { get; set; }
        public string USUARIO1 { get; set; }
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO { get; set; }
    
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
        public virtual ICollection<PRIVILEGIO> PRIVILEGIO { get; set; }
    }
}
