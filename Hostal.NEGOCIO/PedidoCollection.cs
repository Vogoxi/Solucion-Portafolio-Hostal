using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class PedidoCollection
    {
        public PedidoCollection()
        {

        }

        private List<NEGOCIO.Pedido> GenerarListado
            (List<DALC.PEDIDO> PedidoDALC)
        {
            List<NEGOCIO.Pedido> Pedido =
                new List<NEGOCIO.Pedido>();

            foreach (DALC.PEDIDO item in PedidoDALC)
            {
                NEGOCIO.Pedido PedTemp = new NEGOCIO.Pedido();
                PedTemp.NPedido = (int)item.N_PEDIDO;
                PedTemp.IdEmpleado = (int)item.ID_EMPLEADO;
                PedTemp.IdProveedor = item.ID_PROVEEDOR;
                PedTemp.FechaEmision = (DateTime)item.FECHA_EMISION;
                PedTemp.FechaEntrega = (DateTime)item.FECHA_ENTREGA;

                Pedido.Add(PedTemp);

            }

            return Pedido;
        }


        public List<NEGOCIO.Pedido> ReadAll()
        {
            var reconversions = CommonBC.Modelo.PEDIDO;
            return GenerarListado(reconversions.ToList());
        }

        public List<NEGOCIO.Pedido> ReadById(string rut)
        {
            var reconversions = CommonBC.Modelo.PEDIDO.Where(p => p.ID_PROVEEDOR == rut).OrderBy(p => p.N_PEDIDO);
            return GenerarListado(reconversions.ToList());
        }
    }
}
