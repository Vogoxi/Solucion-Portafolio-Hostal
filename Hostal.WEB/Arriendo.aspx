<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Arriendo.aspx.cs" Inherits="Hostal.WEB.Arriendo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="Panel1" runat="server">
        <asp:ScriptManager EnablePageMethods="True" runat="server"></asp:ScriptManager>
        <div class="container py-3">
            <div class="row">
                <div class="mx-auto col-sm-12">
                            <!-- form user info -->
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Reserva</h4>
                                </div>
                                <div class="card-body">
                                   
                                    <h5>Seleccione Fecha de estadía de Huesped</h5>

                                    <br />


                                    <div class="form-group row col-lg-10">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-2">
                                            <h6><label>Llegada</label></h6>
                                        </div>
                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-2">
                                            <h6><label>Salida</label></h6>
                                        </div>
                                    <%--</div>--%>
                                    <div class="form-group row col-lg-10">
                                        <div class="col-lg-5"></div>
                                        <div class="col-lg-2">
                                            <input id="TxtFechaInicio" runat="server" class="" type="date"  />
                                        </div>
                                        <div class="col-lg-3"></div>
                                        <div class="col-lg-2">
                                            <input id="TxtFechaFinal" runat="server" class="" type="date" />
                                        </div>
                                    </div>


                                    <div class="form-group row col-lg-10 align-content-center">
                                        <div class="col-lg-8"></div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="Consultar" runat="server" Text="Consultar" class='btn btn-lg' style='background-color: #4286f4; color: white;' OnClick="Consultar_Click"/>
                                        </div>
                                    </div>

                                        <h6><label id="mensaje1" runat="server"></label></h6>
                                        <br />
                                    

                                  


                                       <div class="hidden"><input type="hidden" id="IdHidden" runat="server" /></div>
                                        
                                          <div class="d-none">
                                                <asp:Button  ID="reservar" runat="server" Text="esconder" OnClick="Reservar_Click"/>
                                          </div>
                                          
                                       <div ><input type="hidden" id="IdHidden2" runat="server" /></div>
                                        <div class="d-none">
                                                <asp:Button ID="BorraReserva" runat="server" Text="esconder" OnClick="BorraReserva_Click" />
                                          </div>
                              
                                </div>
                                
                                </div>

                                <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Habitaciones Disponibles</h4>
                                </div>
                                <div class="card-body">
                                   
                                    <h5>Seleccione Habitacion para Huesped</h5>
                                    </div>
                                    
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>

                                        <br />
                                         <div id="ddlHidden" runat="server" visible="false">
                                        <div class="form-group row col-lg-10">
                                            <div class="col-lg-6"></div>
                                            <div class="col-lg-5">
                                                   <asp:DropDownList ID="ddlHuespedes" CssClass="btn btn-primary" runat="server"></asp:DropDownList>
                                            </div>
                                            <h6><label id="mensaje2" runat="server"></label></h6>
                                        </div>
                                            </div>
                                    </ContentTemplate>
                                        </asp:UpdatePanel>


                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        
                                              <div class="table-responsive" id="tablaHtml" runat="server">
                                    
                                              </div>
                                       
                                    </ContentTemplate>
                                    </asp:UpdatePanel>


                            </div>

                     <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Habitaciones Reservadas</h4>
                                </div>
                                <div class="card-body">
                                   
                                    <h5>Seleccione Servicios de Comedor Para Huespedes</h5>
                                    </div>
                                    

                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        
                                        
                                            <div class="table-responsive" id="tablaHtmlRes" runat="server">

                                             </div>
                                       
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                         <div id="btnHidden" runat="server" visible="false">
                         <div class="form-group row col-lg-10">
                             <div class="col-lg-6"></div>
                                 <div><h5>Total:</h5></div>
                             <div ><h5><asp:TextBox ID="txtPrecio" ReadOnly="true" BorderStyle="None" text="0$" runat="server"></asp:TextBox></h5></div>
                        </div>
                        <div class="form-group row col-lg-10">
                            <div class="col-lg-6"></div>
                                     <asp:Button ID="BtnFactura"  runat="server" Text="Hacer Reservación" class="btn btn-lg" style="background-color: #4286f4; color: white;" OnClick="GenerarFactura_Click"/>
                                     <div class="col-lg-2"></div>
                              </div>
                         </div>

                         <h6><label id="mensaje3" runat="server"></label></h6>
                            </div>


                     

                   </div> <!-- /form user info -->
        </div>
            </div>
            </div>
    </asp:Panel>

    <script src="../js/Datatables/jquery.dataTables.min.js"></script>


    <script>
        $(document).ready(function () {
            $('#Tabla').DataTable({
                "fnDrawCallback": function (oSettings) {
                    $('div.dataTables_filter input').attr('placeholder', 'Filtro por Campo...');
                },
                "bLengthChange": false
            });
                $('#TablaRes').DataTable({
                    "fnDrawCallback": function (oSettings) {
                        $('div.dataTables_filter input').attr('placeholder', 'Filtro por Campo...');
                    },
                    "bLengthChange": false
                });
            });
            
            $(":button").click(function () {
                var idhabitacion = $(this).attr("id");
                var reserva = $(this).data("res");
                console.log(reserva);
                if(reserva == "reserva"){
                    $("#ContentPlaceHolder1_IdHidden").val(idhabitacion);
                    $("#ContentPlaceHolder1_reservar").trigger("click");
                }
            });
            $(":button").click(function () {
                var idborrar = $(this).attr("id");
                var reserva = $(this).data("tai");
                console.log(reserva);
                if (reserva == "BorraReserva") {
                    $("#ContentPlaceHolder1_IdHidden2").val(idborrar);
                    $("#ContentPlaceHolder1_BorraReserva").trigger("click");
                }
            });
            $(".cambio").change(function () {
                var id = $(this).val();
                var num = $(this).attr("id");
                num = num.replace("Select","");
                console.log(num);
                $.ajax({
                    url: 'Arriendo.aspx/ActualizarAjax',
                    contentType:"application/json; charset=utf-8",
                    dataType:"json",
                    type:'POST',
                    data:JSON.stringify({"id":id,"num":num}),
                    success:function(response){
                        $("#ContentPlaceHolder1_txtPrecio").val(response.d);
                        console.log(response);
                    }
                });

            });


        </script>
</asp:Content>
