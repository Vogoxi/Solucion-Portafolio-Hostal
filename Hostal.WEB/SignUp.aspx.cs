using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            NEGOCIO.Usuario usuario = new NEGOCIO.Usuario();
            usuario.User = txtUsuario.Text;
            usuario.Contrasena = txtPassword.Text;
            usuario.TipoUsuario = "Empresa";

            if (usuario.agregarUsuario(txtUsuario.Text))
            {
                usuario.Id = (int)usuario.getUsuarioMaxId();
                usuario = usuario.getUsuario();

                NEGOCIO.Empresa empresa = new NEGOCIO.Empresa();
                empresa.Rut = txtRut.Text;
                empresa.RazonSocial = txtRazonSocial.Text;
                empresa.Giro = txtGiro.Text;
                empresa.Telefono = txtTelefono.Text;
                empresa.Direccion = txtDireccion.Text;
                empresa.UsuarioId = usuario.Id;

                if (empresa.agregarEmpresa())
                {
                    lblStatus.Text = "Empresa creada con exito";
                }
                else{                    
                    usuario.borrarUsuario();
                    lblStatus.Text = "No se pudo crear la empresa";
                }
            }else{
                lblStatus.Text = "El nombre de usuario ya existe";
            }
        }
    }
}