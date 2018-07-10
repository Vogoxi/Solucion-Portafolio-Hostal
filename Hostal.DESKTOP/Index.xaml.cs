using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Hostal.DESKTOP
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window
    {
        
        public Index(NEGOCIO.Usuario user)
        {
            User.Id = user.Id;
            InitializeComponent();
            CargarPerfil(user);
        }

        private void CargarPerfil(NEGOCIO.Usuario user)
        {
            txt_usuario.Text = String.Format("Bienvenido: {0}", user.User.ToUpper());
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemPedidos":
                    usc = new VentanaPedidos();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemFacturas":
                    usc = new Facturas();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemRegistros":
                    usc = new Registros();
                    GridMain.Children.Add(usc);
                    break;
                    //default:
                    //    break;
            }
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_cerrar_sesion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow login = new MainWindow();
            login.Show();
        }
    }
}
