using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hostal.NEGOCIO;

namespace Hostal.WEB
{
    public partial class Arriendo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetalleFacturaCollection det = new DetalleFacturaCollection();

            det.Consulta(DateTime.Today, Convert.ToDateTime("09-06-2018"));


            if (!IsPostBack)
            {
                DateTime fecha = DateTime.Today;
                TxtFechaInicio.Value = DateTime.Today.ToString();
                

                CargarHuesped();
                CreaTabla();
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

            Empresa emp = new Empresa();
            emp = (Empresa)Session["empresa"];


            foreach (NEGOCIO.Huesped item in hue.ReadAll(/*emp.Rut*/"18.465.104-1"))
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

        private void CreaTabla()
        {
            NEGOCIO.HabitacionCollection habitaciones = new NEGOCIO.HabitacionCollection();
            string tabla = "<table class='table table-hover' id='Tabla'>";
            tabla = tabla + "<thead>";
            tabla = tabla + "<tr>";
            tabla = tabla + "<th style='text-align: center;'>Número</th>";
            tabla = tabla + "<th style='text-align: center;'>Precio</th>";
            tabla = tabla + "<th style='text-align: center;'>Tipo</th>";
            tabla = tabla + "<th style='text-align: center;'>Tipo Cama</th>";
            tabla = tabla + "<th style='text-align: center;'>Registrar</th>";

            tabla = tabla + "</tr>";
            tabla = tabla + "</thead>";
            tabla = tabla + "<tbody>";
            foreach (NEGOCIO.Habitacion item in habitaciones.ReadAll())
            {
                tabla = tabla + "<tr>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Numero + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Precio + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Tipo + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.TipoCama + "</td>";
                tabla = tabla + "<td style='text-align: center;'><input type='button' id='"+ item.Numero +"' class='btn' value='Reservar' style='background-color: #4286f4; color: white;'/></td>";
                tabla = tabla + "</tr>";
            }
            tabla = tabla + "</tbody>";
            tabla = tabla + "</table>";
            tablaHtml.InnerHtml = tabla;
        }


        protected void Reservar_Click(object sender, EventArgs e)
        {
            string hola = "";
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {

            DetalleFacturaCollection detalles = new DetalleFacturaCollection();
            HabitacionCollection habitacion = new HabitacionCollection();

            foreach (var item in detalles.ReadAll())
            {
                DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
                DateTime Salida = Convert.ToDateTime(TxtFechaFinal.Value);

                if ( llegada > item.FechaIngreso && llegada > item.FechaIngreso )
                {

                }
            }

        }
    }
}