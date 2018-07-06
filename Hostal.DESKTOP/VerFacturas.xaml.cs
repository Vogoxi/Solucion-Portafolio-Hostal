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
            facturas.OrderBy(f => f.Id);
            dta_Facturas.ItemsSource = facturas;

            dta_Detalle.CanUserAddRows = false;
            dta_Facturas.CanUserAddRows = false;

            //dta_Facturas.Columns[0].Header = "N° Factura";
            //dta_Facturas.Columns[1].Header = "Empresa";
            //dta_Facturas.Columns[1].Header = "Empresa";
        }

        private void dta_Facturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NEGOCIO.Factura factura = dta_Facturas.SelectedItem as NEGOCIO.Factura;

            List<NEGOCIO.DetalleFactura> detalles = new List<NEGOCIO.DetalleFactura>();
            List<NEGOCIO.DetalleFactura> detallesGrid = new List<NEGOCIO.DetalleFactura>();
            NEGOCIO.DetalleFacturaCollection colection = new NEGOCIO.DetalleFacturaCollection();

            detalles = colection.ReadById(factura.Id);
            detalles.OrderBy(d => d.Id);

            dta_Detalle.ItemsSource = detalles;
        }
    }
}
