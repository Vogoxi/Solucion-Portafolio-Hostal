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

            /*      agregar usuario
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
            */

            /*       validar usuario
            Usuario user = new Usuario();

            Console.WriteLine("Ingrese Usuario");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            string password = Console.ReadLine();


            if(user.validarUsuario(nombre, password)>0)
            {
                Console.WriteLine("Logeado");
            }else
            {
                Console.WriteLine("Usuario o contraseña incorrectos");
            }
            Console.ReadKey();
            */

            Usuario user = new Usuario();
            Console.WriteLine("Ingrese usuario al que desea cambiar contraseña");
            int valorId = user.getUsuarioIdByName(Console.ReadLine());
            if (valorId != 0)
            {
                user.Id = valorId;
                user = user.getUsuario();
                Console.WriteLine("Ingrese nueva contraseña");
                user.Contrasena = Console.ReadLine();
                if (user.actualizarUsuario())
                {
                    string mensaje = "Contraseña del usuario " + user.User + " ha sido modificada exitosamente";
                    Console.WriteLine(mensaje);
                }else
                {
                    Console.WriteLine("Ha ocurrido un error al intentar cambiar la contraseña");
                }
            }else
            {
                Console.WriteLine("usuario no existe");
            }
            Console.ReadKey();
            



        }
    }
}
