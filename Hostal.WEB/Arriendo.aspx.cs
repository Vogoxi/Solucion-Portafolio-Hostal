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

            Reserva = new List<NEGOCIO.Reserva>();

            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];
            }

            foreach (NEGOCIO.Huesped item in hue.ReadAllRes(/*emp.Rut*/"18.465.104-1",Reserva))
            {
                huesped = new NEGOCIO.Huesped();
                huesped.Rut = item.Rut;
                huesped.Nombre = item.Nombre;
                huesped.Apellido = item.Apellido;
                huesped.Telefono = item.Telefono;
                huesped.EmpresaRut = item.EmpresaRut;

                listaHue.Add(huesped);
            }
          
            ddlHuespedes.DataSource = listaHue;
            ddlHuespedes.DataTextField = "NomApe";
            ddlHuespedes.DataValueField = "Rut";
            ddlHuespedes.DataBind();
        }

        private void CreaTabla(List<Habitacion> habitaciones)
        {
            tablaHtml.InnerHtml = null;

                string tabla = "<table  class='table table-hover' id='Tabla'>";
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
                idhuesped = ddlHuespedes.SelectedValue;
               

                if (IdHidden.Value != null || IdHidden.Value != "")
                {
                    idHabitacion = IdHidden.Value;

                    Reserva reserva = new Reserva();

                    int id;

                    int.TryParse(idHabitacion, out id);

                    reserva.Numero = id;
                    reserva.Rut = idhuesped;
                    reserva.FechaInicio = Convert.ToDateTime(TxtFechaInicio.Value);
                    reserva.FechaTermino = Convert.ToDateTime(TxtFechaFinal.Value);

                    Reserva.Add(reserva);

                    Session["Reserva"] = Reserva;

                    GuardarComida(Reserva);

  
                    CargarHuesped();

                    HabitacionCollection habitacion = new HabitacionCollection();
                    DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
                    DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);

                    List<Habitacion> habitaciones = new List<Habitacion>();

                    habitaciones = habitacion.HabitacionesDisponibles(llegada, salida, Reserva);

                    CreaTabla(habitaciones);
                    
                    CreaTablaRes(Reserva);

              
                    
                    //ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "test", "tablaInit();", true);
                    //ScriptManager.RegisterStartupScript(UpdatePanel3, this.GetType(), "test", "tablaInit();", true);

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

            tablaHtmlRes.InnerHtml = null;

            if (Session["Reserva"] != null)
            {
                
                tabla = tabla + "<thead>";
                tabla = tabla + "<tr>";
                tabla = tabla + "<th style='text-align: center;'>Número</th>";
                tabla = tabla + "<th style='text-align: center;'>Rut</th>";
                tabla = tabla + "<th style='text-align: center;'>Nombre</th>";
                tabla = tabla + "<th style='text-align: center;'>Fecha llegada</th>";
                tabla = tabla + "<th style='text-align: center;'>Fecha salida</th>";
                tabla = tabla + "<th style='text-align: center;'>Servicio Comedor</th>";
                tabla = tabla + "<th style='text-align: center;'>Opciones</th>";
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
                hab = hab.GetHabitacion();
                hues = hues.getHuesped();

                tabla = tabla + "<tr>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Numero + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Rut + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + hues.NomApe + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.FechaInicio.ToShortDateString() + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.FechaTermino.ToShortDateString() + "</td>";

                ServicioCollection servicios = new ServicioCollection();
                
                tabla = tabla + "<td style='text-align: center;'> <select runat='server' name='Select" + item.Numero + "' id='Select" + item.Numero + "'>";
                
                tabla = tabla + "<option>Seleccione Servicio</option>";

                foreach (var food in servicios.ReadAll())
                {
                    if(item.Servicio == food.Id)
                    {
                        tabla = tabla + "<option value='" + food.Id + "' selected>" + food.Nombre + "</option>";
                        
                    }else
                    {
                        tabla = tabla + "<option value='" + food.Id + "'>" + food.Nombre + "</option>";
                    }
                    
                    
                }
                tabla = tabla +"</ select > ";
                tabla = tabla + "<td style='text-align: center;'>" + "</td>";

                

                 tabla = tabla + "</tr>";
            }
            tabla = tabla + "</tbody>";
            tabla = tabla + "</table>";
            
            tablaHtmlRes.InnerHtml = tabla;
        }


        protected void Consultar_Click(object sender, EventArgs e)
        {
            HabitacionCollection habitacion = new HabitacionCollection();
            DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
            DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);

            Reserva = new List<NEGOCIO.Reserva>();

            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];
            }

            CreaTabla(habitacion.HabitacionesDisponibles(llegada, salida,Reserva));

        }

        protected void GenerarFactura_Click(object sender, EventArgs e)
        {
            Reserva = new List<NEGOCIO.Reserva>();

            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];

                GuardarComida(Reserva);

                Factura factura = new Factura();

                factura.FechaFacturacion = DateTime.Today;
                factura.IdEmpresa = "18.465.104-1";
                factura.Total = 0;
                bool estado = true;

                if (factura.AgregarFactura())
                {
                    foreach (var item in Reserva)
                    {
                        DetalleFactura detFac = new DetalleFactura();

                        detFac.FechaIngreso = item.FechaInicio;
                        detFac.FechaSalida = item.FechaTermino;
                        detFac.IdFactura = factura.Id;
                        detFac.IdHabitacion = item.Numero;
                        detFac.IdHuesped = item.Rut;
                        detFac.IdServicio = item.Servicio;

                        if (!detFac.AgregarDetalleFactura())
                        {
                            estado = false;
                            break;
                            //borrar detalles
                            //facturas
                        }
                    }
                }

                if (estado)
                {
                    //generarcupon
                }
                else
                {
                    //Error
                }
                

                


            }
            else
            {
                //Error
            }

            



        }

        private void GuardarComida(List<Reserva> reserva)
        {
            int id = 0;
             
            foreach (var item in reserva)
            {
                if (Request.Form["Select"+item.Numero] != null)
                {
                    int.TryParse(Request.Form["Select" + item.Numero], out id);
                    item.Servicio = id;
                }else
                {
                    item.Servicio = 0;
                }
                
            }
        }


    }
}