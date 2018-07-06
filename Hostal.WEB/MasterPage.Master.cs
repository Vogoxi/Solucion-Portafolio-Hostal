using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hostal.NEGOCIO;

namespace Hostal.WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (Usuario)Session["usuario"];

            if(usuario.TipoUsuario == "empresa")
            {


            }else if(usuario.TipoUsuario == "proveedor")
            {

            }else if(usuario.TipoUsuario == "empleado")
            {

            }else if(usuario.TipoUsuario == "administrador")
            {

            }else
            {

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}