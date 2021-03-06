﻿using System;
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
            (List<DALC.HUESPED> HuespedDALC)
        {
            List<NEGOCIO.Huesped> Huespedes =
                new List<NEGOCIO.Huesped>();

            foreach (DALC.HUESPED item in HuespedDALC)
            {
                NEGOCIO.Huesped HuesTemp = new NEGOCIO.Huesped();
                HuesTemp.Rut = item.RUT;
                HuesTemp.Nombre = item.NOMBRE;
                HuesTemp.Apellido = item.APELLIDO;
                HuesTemp.Telefono = item.TELEFONO;
                HuesTemp.EmpresaRut = item.EMPRESA_RUT;

                Huespedes.Add(HuesTemp);

            }

            return Huespedes;
        }

        public List<NEGOCIO.Huesped> ReadAll()
        {
            var reconversions = CommonBC.Modelo.HUESPED;
            return GenerarListado(reconversions.ToList());
        }
    }
}
