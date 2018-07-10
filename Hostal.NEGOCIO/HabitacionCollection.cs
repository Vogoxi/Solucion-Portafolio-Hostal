using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class HabitacionCollection : List<Habitacion>
    {
        public HabitacionCollection()
        {

        }

        private List<NEGOCIO.Habitacion> GenerarListado
            (List<DALC.HABITACION> HabitacionDALC)
        {
            List<NEGOCIO.Habitacion> Habitaciones =
                new List<NEGOCIO.Habitacion>();

            foreach (DALC.HABITACION item in HabitacionDALC)
            {
                NEGOCIO.Habitacion HabTemp = new Habitacion();
                HabTemp.Numero = (int)item.NUMERO;
                HabTemp.Precio = (int)item.PRECIO;
                HabTemp.Mantencion = (int)item.MANTENCION;
                HabTemp.TipoCama = item.TIPO_CAMA;
                HabTemp.Tipo = item.TIPO;

                Habitaciones.Add(HabTemp);

            }

            return Habitaciones;
        }

        public List<NEGOCIO.Habitacion> ReadAll()
        {
            try
            {
                var reconversions = CommonBC.Modelo.HABITACION;
                return GenerarListado(reconversions.ToList());
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                if(ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
            
        }

        public List<string> ReadAllTipos()
        {
            var reconversions = CommonBC.Modelo.HABITACION.Distinct().GroupBy(r => r.TIPO).ToList();

            List<string> tipos = new List<string>();

            foreach (var item in reconversions)
            {
                tipos.Add(item.Key);
            }

            return tipos;
        }

        public int DevulvePrecio(string tipo)
        {
            var query = CommonBC.Modelo.HABITACION.First(r => r.TIPO == tipo);

            return (int)query.PRECIO;
        }


        public List<Habitacion> HabitacionesDisponibles(DateTime ingreso, DateTime salida, List<Reserva> Reserva)
        {
            List<long> idHab = new List<long>();

            foreach (var item in Reserva)
            {
                idHab.Add(item.Numero);
            }

            var Habitaciones = CommonBC.Modelo.HABITACION.Where(r =>  !idHab.Contains(r.NUMERO)).ToList();

            List<Habitacion> Allhabitaciones = new List<Habitacion>();

            foreach (var item in Habitaciones)
            {
                var detalles = CommonBC.Modelo.DETALLE_FACTURA.Where(r =>  r.HABITACION_ID == item.NUMERO && ((r.FECHA_INGRESO > ingreso && r.FECHA_INGRESO > salida) || (r.FECHA_SALIDA < ingreso && r.FECHA_SALIDA < salida))).ToList();

                var detallescount = CommonBC.Modelo.DETALLE_FACTURA.Where(r => r.HABITACION_ID == item.NUMERO).ToList();

                if (detalles.Count() == detallescount.Count())
                {
                    Habitacion hab = new Habitacion();

                    hab.Numero = (int)item.NUMERO;
                    hab.Precio = (int)item.PRECIO;
                    hab.Mantencion = (int)item.MANTENCION;
                    hab.Tipo = item.TIPO;
                    hab.TipoCama = item.TIPO_CAMA;

                    Allhabitaciones.Add(hab);
                }
                
            }

            return Allhabitaciones;
        }


    }
}
