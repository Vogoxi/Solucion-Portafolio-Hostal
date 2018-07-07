using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class PlatoCollection
    {
        public PlatoCollection()
        {

        }

        private List<NEGOCIO.Plato> GenerarListado
            (List<DALC.PLATO> PlatoDALC)
        {
            List<NEGOCIO.Plato> Platos =
                new List<NEGOCIO.Plato>();

            foreach (DALC.PLATO item in PlatoDALC)
            {
                NEGOCIO.Plato PlaTemp = new NEGOCIO.Plato();
                PlaTemp.Id = (int)item.ID;
                PlaTemp.Nombre = item.NOMBRE;
                PlaTemp.IdServicio = (int)item.ID_SERVICIO;

                Platos.Add(PlaTemp);

            }

            return Platos;
        }

        public List<NEGOCIO.Plato> ReadAll()
        {
            var reconversions = CommonBC.Modelo.PLATO;
            return GenerarListado(reconversions.ToList());
        }
    }
}
