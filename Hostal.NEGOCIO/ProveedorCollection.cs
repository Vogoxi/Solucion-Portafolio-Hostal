using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class ProveedorCollection
    {
        public ProveedorCollection()
        {

        }


        private List<NEGOCIO.Proveedor> GenerarListado
            (List<DALC.PROVEEDOR> ProveedorDALC)
        {
            List<NEGOCIO.Proveedor> Proveedores =
                new List<NEGOCIO.Proveedor>();

            foreach (DALC.PROVEEDOR item in ProveedorDALC)
            {
                NEGOCIO.Proveedor ProvTemp = new NEGOCIO.Proveedor();
                ProvTemp.Rut = item.RUT;
                ProvTemp.Nombre = item.NOMBRE;
                ProvTemp.Rubro = item.RUBRO;
                ProvTemp.UsuarioId = (int)item.USUARIO_ID;

                Proveedores.Add(ProvTemp);

            }

            return Proveedores;
        }

        public List<NEGOCIO.Proveedor> ReadAll()
        {
            var reconversions = CommonBC.Modelo.PROVEEDOR;
            return GenerarListado(reconversions.ToList());
        }
    }
}
