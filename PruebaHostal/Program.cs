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
            user.Contrasena = "123456";

            user.agregarUsuario(user);



        }
    }
}
