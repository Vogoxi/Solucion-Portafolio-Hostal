using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class AgregarHuesped : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NEGOCIO.Empresa empresa = (NEGOCIO.Empresa)Session["empresa"];
            NEGOCIO.Huesped huesped = new NEGOCIO.Huesped();
            huesped.Nombre = txtNombre.Text;
            huesped.Apellido = txtApellido.Text;
            huesped.Rut = txtRut.Text;
            huesped.Telefono = txtTelefono.Text;
            huesped.EmpresaRut = empresa.Rut;

            if (huesped.agregarHuesped())
            {
                lblStatus.Text = "Huesped Agregado";
            }else{
                lblStatus.Text = "No se pudo agregar el huesped";
            }
     
        }
    }
}