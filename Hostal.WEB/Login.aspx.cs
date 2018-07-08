using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hostal.NEGOCIO;

namespace Hostal.WEB
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cupon cupon = new Cupon();

            cupon.GenerarCupon();
  
        }

        protected void LoginPanel_Authenticate(object sender, AuthenticateEventArgs e)
        {
            NEGOCIO.Usuario usuario = new NEGOCIO.Usuario();
            usuario.Id = usuario.validarUsuario(LoginPanel.UserName, LoginPanel.Password);
            if (usuario.Id != 0)
            {
                usuario = usuario.getUsuario();
                Session["usuario"] = usuario;

                if(usuario.TipoUsuario=="empresa")
                {
                    NEGOCIO.Empresa empresa = new NEGOCIO.Empresa();
                    Session["empresa"] = empresa.getEmpresaByUserId(usuario);
                }
                else if(usuario.TipoUsuario == "proveedor")
                {
                    NEGOCIO.Proveedor proveedor = new NEGOCIO.Proveedor();
                    Session["proveedor"] = proveedor.getProveedorByUserId(usuario);
                }

                
                Response.Redirect("Index.aspx");
            }
        }
    }
}