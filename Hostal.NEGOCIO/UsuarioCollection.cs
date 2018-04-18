using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class UsuarioCollection
    {
        public UsuarioCollection()
        {

        }


        private List<NEGOCIO.Usuario> GenerarListado
            (List<DALC.USUARIO> UsuarioDALC)
        {
            List<NEGOCIO.Usuario> Usuarios =
                new List<NEGOCIO.Usuario>();

            foreach (DALC.USUARIO item in UsuarioDALC)
            {
                NEGOCIO.Usuario UserTemp = new NEGOCIO.Usuario();
                UserTemp.Id = (int)item.ID;
                UserTemp.Contrasena = item.CONTRASENA;
                UserTemp.User = item.USUARIO1;
                UserTemp.TipoUsuario = item.TIPO_USUARIO;


                Usuarios.Add(UserTemp);

            }

            return Usuarios;
        }

        public List<NEGOCIO.Usuario> ReadAll()
        {
            var reconversions = CommonBC.Modelo.USUARIO;
            return GenerarListado(reconversions.ToList());
        }
    }
}
