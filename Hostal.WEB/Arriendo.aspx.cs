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

            if (!IsPostBack)
            {
                CargarHuesped();
            }

        }


        private void CargarHuesped()
        {
            NEGOCIO.HuespedCollection hue = new NEGOCIO.HuespedCollection();
            List<NEGOCIO.Huesped> listaHue = new List<NEGOCIO.Huesped>();
            NEGOCIO.Huesped huesped = new NEGOCIO.Huesped();
            huesped.Rut = "";
            huesped.Nombre = "Seleccione Huesped";
            listaHue.Add(huesped);
            foreach (NEGOCIO.Huesped item in hue.ReadAll())
            {
                huesped = new NEGOCIO.Huesped();
                huesped.Rut = item.Rut;
                huesped.Nombre = item.Nombre;
                huesped.Apellido = item.Apellido;
                listaHue.Add(huesped);
            }

            ddlHuespedes.DataSource = listaHue;
            ddlHuespedes.DataTextField = "NomApe";
            ddlHuespedes.DataValueField = "Rut";
            ddlHuespedes.DataBind();
        }
    }
}