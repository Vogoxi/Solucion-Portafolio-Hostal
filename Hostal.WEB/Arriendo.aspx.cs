using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hostal.NEGOCIO;
using System.Web.Services;

namespace Hostal.WEB
{
    public partial class Arriendo : System.Web.UI.Page
    {
        List<Reserva> Reserva = new List<Reserva>();

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

            Empresa emp = new Empresa();
            emp = (Empresa)Session["empresa"];

            Reserva = new List<NEGOCIO.Reserva>();

            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];
            }

            foreach (NEGOCIO.Huesped item in hue.ReadAllRes(emp.Rut,Reserva))
            {
                huesped = new NEGOCIO.Huesped();
                huesped.Rut = item.Rut;
                huesped.Nombre = Auxiliar.UppercaseWords(item.Nombre);
                huesped.Apellido = Auxiliar.UppercaseWords(item.Apellido);
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
            
                string tabla = "<table  class='table table-hover table-striped' id='Tabla'>";
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
                    tabla = tabla + "<td style='text-align: center;'>" + item.Precio.ToString("C0") + "</td>";
                    tabla = tabla + "<td style='text-align: center;'>" + Auxiliar.UppercaseWords(item.Tipo) + "</td>";
                    tabla = tabla + "<td style='text-align: center;'>" + Auxiliar.UppercaseWords(item.TipoCama) + "</td>";
                    tabla = tabla + "<td style='text-align: center;'><input type='button' class='btn' data-res='reserva' id='"+item.Numero+ "' ' value='Reservar' style='background-color: #4286f4; color: white;' class='btn'/></td>";
                    tabla = tabla + "</tr>";
                }
                tabla = tabla + "</tbody>";
                tabla = tabla + "</table>";
                
                tablaHtml.InnerHtml = tabla;
        }


        protected void Reservar_Click(object sender, EventArgs e)
        {
            if (ddlHuespedes.SelectedIndex== -1 || ddlHuespedes.SelectedIndex !=0)
            {
                if (Session["Reserva"] != null)
                {
                    Reserva = (List<Reserva>)Session["Reserva"];
                }
                else
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

                        bool estado = false;

                        foreach (var item in Reserva)
                        {
                            if (item.Numero == id)
                            {
                                estado = true;
                            }
                        }

                       
                            reserva.Numero = id;
                            reserva.Rut = idhuesped;
                            reserva.FechaInicio = Convert.ToDateTime(TxtFechaInicio.Value);
                            reserva.FechaTermino = Convert.ToDateTime(TxtFechaFinal.Value);

                        if (estado == false)
                        {
                            Reserva.Add(reserva);
                            Session["Reserva"] = Reserva;
                        }

                            GuardarComida(Reserva);

                            txtPrecio.Text = ActualizarPrecio(Reserva).ToString("C0");

                            CargarHuesped();

                            HabitacionCollection habitacion = new HabitacionCollection();
                            DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
                            DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);

                            List<Habitacion> habitaciones = new List<Habitacion>();

                            habitaciones = habitacion.HabitacionesDisponibles(llegada, salida, Reserva);

                            CreaTabla(habitaciones);

                            CreaTablaRes(Reserva);

                            string script = @"$(document).ready(function(){
                                    $('#Tabla').DataTable({
                                     ""fnDrawCallback"": function(oSettings) {
                                     $('div.dataTables_filter input').attr('placeholder','Filtro por Campo...');
                                          },
                                     ""bLengthChange"": false
                                      });
                                     });
                                     $("":button"").click(function () {
                                     var idhabitacion = $(this).attr(""id"");
                                    var reserva = $(this).data(""res"");
                                    if (reserva == ""reserva"")
                                    {
                                    $(""#ContentPlaceHolder1_IdHidden"").val(reserva);
                                    $(""#ContentPlaceHolder1_reservar"").trigger(""click"");
                                     }
                                     });$('#TablaRes').DataTable({
                                     ""fnDrawCallback"": function(oSettings) {
                                     $('div.dataTables_filter input').attr('placeholder','Filtro por Campo...');
                                          },
                                     ""bLengthChange"": false
                                      });
                                     });
                                     $("":button"").click(function () {
                                     var idborrar = $(this).attr(""id"");
                                    var reserva = $(this).data(""tai"");
                                    if (reserva == ""BorraReserva"")
                                    {
                                    $(""#ContentPlaceHolder1_IdHidden2"").val(reserva);
                                    $(""#ContentPlaceHolder1_BorraReserva"").trigger(""click"");
                                     }
                                     });";

                            ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "test", "tablaInit();", true);
                            ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "test", script, true);

                        mensaje2.InnerText = "";

                    }
            


                }
                else
                {
                    //Error
                }


            }else
            {
                mensaje2.InnerText = "Debe Elegir Huesped";
            }


        }


        private void CreaTablaRes(List<Reserva> reservas)
        {
            string tabla = "<table class='table table-hover table-striped' id='TablaRes'>";

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
                tabla = tabla + "<th style='text-align: center;'>Opcion</th>";
                tabla = tabla + "</tr>";
                tabla = tabla + "</thead>";
                tabla = tabla + "<tbody>";


                Reserva = (List<Reserva>)Session["Reserva"];

                if (Reserva.Count>0)
                {
                    btnHidden.Visible = true;
                }else
                {
                    btnHidden.Visible = false;
                }
                

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
                Auxiliar.UppercaseWords(hues.Nombre);
                Auxiliar.UppercaseWords(hues.Apellido);

                tabla = tabla + "<tr>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Numero + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.Rut + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + hues.NomApe + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.FechaInicio.ToShortDateString() + "</td>";
                tabla = tabla + "<td style='text-align: center;'>" + item.FechaTermino.ToShortDateString() + "</td>";

                ServicioCollection servicios = new ServicioCollection();
                
                tabla = tabla + "<td style='text-align: center;'> <select runat='server' class='cambio' name='Select" + item.Numero + "' id='Select" + item.Numero + "'>";
                
                tabla = tabla + "<option value='0'>Seleccione Servicio</option>";

                foreach (var food in servicios.ReadAll())
                {
                    if(item.Servicio == food.Id)
                    {
                        tabla = tabla + "<option value='" + food.Id + "' selected>" + food.Nombre+" "+ food.Precio.ToString("C0") + "</option>";
                        
                    }else
                    {
                        tabla = tabla + "<option value='" + food.Id + "'>" + food.Nombre + " " + food.Precio.ToString("C0") + "</option>";
                    }
                    
                    
                }
                tabla = tabla + "</ select > </td>";
                tabla = tabla + "<td style='text-align: center;'><input type='button' data-tai='BorraReserva' style='background-color: #4286f4; color: white;' class='btn' id='" + item.Numero + "' value='Borrar'/></td>";


                tabla = tabla + "</tr>";
            }
            tabla = tabla + "</tbody>";
            tabla = tabla + "</table>";
            
            tablaHtmlRes.InnerHtml = tabla;
        }


        protected void Consultar_Click(object sender, EventArgs e)
        {
            if (TxtFechaInicio.Value != "" && TxtFechaFinal.Value!= "")
            {
                HabitacionCollection habitacion = new HabitacionCollection();
                DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
                DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);
                DateTime today = DateTime.Today;

                if (today>llegada || today> salida || llegada>=salida)
                {
                    mensaje1.InnerText = "Las fechas deben ser mayor a "+ today.ToShortDateString() + " y la de llegada menor a la de salida";
                }else
                {
                    Reserva = new List<NEGOCIO.Reserva>();

                    if (Session["Reserva"] != null)
                    {
                        Reserva = (List<Reserva>)Session["Reserva"];

                        GuardarComida(Reserva);

                        Session["Reserva"] = Reserva;
                    }

                    CreaTabla(habitacion.HabitacionesDisponibles(llegada, salida, Reserva));

                    mensaje1.InnerText = "";

                    ddlHidden.Visible = true;
                }
            }else
            {
                mensaje1.InnerText = "Debe Elegir fechas de llegada y salida";
            }
        }

        protected void GenerarFactura_Click(object sender, EventArgs e)
        {
            Reserva = new List<NEGOCIO.Reserva>();

            if (Session["Reserva"] != null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];

                GuardarComida(Reserva);

                Session["Reserva"] = Reserva;

                CreaTablaRes(Reserva);

                Factura factura = new Factura();

                Empresa emp = new Empresa();
                emp = (Empresa)Session["Empresa"];

                factura.FechaFacturacion = DateTime.Today;
                factura.IdEmpresa = emp.Rut;
                factura.Total = 0;
                bool borrarFactura = false;

                if (factura.AgregarFactura())
                {

                    factura.Id = factura.getFacturaMaxId();

                    

                    foreach(var item in Reserva)
                    {
                        if (item.Servicio==0)
                        {
                            borrarFactura = true;
                        }
                    }

                    if (borrarFactura == true)
                    {
                        factura.BorrarFactura();
                    }
                    else
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

                            detFac.AgregarDetalleFactura();
                        }
                    }
                }

                if (borrarFactura == false)
                {
                    factura.Total = ActualizarPrecio(Reserva);

                    factura.ActualizarFactura();

                    Session["Reserva"] = null;

                    Response.Redirect("index.aspx");
                }
                else
                {
                    mensaje3.InnerText = "Tiene Huespedes sin Servicio de comedor elegido";
                }
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

        
        [WebMethod(EnableSession = true)]
        public static string ActualizarAjax(int id, int num)
        {
            int precio = 0;
            int valorHab = 0;
            int valorSer = 0;

            if (HttpContext.Current.Session["Reserva"] != null)
            {
                List<Reserva> res = new List<Reserva>();
                List<Reserva> res2 = new List<Reserva>();

                res = (List<Reserva>)HttpContext.Current.Session["Reserva"];

                foreach (var item in res)
                {
                    if (item.Numero == num)
                    {
                        item.Servicio = id;
                    }

                    res2.Add(item);
                }


                foreach (var item in res2)
                {
                    Reserva reservita = new Reserva();
                    reservita.Numero = item.Numero;
                    valorHab = reservita.getValorHabById(reservita.Numero);

                    if (item.Servicio != 0)
                    {
                        reservita.Servicio = item.Servicio;
                        valorSer = reservita.getValorSerById(reservita.Servicio);
                    }else
                    {
                        valorSer = 0;
                    }

                    int resultado = (int)item.FechaTermino.Subtract(item.FechaInicio).TotalDays;

                    precio = precio + (valorHab + valorSer) * resultado;

                    HttpContext.Current.Session["Reserva"] = res2;
                }
                  
            }
            
    
            return precio.ToString("C0");
        }

        private int ActualizarPrecio(List<Reserva> reserva)
        {
            int precio = 0;
            int valorHab = 0;
            int valorSer = 0;

            if (Session["Reserva"]!= null)
            {
                Reserva = (List<Reserva>)Session["Reserva"];

                foreach (var item in Reserva)
                {
                    Reserva reservita = new Reserva();
                    reservita.Numero = item.Numero;
                    valorHab = reservita.getValorHabById(reservita.Numero);

                    if (item.Servicio != 0)
                    {
                        reservita.Servicio = item.Servicio;
                        valorSer = reservita.getValorSerById(reservita.Servicio);

                    }
                    else
                    {
                        valorSer = 0;
                    }

                    int resultado = (int)item.FechaTermino.Subtract(item.FechaInicio).TotalDays;

                    precio = precio + (valorHab + valorSer) * resultado;

                }
            }else
            {
                precio = 0;
            }

            txtPrecio.Text = precio.ToString("C0");

            return precio;
        }


        protected void BorraReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Reserva"] != null)
                {
                    Reserva = (List<Reserva>) Session["Reserva"];

                    foreach (var item in Reserva)
                    {
                        if (item.Numero == int.Parse(IdHidden2.Value))
                        {
                            Reserva.Remove(item);
                            //Se borro reserva mensaje
                            break;
                        }
                    }
                }

                Session["Reserva"] = Reserva;
                GuardarComida(Reserva);

                if (Reserva.Count>0)
                {
                    btnHidden.Visible = true;
                }else
                {
                    btnHidden.Visible = false;
                }

                txtPrecio.Text = ActualizarPrecio(Reserva).ToString("C0");

                CargarHuesped();

                HabitacionCollection habitacion = new HabitacionCollection();
                DateTime llegada = Convert.ToDateTime(TxtFechaInicio.Value);
                DateTime salida = Convert.ToDateTime(TxtFechaFinal.Value);

                List<Habitacion> habitaciones = new List<Habitacion>();

                habitaciones = habitacion.HabitacionesDisponibles(llegada, salida, Reserva);

                CreaTabla(habitaciones);

                if (Reserva.Count != 0)
                {
                    CreaTablaRes(Reserva);
                }else
                {
                    tablaHtmlRes.InnerHtml = "";
                }


                string script = @"$(document).ready(function(){
                                    $('#Tabla').DataTable({
                                     ""fnDrawCallback"": function(oSettings) {
                                     $('div.dataTables_filter input').attr('placeholder','Filtro por Campo...');
                                          },
                                     ""bLengthChange"": false
                                      });
                                     });
                                     $("":button"").click(function () {
                                     var idhabitacion = $(this).attr(""id"");
                                    var reserva = $(this).data(""res"");
                                    if (reserva == ""reserva"")
                                    {
                                    $(""#ContentPlaceHolder1_IdHidden"").val(reserva);
                                    $(""#ContentPlaceHolder1_reservar"").trigger(""click"");
                                     }
                                     });$('#TablaRes').DataTable({
                                     ""fnDrawCallback"": function(oSettings) {
                                     $('div.dataTables_filter input').attr('placeholder','Filtro por Campo...');
                                          },
                                     ""bLengthChange"": false
                                      });
                                     });
                                     $("":button"").click(function () {
                                     var idborrar = $(this).attr(""id"");
                                    var reserva = $(this).data(""tai"");
                                    if (reserva == ""BorraReserva"")
                                    {
                                    $(""#ContentPlaceHolder1_IdHidden2"").val(reserva);
                                    $(""#ContentPlaceHolder1_BorraReserva"").trigger(""click"");
                                     }
                                     });";

                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "test1", "tablaInit();", true);
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "test2", script, true);
                ScriptManager.RegisterStartupScript(UpdatePanel3, this.GetType(), "test3", "tablaInit();", true);
                ScriptManager.RegisterStartupScript(UpdatePanel3, this.GetType(), "test4", script, true);

            }
            catch (Exception ex)
            {
                Logger.Log("hostal.Web.borrarReserva.aspx");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return;
            }
        }


    }
}