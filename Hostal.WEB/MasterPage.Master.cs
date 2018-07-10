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

            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }else
            {
                usuario = (Usuario)Session["usuario"];

                if (usuario.TipoUsuario == "empresa")
                {
                    perfilmenu.Visible = true;
                    usuariomenu.Visible = true;
                    huespedmenu.Visible = true;
                    arrendarmenu.Visible = true;
                    menuproveedor.Visible = false;
                    ordenpmenu.Visible = false;
                    navbarDropdown.Visible = true;
                    navbarDropdown1.Visible = true;
                    navbarDropdown2.Visible = false;
                    

                }
                else if (usuario.TipoUsuario == "proveedor")
                {
                    perfilmenu.Visible = false;
                    usuariomenu.Visible =false;
                    huespedmenu.Visible = false;
                    arrendarmenu.Visible = false;
                    menuproveedor.Visible = true;
                    ordenpmenu.Visible = true;
                    navbarDropdown.Visible = false;
                    navbarDropdown1.Visible = false;
                    navbarDropdown2.Visible = true;
                }
            }

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}