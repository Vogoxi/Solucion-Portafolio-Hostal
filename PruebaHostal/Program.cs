using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostal.NEGOCIO;

namespace PruebaHostal
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario user = new Usuario();

            user.User = "german";
            user.TipoUsuario = "E";
            user.Contrasena = "germ.123";

            if (!user.agregarUsuario(user.User))
            {
                Console.Write("usuario ya existe");
            }else
            {
                Console.Write("usuario agregado");
            }



        }
    }
}
