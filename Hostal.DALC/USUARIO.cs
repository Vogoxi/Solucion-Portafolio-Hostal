//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
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
            this.EMPRESA = new HashSet<EMPRESA>();
            this.PRIVILEGIO = new HashSet<PRIVILEGIO>();
<<<<<<< HEAD
=======
            this.EMPRESA = new HashSet<EMPRESA>();
>>>>>>> master
            this.PROVEEDOR = new HashSet<PROVEEDOR>();
        }
    
        public decimal ID { get; set; }
        public string USUARIO1 { get; set; }
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO { get; set; }
    
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
        public virtual ICollection<EMPRESA> EMPRESA { get; set; }
        public virtual ICollection<PRIVILEGIO> PRIVILEGIO { get; set; }
<<<<<<< HEAD
=======
        public virtual ICollection<EMPRESA> EMPRESA { get; set; }
>>>>>>> master
        public virtual ICollection<PROVEEDOR> PROVEEDOR { get; set; }
    }
}
