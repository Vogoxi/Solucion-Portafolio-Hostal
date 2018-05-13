using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class EmpleadoCollection
    {
        public EmpleadoCollection()
        {

        }


        private List<NEGOCIO.Empleado> GenerarListado
            (List<DALC.EMPLEADO> EmpleadoDALC)
        {
            List<NEGOCIO.Empleado> Empleados =
                new List<NEGOCIO.Empleado>();

            foreach (DALC.EMPLEADO item in EmpleadoDALC)
            {
                NEGOCIO.Empleado EmpTemp = new NEGOCIO.Empleado();
                EmpTemp.Id = (int)item.ID;
                EmpTemp.Nombre = item.NOMBRE;
                EmpTemp.Apellido = item.APELLIDO;
                EmpTemp.UsuarioId = (int)item.USUARIO_ID;

                Empleados.Add(EmpTemp);

            }

            return Empleados;
        }

        public List<NEGOCIO.Empleado> ReadAll()
        {
            var reconversions = CommonBC.Modelo.EMPLEADO;
            return GenerarListado(reconversions.ToList());
        }
    }
}
