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
    
    public partial class EMPLEADO
    {
        public EMPLEADO()
        {
            this.PEDIDO = new HashSet<PEDIDO>();
        }
    
        public long ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public long USUARIO_ID { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
    }
}
