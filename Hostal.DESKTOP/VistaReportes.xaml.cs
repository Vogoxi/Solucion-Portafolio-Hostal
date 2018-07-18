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
    /// Interaction logic for VistaReportes.xaml
    /// </summary>
    public partial class VistaReportes : UserControl
    {
        public VistaReportes()
        {
            InitializeComponent();
            CargarCombo();
        }

        private void CargarCombo()
        {
            CheckStatus(0);
            cmb_area.Items.Add("Pedidos");
            cmb_area.Items.Add("Facturas");
            cmb_anio.Items.Add("2018");
            cmb_mes.IsEnabled = false;
            cmb_anio.IsEnabled = false;
            for (int i = 1; i <= 12; i++)
            {
                cmb_mes.Items.Add(i);
            }

            CargarProveedores();
        }

        private void CargarProveedores()
        {
            NEGOCIO.ProveedorCollection CollectionProveedor = new NEGOCIO.ProveedorCollection();
            List<NEGOCIO.Proveedor> listaProveedores = new List<NEGOCIO.Proveedor>();
            NEGOCIO.Proveedor proveedor = new NEGOCIO.Proveedor();
            listaProveedores.Add(proveedor);

            cmb_proveedor.Items.Add("Todos");

            foreach (NEGOCIO.Proveedor item in CollectionProveedor.ReadAll())
            {
                proveedor = new NEGOCIO.Proveedor();
                proveedor.Rut = item.Rut;
                proveedor.Nombre = item.Nombre;

                cmb_proveedor.Items.Add(proveedor);
            }

            cmb_proveedor.Visibility = Visibility.Hidden;
            lbl_prov.Visibility = Visibility.Hidden;
        }

        private void CheckStatus(int estado)
        {
            if (estado == 0)
            {
                chk_aprobados.Visibility = Visibility.Hidden;
                chk_rechazados.Visibility = Visibility.Hidden;
                chk_sinProcesar.Visibility = Visibility.Hidden;
                chk_total.Visibility = Visibility.Hidden;
            }else
            {
                chk_aprobados.Visibility = Visibility.Visible;
                chk_rechazados.Visibility = Visibility.Visible;
                chk_sinProcesar.Visibility = Visibility.Visible;
                chk_total.Visibility = Visibility.Visible;
            }
            
        }

        private void cmb_area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_area.SelectedIndex != -1)
            {
                cmb_mes.IsEnabled = true;
                cmb_anio.IsEnabled = true;
                CheckStatus(0);
                if (cmb_area.SelectedItem.ToString() == "Pedidos")
                {
                    CheckStatus(1);
                    cmb_proveedor.Visibility = Visibility.Visible;
                    lbl_prov.Visibility = Visibility.Visible;
                }

                if (cmb_area.SelectedItem.ToString() == "Facturas")
                {
                    CheckStatus(0);
                    cmb_proveedor.Visibility = Visibility.Hidden;
                    lbl_prov.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btn_generar_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_area.SelectedIndex != -1 && cmb_anio.SelectedIndex != -1 && cmb_mes.SelectedIndex != -1)
            {
                int[] datos = new int[4];
                
                if (chk_rechazados.IsChecked.Value)
                {
                    datos[1] = 1;
                }
                if (chk_sinProcesar.IsChecked.Value)
                {
                    datos[2] = 2;
                }
                if (chk_aprobados.IsChecked.Value)
                {
                    datos[0] = 3;
                }
                if (chk_total.IsChecked.Value)
                {
                    datos[3] = 4;
                }

                NEGOCIO.Reportes reporte = new NEGOCIO.Reportes();

                DateTime fecha = new DateTime(int.Parse(cmb_anio.SelectedItem.ToString()),int.Parse(cmb_mes.SelectedItem.ToString()),1);

                string tipoReporte = String.Empty;

                try
                {
                    byte[] bytes = new byte[0];

                    if (cmb_area.SelectedItem.ToString() == "Pedidos")
                    {
                        tipoReporte = "Pedidos";
                        if (cmb_proveedor.SelectedItem.ToString() == "Todos")
                        {
                            bytes = reporte.ReportePedidos(fecha, datos);
                        }else
                        {
                            
                            NEGOCIO.Proveedor proveedor = (NEGOCIO.Proveedor)cmb_proveedor.SelectedItem;
                            bytes = reporte.ReportePedidosProveedor(fecha, datos, proveedor);
                            tipoReporte += NEGOCIO.Auxiliar.UppercaseWords(proveedor.Nombre);
                        }
                        
                    }

                    if (cmb_area.SelectedItem.ToString() == "Facturas")
                    {
                        tipoReporte = "Facturas";
                        bytes = reporte.ReporteArriendos(fecha);
                    }



                    Random numero = new Random(100);

                    var testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), String.Format("{0}{5}-{1}_{2}_{3}_{4}.pdf", "Reporte", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond,tipoReporte));

                    System.IO.File.WriteAllBytes(testFile, bytes);

                    MessageBox.Show("Se ha generado el reporte en el escritorio", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(String.Format("Error: {0}",ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Faltan datos por ingresar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
