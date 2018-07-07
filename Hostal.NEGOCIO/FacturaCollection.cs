using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class FacturaCollection
    {
        public FacturaCollection()
        {

        }

        private List<NEGOCIO.Factura> GenerarListado
            (List<DALC.FACTURA> FacturaDALC)
        {
            List<NEGOCIO.Factura> Facturas =
                new List<NEGOCIO.Factura>();

            foreach (DALC.FACTURA item in FacturaDALC)
            {
                NEGOCIO.Factura FactTemp = new NEGOCIO.Factura();
                FactTemp.Id = (int)item.ID;
                FactTemp.IdEmpresa = item.ID_EMPRESA;
                FactTemp.Total = (int)item.TOTAL;
                FactTemp.FechaFacturacion = (DateTime)item.FECHA_FACTURACION;

                Facturas.Add(FactTemp);
            }

            return Facturas;
        }

        public List<NEGOCIO.Factura> ReadAll()
        {
            var reconversions = CommonBC.Modelo.FACTURA.OrderBy(f => f.ID);
            return GenerarListado(reconversions.ToList());
        }
    }
}
