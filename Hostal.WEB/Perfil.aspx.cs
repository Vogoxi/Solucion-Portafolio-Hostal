using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class Perfil : System.Web.UI.Page
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
            NEGOCIO.Empresa empresa = (NEGOCIO.Empresa)Session["empresa"];
            txtRazonSocial.Text = empresa.RazonSocial;
            txtRut.Text = empresa.Rut;
            txtDireccion.Text = empresa.Direccion;
            txtGiro.Text = empresa.Giro;
            txtTelefono.Text = empresa.Telefono;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            NEGOCIO.Empresa empresa = (NEGOCIO.Empresa)Session["empresa"];
            empresa.Giro = txtGiro.Text.Trim();
            empresa.Telefono = txtTelefono.Text.Trim();
            empresa.Direccion = txtDireccion.Text.Trim();
            if (empresa.actualizarEmpresa())
            {
                lblStatus.Text = "Datos Actualizados";
            }else
            {
                lblStatus.Text = "Error al actualizar datos";
            }
        }
    }
}