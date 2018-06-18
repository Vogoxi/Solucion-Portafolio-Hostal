using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class HuespedCollection
    {
        public HuespedCollection()
        {

        }


        private List<NEGOCIO.Huesped> GenerarListado
            (List<DALC.HUESPED> HuespedDALC, string rutEmpresa)
        {
            List<NEGOCIO.Huesped> Huespedes =
                new List<NEGOCIO.Huesped>();

            foreach (DALC.HUESPED item in HuespedDALC)
            {
                if (item.EMPRESA_RUT == rutEmpresa)
                {
                    NEGOCIO.Huesped HuesTemp = new NEGOCIO.Huesped();
                    HuesTemp.Rut = item.RUT;
                    HuesTemp.Nombre = item.NOMBRE;
                    HuesTemp.Apellido = item.APELLIDO;
                    HuesTemp.Telefono = item.TELEFONO;
                    HuesTemp.EmpresaRut = item.EMPRESA_RUT;
                    Huespedes.Add(HuesTemp);
                }
            }

            return Huespedes;
        }

        public List<NEGOCIO.Huesped> ReadAll(string rut)
        {
            var reconversions = CommonBC.Modelo.HUESPED;
            return GenerarListado(reconversions.ToList(), rut);
        }

        public List<NEGOCIO.Huesped> ReadAllRes(string rut,List<Reserva> reserva)
        {
            if (reserva.Count != 0)
            {
                List<string> listRut = new List<string>();
                foreach (var item in reserva)
                {
                    listRut.Add(item.Rut);
                }
                var reconversions = CommonBC.Modelo.HUESPED.Where(r => !listRut.Contains(r.RUT)).ToList();
                return GenerarListado(reconversions.ToList(), rut);
            }else
            {
                var reconversions = CommonBC.Modelo.HUESPED;
                return GenerarListado(reconversions.ToList(), rut);
            }
           
        }

    }
}
