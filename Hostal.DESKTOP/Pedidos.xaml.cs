﻿using System;
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
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
        }

        private void CargarProveedores()
        {
            NEGOCIO.ProveedorCollection CollectionProveedor = new NEGOCIO.ProveedorCollection();
            List<NEGOCIO.Proveedor> listaProveedores = new List<NEGOCIO.Proveedor>();
            NEGOCIO.Proveedor proveedor = new NEGOCIO.Proveedor();
            listaProveedores.Add(proveedor);

            foreach (NEGOCIO.Proveedor item in CollectionProveedor.ReadAll())
            {
                proveedor = new NEGOCIO.Proveedor();
                proveedor.Rut = item.Rut;
                proveedor.Nombre = item.Nombre;

                cmb_proveedores.Items.Add(proveedor);
            }

            btn_hacer_pedido.IsEnabled = false;
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_cantidad.Text != String.Empty || txt_producto.Text != String.Empty)
            {
                Producto producto = new Producto();
                producto.Nombre = txt_producto.Text;
                int cantidad;
                if (int.TryParse(txt_cantidad.Text, out cantidad))
                {
                    producto.Cantidad = cantidad;
                    dataGrid.Items.Add(producto);
                    txt_producto.Text = String.Empty;
                    txt_cantidad.Text = String.Empty;
                    btn_hacer_pedido.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("La cantidad debe ser un numero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }else
            {
                MessageBox.Show("Falta por ingresar datos del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }

        private void btn_hacer_pedido_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult resultado = MessageBox.Show(String.Format("¿Esta seguro que desea generar el pedido?"), "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (resultado)
            {
                case MessageBoxResult.Yes:
                    NEGOCIO.Pedido pedido = new NEGOCIO.Pedido();
                    NEGOCIO.Proveedor proveedor = (NEGOCIO.Proveedor)cmb_proveedores.SelectedItem;
                    pedido.FechaEntrega = DateTime.MinValue;
                    pedido.IdProveedor = proveedor.Rut;
                    pedido.IdEmpleado = User.Id;
                    if (pedido.AgregarPedido())
                    {
                        foreach (Producto producto in dataGrid.Items)
                        {
                            NEGOCIO.DetallePedido detalle = new NEGOCIO.DetallePedido();
                            detalle.Producto = producto.Nombre.ToLower();
                            detalle.Cantidad = producto.Cantidad;
                            detalle.Idpedido = pedido.NPedido;
                            detalle.AgregarDetalle();
                        }
                        MessageBox.Show("Su pedido a sido ingresado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dataGrid.Items.Clear();
                    }
                    break;
            }                 
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                dataGrid.Items.RemoveAt(dataGrid.SelectedIndex);
                dataGrid.Items.Refresh();
                if (dataGrid.Items.Count == 0)
                {
                    btn_hacer_pedido.IsEnabled = false;
                }
            }
        }
    }
}
