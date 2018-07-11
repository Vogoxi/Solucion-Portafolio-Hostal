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
    /// Interaction logic for MantenedorProveedores.xaml
    /// </summary>
    public partial class MantenedorProveedores : UserControl
    {
        public MantenedorProveedores()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void CargarGrid()
        {
            List<NEGOCIO.Proveedor> proveedor = new List<NEGOCIO.Proveedor>();
            NEGOCIO.ProveedorCollection collection = new NEGOCIO.ProveedorCollection();
            proveedor = collection.ReadAll();
            dta_Proveedores.ItemsSource = proveedor;

            dta_Proveedores.CanUserAddRows = false;
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            if (txt_rut.Text != String.Empty && txt_rubro.Text != String.Empty && txt_razon.Text != String.Empty && txt_usuario.Text != String.Empty && txt_contrasena.Password != String.Empty && txt_RepetirContra.Password != String.Empty)
            {
                NEGOCIO.Usuario usuario = new NEGOCIO.Usuario();
                usuario.User = txt_usuario.Text.ToLower();
                if (usuario.getUsuarioIdByName(usuario.User) == 0)
                {
                    if (txt_contrasena.Password == txt_RepetirContra.Password)
                    {
                        usuario.Contrasena = txt_contrasena.Password;
                        usuario.TipoUsuario = "proveedor";
                        if (usuario.agregarUsuario(usuario.User))
                        {
                            int id = usuario.getUsuarioMaxId();
                            NEGOCIO.Proveedor proveedor = new NEGOCIO.Proveedor();
                            proveedor.Rut = txt_rut.Text;
                            if (proveedor.getProveedor() == null)
                            {
                                proveedor.Nombre = txt_razon.Text;
                                proveedor.Rubro = txt_rubro.Text;
                                proveedor.UsuarioId = id;
                                if (proveedor.agregarProveedor())
                                {
                                    MessageBox.Show(String.Format("Proveedor creado con exito \r Usuario: {0} \r Contraseña: {1} \r Recuerde dar estos datos al proveedor correspondiente", usuario.User, usuario.Contrasena), "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                                    LimiparTxt();
                                    CargarGrid();
                                }else
                                {
                                    MessageBox.Show("No se pudo agregar el proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }else
                            {
                                MessageBox.Show("El rut del proveedor actual ya se encuentra registrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                usuario.Id = usuario.getUsuarioMaxId();
                                usuario.borrarUsuario();
                                
                            }
                        }else
                        {
                            MessageBox.Show("No se pudo crear el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no son iguales", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }else
                {
                    MessageBox.Show("Ya existe el nombre de usuario, favor intentar con otro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }else
            {
                MessageBox.Show("Faltan campos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimiparTxt()
        {
            txt_rut.Text = String.Empty;
            txt_razon.Text = String.Empty;
            txt_rubro.Text = String.Empty;
            txt_usuario.Text = String.Empty;
            txt_contrasena.Password = String.Empty;
            txt_RepetirContra.Password = String.Empty;
        }

        private void dta_Proveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dta_Proveedores.SelectedIndex != -1)
            {
                NEGOCIO.Proveedor proveedor = dta_Proveedores.SelectedItem as NEGOCIO.Proveedor;

                if (proveedor != null)
                {
                    txt_modRazon.Text = proveedor.Nombre;
                    txt_modRubro.Text = proveedor.Rubro;
                }
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            if (dta_Proveedores.SelectedIndex != -1)
            {
                if (txt_modRubro.Text != String.Empty && txt_modRazon.Text != String.Empty)
                {
                    NEGOCIO.Proveedor proveedor = dta_Proveedores.SelectedItem as NEGOCIO.Proveedor;
                    proveedor.Nombre = txt_modRazon.Text;
                    proveedor.Rubro = txt_modRubro.Text;
                    if (proveedor.actualizarProveedor())
                    {
                        MessageBox.Show("Proveedor actualizado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                        txt_modRazon.Text = String.Empty;
                        txt_modRubro.Text = String.Empty;
                        CargarGrid();
                    }
                }else
                {
                    MessageBox.Show("Faltan campos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_elimnar_Click(object sender, RoutedEventArgs e)
        {
            if (dta_Proveedores.SelectedIndex != -1)
            {
                NEGOCIO.Proveedor proveedor = dta_Proveedores.SelectedItem as NEGOCIO.Proveedor;
                MessageBoxResult resultado = MessageBox.Show(String.Format("¿Esta seguro que desea eliminar al proveedor seleccionado? \rEsta acción no se puede deshacer."), "Anulación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                switch (resultado)
                {   
                    case MessageBoxResult.Yes:
                        NEGOCIO.Usuario user = new NEGOCIO.Usuario();
                        user.Id = proveedor.UsuarioId;
                        if (user.borrarUsuario())
                        {
                            MessageBox.Show("Proveedor eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                            txt_modRazon.Text = String.Empty;
                            txt_modRubro.Text = String.Empty;
                            CargarGrid();
                        }
                        break;
                }             
            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
