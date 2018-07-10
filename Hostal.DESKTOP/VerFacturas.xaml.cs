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
    /// Interaction logic for VerFacturas.xaml
    /// </summary>
    public partial class VerFacturas : UserControl
    {
        public VerFacturas()
        {
            InitializeComponent();
            CargarGrid();
        }

        public class FacturaAux
        {
            string NombreEmpresa { get; set; } 
        }

        private void CargarGrid()
        {
            List<NEGOCIO.Factura> facturas = new List<NEGOCIO.Factura>();
            NEGOCIO.FacturaCollection colection = new NEGOCIO.FacturaCollection();
            facturas = colection.ReadAll();
            dta_Facturas.ItemsSource = facturas;

            dta_Detalle.CanUserAddRows = false;
            dta_Facturas.CanUserAddRows = false;
        }

        private void dta_Facturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dta_Facturas.SelectedIndex != -1)
            {
                btn_anular.IsEnabled = true;
                NEGOCIO.Factura factura = dta_Facturas.SelectedItem as NEGOCIO.Factura;

                List<NEGOCIO.DetalleFactura> detalles = new List<NEGOCIO.DetalleFactura>();
                NEGOCIO.DetalleFacturaCollection colection = new NEGOCIO.DetalleFacturaCollection();

                detalles = colection.ReadById(factura.Id);
                detalles.OrderBy(d => d.Id);

                dta_Detalle.ItemsSource = detalles;
            }           
        }

        private void btn_anular_Click(object sender, RoutedEventArgs e)
        {
            NEGOCIO.Factura factura = dta_Facturas.SelectedItem as NEGOCIO.Factura;
            MessageBoxResult resultado = MessageBox.Show(String.Format("¿Esta seguro que desea eliminar la factura N°{0}? \rEsta acción no se puede deshacer.",factura.Id), "Anulación", MessageBoxButton.YesNo,MessageBoxImage.Warning);
            switch (resultado)
            {
                case MessageBoxResult.Yes:       
                    factura.BorrarFactura();
                    MessageBox.Show("Factura Anulada", "Anulación",MessageBoxButton.OK,MessageBoxImage.Information);
                    dta_Detalle.ItemsSource = null;
                    dta_Detalle.Items.Refresh();
                    CargarGrid();
                    break;
            }
        }
    }
}
