using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostal.NEGOCIO;
using System.IO;

namespace PruebaHostal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usuario user = new Usuario();

            //user.User = "german";
            //user.TipoUsuario = "E";
            //user.Contrasena = "germ.123";

            //if (!user.agregarUsuario(user.User))
            //{
            //    Console.Write("usuario ya existe");
            //}else
            //{
            //    Console.Write("usuario agregado");
            //}

            //user = new Usuario();

            //user.Id = 3;
            //user.User = "germanx";
            //user.TipoUsuario = "E";
            //user.Contrasena = "1234";

            //user.actualizarUsuario();

            //Console.WriteLine("actualizado");

            //user = new Usuario();

            //user.Id = 3;
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
            
            //Usuario user = new Usuario();
            //user.Id = 5;

            //Empresa empresa = new Empresa();
            //empresa = empresa.getEmpresaByUserId(user);

            HuespedCollection huespedes = new HuespedCollection();
            List<Huesped> lista = new List<Huesped>();
            lista = huespedes.ReadAll();
            
            Console.ReadKey();
            

            HabitacionCollection hab = new HabitacionCollection();
            DateTime ingreso = Convert.ToDateTime("01/06/2018");
            DateTime salida = Convert.ToDateTime("15/06/2018");

            var hola = hab.HabitacionesDisponibles(ingreso, salida,);

            var resultado = hola;
            */

            Cupon cupon = new Cupon();

            Empresa empresa = new Empresa();
            empresa.Rut = "77987654-1";
            empresa = empresa.getEmpresa();

            Factura factura = new Factura();
            factura.Id = 1;
            factura = factura.GetFactura();

            DetalleFacturaCollection detFact = new DetalleFacturaCollection();

            

            cupon.Empresa = empresa;
            cupon.Factura = factura;
            cupon.ListaDet = detFact.ReadByIdFactura(factura.Id);

            var bytes = cupon.GenerarCupon();

            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");

            System.IO.File.WriteAllBytes(testFile, bytes);


        }
    }
}
