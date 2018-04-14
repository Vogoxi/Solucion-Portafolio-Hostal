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

            user.User = "asd";
            user.TipoUsuario = "X";
            user.Contrasena = "22222222";

            user.agregarUsuario();



        }
    }
}
