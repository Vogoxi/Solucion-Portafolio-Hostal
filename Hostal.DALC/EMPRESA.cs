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
    
    public partial class EMPRESA
    {
        public EMPRESA()
        {
            this.FACTURA = new HashSet<FACTURA>();
            this.HUESPED = new HashSet<HUESPED>();
        }
    
        public string RUT { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string GIRO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public long USUARIO_ID { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<FACTURA> FACTURA { get; set; }
        public virtual ICollection<HUESPED> HUESPED { get; set; }
    }
}
