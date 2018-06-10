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
        List<Reserva> Reserva = new List<Reserva>();

        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                DateTime fecha = DateTime.Today;
                TxtFechaInicio.Value = DateTime.Today.ToString();
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

            if (Session["reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];
                Huesped hues = new Huesped();

                foreach (var item in Reserva)
                {
                    hues = new Huesped();
                    hues.Rut = item.Rut;
                    hues.getHuesped();

                    if (hues != null)
                    {
                        listaHue.Remove(hues);
                    }
                }
            }

            ddlHuespedes.DataSource = listaHue;
            ddlHuespedes.DataTextField = "NomApe";
            ddlHuespedes.DataValueField = "Rut";
            ddlHuespedes.DataBind();
        }

        private void CreaTabla(List<Habitacion> habitaciones)
        {

            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];
                Habitacion hab = new Habitacion();

                foreach (var item in Reserva)
                {
                    hab = new Habitacion();
                    hab.Numero = item.Numero;
                    hab.GetHabitacion();

                    if (hab != null)
                    {
                        habitaciones.Remove(hab);
                    }
                }
            }


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
                foreach (NEGOCIO.Habitacion item in habitaciones)
                {

                    tabla = tabla + "<tr>";
                    tabla = tabla + "<td style='text-align: center;'>" + item.Numero + "</td>";
                    tabla = tabla + "<td style='text-align: center;'>" + item.Precio + "</td>";
                    tabla = tabla + "<td style='text-align: center;'>" + item.Tipo + "</td>";
                    tabla = tabla + "<td style='text-align: center;'>" + item.TipoCama + "</td>";
                    tabla = tabla + "<td style='text-align: center;'><input type='button' id='" + item.Numero + "' class='btn' value='Reservar' style='background-color: #4286f4; color: white;'/></td>";
                    tabla = tabla + "</tr>";
                }
                tabla = tabla + "</tbody>";
                tabla = tabla + "</table>";
                tablaHtml.InnerHtml = tabla;
        }


        protected void Reservar_Click(object sender, EventArgs e)
        {
            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];
            }else
            {
                Reserva = new List<NEGOCIO.Reserva>();
            }

            string idHabitacion = "";
            string idhuesped = "";

            if (ddlHuespedes.SelectedIndex != 0 || ddlHuespedes.SelectedIndex != -1)
            {
                idHabitacion = ddlHuespedes.SelectedValue;

                if (IdHidden.Value != null || IdHidden.Value != "")
                {
                    idhuesped = IdHidden.Value;

                    Reserva reserva = new Reserva();

                    int id;

                    int.TryParse(idHabitacion, out id);

                    reserva.Numero = id;
                    reserva.Rut = idhuesped;

                    Reserva.Add(reserva);

                    Session["Reserva"] = Reserva;

                    CargarHuesped();

                    HabitacionCollection habitacion = new HabitacionCollection();
                    DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
                    DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);

                    CreaTabla(habitacion.HabitacionesDisponibles(llegada, salida));

                    CreaTablaRes(Reserva);

                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "test", "tablaInit();", true);

                }
                else
                {
                    //Error
                }


            }else
            {
                //ALERTA DEBE ELEGIR VALOR
            }


        }


        private void CreaTablaRes(List<Reserva> reservas)
        {
            string tabla = "<table class='table table-hover' id='TablaRes'>";

            if (Session["Reserva"] != null)
            {
                
                tabla = tabla + "<thead>";
                tabla = tabla + "<tr>";
                tabla = tabla + "<th style='text-align: center;'>Número</th>";
                tabla = tabla + "<th style='text-align: center;'>Rut</th>";
                tabla = tabla + "<th style='text-align: center;'>Nombre</th>";
                tabla = tabla + "</tr>";
                tabla = tabla + "</thead>";
                tabla = tabla + "<tbody>";


                Reserva = (List<Reserva>)Session["Reserva"];
                

            }

            foreach (var item in Reserva)
            {
                Habitacion hab = new Habitacion();
                Huesped hues = new Huesped();
                hab = new Habitacion();
                hues = new Huesped();

                hab.Numero = item.Numero;
                hues.Rut = item.Rut;
                hab.GetHabitacion();
                hues.getHuesped();

                tabla = tabla + "<tr>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Numero + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Rut + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + hues.Nombre + "</td>";
                tabla = tabla + "</tr>";
            }
            tabla = tabla + "</tbody>";
            tabla = tabla + "</table>";
            tablaHtml.InnerHtml = tabla;
        }


        protected void Consultar_Click(object sender, EventArgs e)
        {
            HabitacionCollection habitacion = new HabitacionCollection();
            DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
            DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);

            CreaTabla(habitacion.HabitacionesDisponibles(llegada, salida));

        }
    }
}