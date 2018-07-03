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
    /// Interaction logic for Factura.xaml
    /// </summary>
    public partial class Facturas : UserControl
    {
        public Facturas()
        {
            InitializeComponent();
        }

        

        private void btn_verFacturas_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new VerFacturas();
            GridMain.Children.Add(usc);

        }
    }
}
