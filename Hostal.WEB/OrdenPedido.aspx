<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrdenPedido.aspx.cs" Inherits="Hostal.WEB.OrdenPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        
        
        <div class="container" style="margin-top: 70px;">
            <div class="row">
        <div class="col-sm">
            <div class="form-row">
            <h2 class="sub-header">Ordenes de Compra</h2>
              <div class="table-responsive">
                <asp:GridView ID="grid_facturas" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_facturas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="NPedido" HeaderText="N° Pedido" ReadOnly="True" SortExpression="N_PEDIDO" />
                        <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emisión" ReadOnly="True" SortExpression="FECHA_EMISION" />
                        <asp:BoundField DataField="FechaEstadoEntrega" HeaderText="Fecha Entrega" ReadOnly="False" SortExpression="FECHA_ENTREGA" />
                        <asp:BoundField DataField="IdEmpleado" HeaderText="ID_EMPLEADO" ReadOnly="True" SortExpression="ID_EMPLEADO" Visible="False" />
                        <asp:BoundField DataField="IdProveedor" HeaderText="ID_PROVEEDOR" ReadOnly="True" SortExpression="ID_PROVEEDOR" Visible="False" />
                    </Columns>
                </asp:GridView>    
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=Entities" DefaultContainerName="Entities" EnableFlattening="False" EntitySetName="PEDIDO" EntityTypeFilter="PEDIDO" Select="it.[N_PEDIDO], it.[FECHA_EMISION], it.[FECHA_ENTREGA], it.[ID_EMPLEADO], it.[ID_PROVEEDOR]">
                </asp:EntityDataSource>
            </div>        
        </div>
    </br>
        <div class="form-row">
                <h2 class="sub-header">
                        <asp:Label ID="lbl_detalle" runat="server" Text="Productos OC N°:"></asp:Label>
                    </h2>
                    <div class="table-responsive">
                        <asp:GridView ID="grid_detalle" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" Visible="False" />
                                <asp:BoundField DataField="PRODUCTO" HeaderText="PRODUCTO" ReadOnly="True" SortExpression="PRODUCTO" />
                                <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" ReadOnly="True" SortExpression="CANTIDAD" />
                            </Columns>
                        </asp:GridView>
                        <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=Entities" DefaultContainerName="Entities" EnableFlattening="False" EntitySetName="DETALLE_PEDIDO" Select="it.[ID], it.[PRODUCTO], it.[CANTIDAD]">
                        </asp:EntityDataSource>
                    </div>
        </div>
            </div>
            <div class="col-sm">
                <h2 class="sub-header">Validar</h2>
                
                    <div class="form-row">
                            <div class="form-group col-md-6">
                        <label>N° OC</label>
                                <asp:TextBox ID="txt_nOrden" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-row">
                        <div class="form-group col-md-6">
                          <label>Fecha Emisión</label>
                            <asp:TextBox ID="txtEmision"  class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                          <label>Fecha Entrega</label>                           
                          <input type="date" class="form-control" runat="server" id="txtEntrega"/>                           
                        </div>
                      </div>
                      <div class="form-row">
                        <div class="form-group col-md-6">
                                <br>
                                    <asp:Label ID="lbl_Estado" runat="server"></asp:Label>
                                <br>
                                <asp:Button ID="btn_rechazar"  class="btn btn-danger" runat="server" Text="Rechazar" OnClick="btn_rechazar_Click" />
                            <asp:Button ID="btn_aprobar"  class="btn btn-success" runat="server" Text="Aprobar" OnClick="btn_aprobar_Click" />
                        </div>
                      </div>
                    
              </div>
        </div>
            </div>
    </asp:Panel>
</asp:Content>
