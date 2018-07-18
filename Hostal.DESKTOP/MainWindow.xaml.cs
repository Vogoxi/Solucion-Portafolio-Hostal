using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Hostal.DESKTOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NEGOCIO.Usuario usuario = new NEGOCIO.Usuario();
            usuario.Id = usuario.validarUsuario(txt_user.Text.Trim(), txt_pass.Password.Trim());
            if (usuario.Id != 0)
            {
                usuario = usuario.getUsuario();
                if (usuario.TipoUsuario == "admin" || usuario.TipoUsuario == "empleado")
                {
                    this.Hide();
                    Index index = new Index(usuario);
                    index.Show();

                }
                else
                {
                    lbl_status.Content = "Acceso Denegado"; 
                }
            }else
            {
                lbl_status.Content = "Usuario o contraseña incorrectos";
            }
        }

        private void btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            //Process.Start("http://www.yourwebaddress.com");
            //Application.Current.Shutdown();
        }
    }
}
