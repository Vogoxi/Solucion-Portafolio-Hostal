//------------------------------------------------------------------------------
// <auto-generated>
<<<<<<< HEAD
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
=======
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
>>>>>>> master
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hostal.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class FACTURA
    {
        public FACTURA()
        {
            this.DETALLE_FACTURA = new HashSet<DETALLE_FACTURA>();
        }
    
        public long ID { get; set; }
        public string TOTAL { get; set; }
        public string ID_EMPRESA { get; set; }
        public Nullable<System.DateTime> FECHA_FACTURACION { get; set; }
    
        public virtual ICollection<DETALLE_FACTURA> DETALLE_FACTURA { get; set; }
        public virtual EMPRESA EMPRESA { get; set; }
    }
}
