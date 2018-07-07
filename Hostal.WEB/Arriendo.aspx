<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Arriendo.aspx.cs" Inherits="Hostal.WEB.Arriendo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function confirmar(idBol) {
            bootbox.confirm({
                title: "¿Borrar Reserva?",
                message: "¿Está seguro que quiere borrar esta reserva?",
                buttons: {
                    cancel: {
                        label: '<i class="fa fa-times"></i> Cancelar',
                        className: 'btn-danger'
                    },
                    confirm: {
                        label: '<i class="fa fa-check"></i> Borrar',
                        className: 'btn-default'
                    }
                },
                callback: function (result) {
                    if (result === true) {
                        var button = document.getElementById("BorraReserva");
                        var id = document.getElementById("IdHidden2");
                        id.value = idBol;
                        button.click();
                    }
                    if (result === false) {

                    }
                }
            });
        }
    </script>
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
                                   
                                    <h5>Seleccione Fecha de su estadia</h5>

                                    <br />


                                    <div class="form-group row col-lg-10">
                                        <div class="col-lg-3">
                                            <h6><label>Llegada</label></h6>
                                        </div>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-3">
                                            <h6><label>Salida</label></h6>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <br />
                                        <div class="col-lg-3">
                                            <input id="TxtFechaInicio" runat="server" class="" type="date"  />
                                        </div>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-3">
                                            <input id="TxtFechaFinal" runat="server" class="" type="date" />
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="form-group row col-lg-10 align-content-center">

                                        <div class="">
                                            <asp:Button ID="Consultar" runat="server" Text="Consultar" class='btn btn-lg' style='background-color: #4286f4; color: white;' OnClick="Consultar_Click"/>
                                        </div>
                                    </div>
                                    <div class="form-group row col-lg-10 align-content-center">

                                        <div></div>
                                        <h6><label id="mensaje1" runat="server"></label></h6>
                                        <br />
                                        
                                    </div>
                                    

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label"></label>
                                            <div class="col-lg-9">
                                                   <asp:DropDownList ID="ddlHuespedes" CssClass="btn btn-primary" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>

                                         

                                    </ContentTemplate>
                                        </asp:UpdatePanel>


                                       <div class="hidden"><input type="hidden" id="IdHidden" runat="server" /></div>
                                        
                                          <div class="d-none">
                                                <asp:Button  ID="reservar" runat="server" Text="esconder" OnClick="Reservar_Click"/>
                                          </div>
                                          
                                       <div ><input type="hidden" id="IdHidden2" runat="server" /></div>
                                        <div class="d-none">
                                                <asp:Button ID="BorraReserva" runat="server" Text="esconder" OnClick="BorraReserva_Click" />
                                          </div>

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        
                                              <div class="table-responsive" id="tablaHtml" runat="server">
                                    
                                              </div>

                                              
                                        
                                             <div class="table-responsive" id="tablaHtmlRes" runat="server">

                                             </div>
                                        
                                       
                                    </ContentTemplate>
                                    </asp:UpdatePanel>


                              <div class="form-group row col-lg-12">
                                     <asp:Button ID="BtnFactura"  runat="server" Text="Hacer Reservación" class="btn btn-lg" style="background-color: #4286f4; color: white;" OnClick="GenerarFactura_Click"/>
                                     <div class="col-lg-2"></div>
                                     <h4><label id="txtPrecio" runat="server"></label></h4>
                              </div>
                                </div>
                                
                                </div>

                    <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Reserva</h4>
                                </div>
                                <div class="card-body">
                                   
                                    <h5>Seleccione Fecha de su estadia</h5>
                                    </div>



                            </div>

                   </div> <!-- /form user info -->
        </div>
    </asp:Panel>

    <script src="../js/Datatables/jquery.dataTables.min.js"></script>
    <script src="cdn.datatables.net/1.10.18/css/jquery.dataTables.min.css"></script>

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

                    }
                });

            });


        </script>
</asp:Content>
