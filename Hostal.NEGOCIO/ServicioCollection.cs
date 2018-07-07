using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class ServicioCollection : List<Servicio>
    {
        public ServicioCollection()
        {

        }


        private List<NEGOCIO.Servicio> GenerarListado
            (List<DALC.SERVICIO> ServicioDALC)
        {
            List<NEGOCIO.Servicio> Servicios =
                new List<NEGOCIO.Servicio>();

            foreach (DALC.SERVICIO item in ServicioDALC)
            {
                NEGOCIO.Servicio SerTemp = new NEGOCIO.Servicio();
                SerTemp.Id = (int)item.ID;
                SerTemp.Nombre = item.NOMBRE;
                SerTemp.Precio = (int)item.PRECIO;

                Servicios.Add(SerTemp);

            }

            return Servicios;
        }

        public List<NEGOCIO.Servicio> ReadAll()
        {
            var reconversions = CommonBC.Modelo.SERVICIO;
            return GenerarListado(reconversions.ToList());
        }
    }
}
