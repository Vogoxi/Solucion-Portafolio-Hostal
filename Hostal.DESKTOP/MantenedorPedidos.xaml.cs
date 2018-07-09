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
    /// Interaction logic for MantenedorPedidos.xaml
    /// </summary>
    public partial class MantenedorPedidos : UserControl
    {
        public MantenedorPedidos()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void CargarGrid()
        {
            List<NEGOCIO.Pedido> pedidos = new List<NEGOCIO.Pedido>();
            NEGOCIO.PedidoCollection collection = new NEGOCIO.PedidoCollection();
            pedidos = collection.ReadAll();
            dta_Pedidos.ItemsSource = pedidos;

            dta_Detalle.CanUserAddRows = false;
            dta_Pedidos.CanUserAddRows = false;
            EstadoBotones(false);
        }

        private void EstadoBotones(bool estado)
        {
            if (estado)
            {
                btn_agregar.IsEnabled = true;
                btn_anular.IsEnabled = true;
                btn_eliminar.IsEnabled = true;
                btn_modificar.IsEnabled = true;
            }
            else
            {
                btn_agregar.IsEnabled = false;
                btn_anular.IsEnabled = false;
                btn_eliminar.IsEnabled = false;
                btn_modificar.IsEnabled = false;
            }           
        }

        private void dta_Pedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dta_Pedidos.SelectedIndex != -1)
            {
                LimpiarTxt();
                NEGOCIO.Pedido pedido = dta_Pedidos.SelectedItem as NEGOCIO.Pedido;
                CargarDetallePedido(pedido.NPedido);

                if (pedido.FechaEstadoEntrega == "Sin Procesar")
                {
                    EstadoBotones(true);
                }
                else
                {
                    EstadoBotones(false);
                }

            }
        }

        private void CargarDetallePedido(int id)
        {      
            List<NEGOCIO.DetallePedido> detalles = new List<NEGOCIO.DetallePedido>();
            NEGOCIO.DetallePedidoCollection colection = new NEGOCIO.DetallePedidoCollection();

            detalles = colection.ReadById(id);
            detalles.OrderBy(d => d.Id);

            dta_Detalle.ItemsSource = detalles;
        }

        private void LimpiarTxt()
        {
            txt_producto.Text = String.Empty;
            txt_cantidad.Text = String.Empty;
        }

        private void dta_Detalle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dta_Pedidos.SelectedIndex != -1)
            {
                NEGOCIO.DetallePedido detalle = dta_Detalle.SelectedItem as NEGOCIO.DetallePedido;

                if (detalle != null)
                {
                    txt_producto.Text = detalle.Producto;
                    txt_cantidad.Text = detalle.Cantidad.ToString();
                }               
            }
        }

        private void btn_anular_Click(object sender, RoutedEventArgs e)
        {
            NEGOCIO.Pedido pedido = dta_Pedidos.SelectedItem as NEGOCIO.Pedido;
            MessageBoxResult resultado = MessageBox.Show(String.Format("¿Esta seguro que desea eliminar el pedido N°{0}? \rEsta acción no se puede deshacer.", pedido.NPedido), "Anulación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (resultado)
            {
                case MessageBoxResult.Yes:
                    List<NEGOCIO.DetallePedido> detalles = (List<NEGOCIO.DetallePedido>)dta_Detalle.Items.SourceCollection;
                    foreach (NEGOCIO.DetallePedido detalle in detalles)
                    {
                        detalle.BorrarDetallePedido();
                    }
                    pedido.BorrarPedido();
                    MessageBox.Show("Pedido Anulado", "Anulación", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarGrid();
                    break;
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dta_Detalle.SelectedIndex != -1)
            {
                NEGOCIO.DetallePedido detallePedido = dta_Detalle.SelectedItem as NEGOCIO.DetallePedido;
                NEGOCIO.Pedido pedido = dta_Pedidos.SelectedItem as NEGOCIO.Pedido;
                detallePedido.BorrarDetallePedido();
                LimpiarTxt();
                CargarDetallePedido(pedido.NPedido);
            }else
            {
                MessageBox.Show("Seleccione un producto", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }         
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {            
            if (txt_producto.Text != String.Empty && txt_producto.Text != String.Empty)
            {
                int cantidad;
                if (int.TryParse(txt_cantidad.Text, out cantidad))
                {
                    NEGOCIO.Pedido pedido = dta_Pedidos.SelectedItem as NEGOCIO.Pedido;
                    NEGOCIO.DetallePedido detallePedido = new NEGOCIO.DetallePedido();
                    detallePedido.Producto = txt_producto.Text;
                    detallePedido.Cantidad = cantidad;
                    detallePedido.Idpedido = pedido.NPedido;
                    detallePedido.AgregarDetalle();
                    CargarDetallePedido(pedido.NPedido);
                    LimpiarTxt();
                }
                else
                {
                    MessageBox.Show("Cantidad debe ser un numero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimpiarTxt();
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }             
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            if (dta_Detalle.SelectedIndex != -1)
            {
                if (txt_producto.Text != String.Empty && txt_producto.Text != String.Empty)
                {
                    int cantidad;
                    if (int.TryParse(txt_cantidad.Text, out cantidad))
                    {
                        NEGOCIO.DetallePedido detallePedido = dta_Detalle.SelectedItem as NEGOCIO.DetallePedido;
                        detallePedido.Producto = txt_producto.Text;
                        detallePedido.Cantidad = cantidad;
                        detallePedido.ActualizarDetallePedido();
                        CargarDetallePedido(detallePedido.Idpedido);
                        LimpiarTxt();
                    }
                    else
                    {
                        MessageBox.Show("Cantidad debe ser un numero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        LimpiarTxt();
                    }
                }
            }else
            {
                MessageBox.Show("Seleccione un producto", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }
    }
}
