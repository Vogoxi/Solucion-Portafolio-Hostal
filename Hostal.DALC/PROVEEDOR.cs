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
    
    public partial class PROVEEDOR
    {
        public string RUT { get; set; }
        public string NOMBRE { get; set; }
        public string RUBRO { get; set; }
        public decimal USUARIO_ID { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
