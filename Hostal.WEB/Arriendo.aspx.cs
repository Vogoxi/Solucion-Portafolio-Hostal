using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class Arriendo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NEGOCIO.HuespedCollection huespedes = new NEGOCIO.HuespedCollection();
            List<NEGOCIO.Huesped> lista = huespedes.ReadAll();
            foreach (NEGOCIO.Huesped huesped in lista)
            {
                ddlHuespedes.DataSource = huesped;
                ddlHuespedes.DataTextField = huesped.Nombre +" "+ huesped.Apellido;
                ddlHuespedes.DataValueField = huesped.Rut;
                ddlHuespedes.DataBind();
            } 
        }
    }
}