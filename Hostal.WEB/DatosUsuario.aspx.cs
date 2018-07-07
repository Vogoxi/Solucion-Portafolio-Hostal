using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class DatosUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            NEGOCIO.Usuario user = (NEGOCIO.Usuario)Session["usuario"];
            txtUsuario.Text = user.User;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            NEGOCIO.Usuario user = (NEGOCIO.Usuario)Session["usuario"];
            user.Contrasena = txtPassword.Text;
            if (user.actualizarUsuario())
            {
                lblStatus.Text = "Contraseña Actualizada";
            }else
            {
                lblStatus.Text = "No se pudo actualizar la contraseña";
            }
        }
    }
}