using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class EmpresaCollection
    {
        public EmpresaCollection()
        {

        }


        private List<NEGOCIO.Empresa> GenerarListado
            (List<DALC.EMPRESA> EmpresaDALC)
        {
            List<NEGOCIO.Empresa> Empresas =
                new List<NEGOCIO.Empresa>();

            foreach (DALC.EMPRESA item in EmpresaDALC)
            {
                NEGOCIO.Empresa EmpTemp = new NEGOCIO.Empresa();
                EmpTemp.Rut = item.RUT;
                EmpTemp.RazonSocial = item.RAZON_SOCIAL;
                EmpTemp.Giro = item.GIRO;
                EmpTemp.Direccion = item.DIRECCION;
                EmpTemp.Telefono = item.TELEFONO;
                EmpTemp.UsuarioId = (int)item.USUARIO_ID;

                Empresas.Add(EmpTemp);

            }

            return Empresas;
        }

        public List<NEGOCIO.Empresa> ReadAll()
        {
            var reconversions = CommonBC.Modelo.EMPRESA;
            return GenerarListado(reconversions.ToList());
        }
    }
}
