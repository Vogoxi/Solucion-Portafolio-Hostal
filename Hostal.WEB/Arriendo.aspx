<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Arriendo.aspx.cs" Inherits="Hostal.WEB.Arriendo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server">
        <asp:ScriptManager EnablePageMethods="True" runat="server"></asp:ScriptManager>
        <div class="container py-3">
            <div class="row">
                <div class="mx-auto col-sm-6">
                            <!-- form user info -->
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Reserva</h4>
                                </div>
                                <div class="card-body">
                                   
                                    <h5>Seleccione Fecha de su estadia</h5>

                                    <br />


                                    <div class="form-group row col-lg-12">
                                        <div class="col-lg-3">
                                            <label>Inicio</label>
                                        </div>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-3">
                                            <label>Termino</label>
                                        </div>
                                        <div class="col-lg-1"></div>
                                        <br />
                                        <div class="col-lg-3">
                                            <input id="TxtFechaInicio" runat="server" type="date"  />
                                        </div>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-3">
                                            <input id="TxtFechaFinal" runat="server" type="date" />
                                        </div>
                                        <div class="col-lg-1"></div>
                                    </div>
                                    <div class="form-group row col-lg-12">

                                        <div class="col-lg-5"></div>
                                        <asp:Button ID="Consultar" runat="server" Text="Consultar" class='btn' style='background-color: #4286f4; color: white;' OnClick="Consultar_Click"/>

                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label"></label>
                                            <div class="col-lg-9">
                                                   <asp:DropDownList ID="ddlHuespedes" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class ="form-group row">
                                              <div class="table-responsive" id="tablaHtml" runat="server">
                                    
                                              </div>
                                        </div>
                                     
                                        <div class="hidden"><input type="hidden" id="IdHidden" runat="server" /></div>
                                         <input type="button"  id="reservar"  runat="server" OnClick="Reservar_Click"/>
                                        
  
                                    </ContentTemplate>
                                        </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                                          <div class="table-responsive" id="tablaHtmlRes" runat="server">
                                          </div>

                                       </ContentTemplate>
                                    </asp:UpdatePanel>
                                     
                                </div>
                                
                                </div>
                            </div>

                   </div> <!-- /form user info -->
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

            });
            $(":button").click(function () {
                var idhabitacion = $(this).attr("id");
                console.log(idhabitacion);
                $("#ContentPlaceHolder1_IdHidden").val(idhabitacion);
                $("#ContentPlaceHolder1_reservar").trigger("click");
            });
           

        </script>
</asp:Content>
