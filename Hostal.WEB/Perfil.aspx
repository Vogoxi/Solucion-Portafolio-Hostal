<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Hostal.WEB.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-3">
        <div class="row">
            <div class="mx-auto col-sm-6">
                        <!-- form user info -->
                        <div class="card">
                            <div class="card-header">
                                <center><h4 class="mb-0">Datos Empresa</h4></center>
                            </div>
                            <div class="card-body">
                                <form class="form" role="form">
                                    <div class="form-group row">
                                        <label class="col-lg-3 col-form-label form-control-label">Rut</label>
                                        <div class="col-lg-9">
                                                <asp:TextBox ID="txtRut" class="form-control" runat="server" disabled></asp:TextBox>                                                
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Razón Social</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox ID="txtRazonSocial" class="form-control" runat="server" disabled></asp:TextBox>
                                            </div>
                                        </div>
                                    <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Giro</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox ID="txtGiro" class="form-control" runat="server" required></asp:TextBox>
                                            </div>
                                        </div>
                                    <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Dirección</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox ID="txtDireccion" class="form-control" runat="server" required></asp:TextBox>
                                                </div>
                                            </div>
                                    <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Teléfono</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox ID="txtTelefono" class="form-control" runat="server" MaxLength="9" placeholder="Ej: 912345678" onKeyPress="return soloNumeros(event)" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div clas="form-group row">
                                            <div class="col-lg-9">
                                                    <asp:Label ID="lblStatus" runat="server" required></asp:Label>
                                            </div>     
                                        </div>
                                    <div class="form-group row">
                                        <label class="col-lg-3 col-form-label form-control-label"></label>                                       
                                        <div class="col-lg-9">
                                            <a href="Login.aspx" class="btn btn-secondary">Volver</a>
                                            <asp:Button ID="btnCrear" class="btn btn-success" runat="server" Text="Actualizar" OnClick="btnCrear_Click"  />
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <!-- /form user info -->
            </div>
        </div>
    </div>
</asp:Content>
