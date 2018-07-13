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


        public int BuscarReporte(int mes, int year, int tipo)
        {
            int yearE = 0;

            switch (tipo)
            {
                case 1:
                    //Rechazado
                    yearE = 9999;
                    break;
                case 2:
                    //Sin Procesar
                    yearE = 2001;
                    break;
                case 3:
                    //Aprobados
                var Pedido2 = CommonBC.Modelo.PEDIDO.Where(r => r.FECHA_EMISION.Value.Month == mes &&
                                                           r.FECHA_EMISION.Value.Year == year && r.FECHA_ENTREGA > r.FECHA_EMISION 
                                                           && r.FECHA_ENTREGA.Value.Year != 9999).ToList();
                    return Pedido2.Count();
                    break;
                default:
                    break;
            }


            var Pedido = CommonBC.Modelo.PEDIDO.Where(r => r.FECHA_EMISION.Value.Month == mes &&
                                                      r.FECHA_EMISION.Value.Year == year && r.FECHA_ENTREGA.Value.Year == yearE).ToList();

            return Pedido.Count();
        }

        public int BuscarReporteTotal(int mes, int year)
        {
            var Pedido = CommonBC.Modelo.PEDIDO.Where(r => r.FECHA_EMISION.Value.Month == mes && r.FECHA_EMISION.Value.Year == year).ToList();

            return Pedido.Count();
        }
    }
}
