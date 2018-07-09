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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hostal.DESKTOP
{
    /// <summary>
    /// Interaction logic for VentanaPedidos.xaml
    /// </summary>
    public partial class VentanaPedidos : UserControl
    {
        public VentanaPedidos()
        {
            InitializeComponent();
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new Pedidos();
            GridMain.Children.Add(usc);
        }

        private void btn_estado_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new MantenedorPedidos();
            GridMain.Children.Add(usc);
        }
    }
}
