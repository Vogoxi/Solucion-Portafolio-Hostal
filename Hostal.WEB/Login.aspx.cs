using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void LoginPanel_Authenticate(object sender, AuthenticateEventArgs e)
        {
            NEGOCIO.Usuario usuario = new NEGOCIO.Usuario();
            usuario.Id = usuario.validarUsuario(LoginPanel.UserName, LoginPanel.Password);
            if (usuario.Id != 0)
            {
                usuario = usuario.getUsuario();
                Session["usuario"] = usuario;
                NEGOCIO.Empresa empresa = new NEGOCIO.Empresa();
                Session["empresa"] = empresa.getEmpresaByUserId(usuario);
                Response.Redirect("Index.aspx");
            }
        }
    }
}