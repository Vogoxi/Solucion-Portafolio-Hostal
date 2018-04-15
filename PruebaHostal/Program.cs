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

            user.User = "germanPrueba2";
            user.TipoUsuario = "E";
            user.Contrasena = "germ.123";

            if (!user.agregarUsuario(user.User))
            {
                Console.Write("usuario ya existe");
            }else
            {
                Console.Write("usuario agregado");
            }
            
            /*
            Usuario user = new Usuario();

            Console.WriteLine("Ingrese Usuario");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            string password = Console.ReadLine();


            if(user.validarUsuario(nombre, password))
            {
                Console.WriteLine("Logeado");
            }else
            {
                Console.WriteLine("Usuario o contraseña incorrectos");
            }
            Console.ReadKey();
            */



        }
    }
}
