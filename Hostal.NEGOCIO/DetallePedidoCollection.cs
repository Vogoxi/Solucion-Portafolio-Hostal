using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class DetallePedidoCollection
    {
        public DetallePedidoCollection()
        {

        }

        private List<NEGOCIO.DetallePedido> GenerarListado
            (List<DALC.DETALLE_PEDIDO> DetallePedidoDALC)
        {
            List<NEGOCIO.DetallePedido> DetallePedido =
                new List<NEGOCIO.DetallePedido>();

            foreach (DALC.DETALLE_PEDIDO item in DetallePedidoDALC)
            {
                NEGOCIO.DetallePedido PedTemp = new NEGOCIO.DetallePedido();
                PedTemp.Id = (int)item.ID;
                PedTemp.Idpedido = (int)item.ID_PEDIDO;
                PedTemp.Cantidad = (int)item.CANTIDAD;
                PedTemp.Producto = item.PRODUCTO;

                DetallePedido.Add(PedTemp);

            }

            return DetallePedido;
        }

        public List<NEGOCIO.DetallePedido> ReadAll()
        {
            var reconversions = CommonBC.Modelo.DETALLE_PEDIDO;
            return GenerarListado(reconversions.ToList());
        }
    }
}
