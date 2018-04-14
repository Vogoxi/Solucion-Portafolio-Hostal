using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostal.DALC;

namespace Hostal.NEGOCIO
{
    class CommonBC
    {
        private static Hostal.DALC.Entities _modelo;

        public static Hostal.DALC.Entities Modelo
        {
            get
            {
                if(_modelo == null)
                {
                    _modelo = new Hostal.DALC.Entities();
                }
                return _modelo;
            }
        }

        public CommonBC() { }
    } 
}
