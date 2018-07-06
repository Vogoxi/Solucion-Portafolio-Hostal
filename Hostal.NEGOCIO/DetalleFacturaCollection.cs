using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class DetalleFacturaCollection
    {
        public DetalleFacturaCollection()
        {

        }


        private List<NEGOCIO.DetalleFactura> GenerarListado
            (List<DALC.DETALLE_FACTURA> DetalleFacturaDALC)
        {
            List<NEGOCIO.DetalleFactura> Detalles =
                new List<NEGOCIO.DetalleFactura>();

            foreach (DALC.DETALLE_FACTURA item in DetalleFacturaDALC)
            {
                NEGOCIO.DetalleFactura DetTemp = new NEGOCIO.DetalleFactura();
                DetTemp.Id = (int)item.ID;
                DetTemp.IdFactura = (int)item.FACTURA_ID;
                DetTemp.IdHabitacion = (int)item.HABITACION_ID;
                DetTemp.IdHuesped = item.HUESPED_ID;
                DetTemp.FechaIngreso = (DateTime)item.FECHA_INGRESO;
                DetTemp.FechaSalida = (DateTime)item.FECHA_SALIDA;
                DetTemp.IdServicio = (int)item.SERVICIO_ID;

                Detalles.Add(DetTemp);

            }

            return Detalles;
        }

        private List<NEGOCIO.DetalleFactura> GenerarListado
            (List<DALC.DETALLE_FACTURA> DetalleFacturaDALC,int id)
        {
            List<NEGOCIO.DetalleFactura> Detalles =
                new List<NEGOCIO.DetalleFactura>();

            foreach (DALC.DETALLE_FACTURA item in DetalleFacturaDALC)
            {
                NEGOCIO.DetalleFactura DetTemp = new NEGOCIO.DetalleFactura();
                DetTemp.Id = (int)item.ID;
                DetTemp.IdFactura = (int)item.FACTURA_ID;
                DetTemp.IdHabitacion = (int)item.HABITACION_ID;
                DetTemp.IdHuesped = item.HUESPED_ID;
                DetTemp.FechaIngreso = (DateTime)item.FECHA_INGRESO;
                DetTemp.FechaSalida = (DateTime)item.FECHA_SALIDA;
                DetTemp.IdServicio = (int)item.SERVICIO_ID;

                if (id == DetTemp.IdFactura)
                {
                    Detalles.Add(DetTemp);
                }
               
            }

            return Detalles;
        }

        public List<NEGOCIO.DetalleFactura> ReadAll()
        {
            var reconversions = CommonBC.Modelo.DETALLE_FACTURA;
            return GenerarListado(reconversions.ToList());
        }

        public List<NEGOCIO.DetalleFactura> ReadById(int id)
        {
            var reconversions = CommonBC.Modelo.DETALLE_FACTURA;
            return GenerarListado(reconversions.ToList(),id);
        }



    }
}
