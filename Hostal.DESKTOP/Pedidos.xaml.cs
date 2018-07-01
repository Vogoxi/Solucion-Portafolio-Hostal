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
    /// Interaction logic for Pedidos.xaml
    /// </summary>
    public partial class Pedidos : UserControl
    {
        public Pedidos()
        {
            InitializeComponent();
            CargarProveedores();
        }

        public class Producto
        {
            public string nombre { get; set; }
            public int cantidad { get; set; }
        }

        private void CargarProveedores()
        {
            NEGOCIO.ProveedorCollection CollectionProveedor = new NEGOCIO.ProveedorCollection();
            List<NEGOCIO.Proveedor> listaProveedores = new List<NEGOCIO.Proveedor>();
            NEGOCIO.Proveedor proveedor = new NEGOCIO.Proveedor();
            proveedor.Rut = "";
            proveedor.Nombre = "Seleccione Proveedor";
            listaProveedores.Add(proveedor);
            cmb_proveedores.Items.Add("Seleccione...");

            foreach (NEGOCIO.Proveedor item in CollectionProveedor.ReadAll())
            {
                proveedor = new NEGOCIO.Proveedor();
                proveedor.Rut = item.Rut;
                proveedor.Nombre = item.Nombre;

                cmb_proveedores.Items.Add(proveedor);
            }

            

            //ddlHuespedes.DataSource = listaHue;
            //ddlHuespedes.DataTextField = "NomApe";
            //ddlHuespedes.DataValueField = "Rut";
            //ddlHuespedes.DataBind();
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();
            producto.nombre = txt_producto.Text;
            int cantidad;
            if (int.TryParse(txt_cantidad.Text,out cantidad))
            {
                producto.cantidad = cantidad;
                dataGrid.Items.Add(producto);
                txt_producto.Text = String.Empty;
                txt_cantidad.Text = String.Empty;
            }
            else
            {
                lbl_error.Content = "La cantidad debe ser un numero";
                txt_cantidad.Text = String.Empty;
            }     
                 
        }
         
        
    }
}
