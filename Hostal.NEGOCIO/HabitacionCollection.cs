using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class HabitacionCollection
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
                HabTemp.Camas = (int)item.CAMAS;
                HabTemp.Tipo = item.TIPO;

                Habitaciones.Add(HabTemp);

            }

            return Habitaciones;
        }

        public List<NEGOCIO.Habitacion> ReadAll()
        {
            var reconversions = CommonBC.Modelo.HABITACION;
            return GenerarListado(reconversions.ToList());
        }
    }
}
