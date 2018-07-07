<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Hostal.WEB.SignUp" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <!-- <style>
  @media (min-width: 1200px) {
    .container{
        max-width: 970px;
    }
  }
  </style> -->
  <script src="js/main.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container py-3">
        <div class="row">
            <div class="mx-auto col-sm-6">
                        <!-- form user info -->
                        <div class="card">
                            <div class="card-header">
                                <h4 class="mb-0">Nuevo Usuario</h4>
                            </div>
                            <div class="card-body">
                                <form class="form" role="form">
                                    <div class="form-group row">
                                        <label class="col-lg-3 col-form-label form-control-label">Usuario</label>
                                        <div class="col-lg-9">
                                                <asp:TextBox ID="txtUsuario"  class="form-control" runat="server" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-3 col-form-label form-control-label">Contraseña</label>
                                        <div class="col-lg-9">
                                                <asp:TextBox type="password" ID="txtPassword" class="form-control" runat="server" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-3 col-form-label form-control-label">Repetir Contraseña</label>
                                        <div class="col-lg-9">
                                                <asp:TextBox type="password" ID="txtRepPassword" class="form-control" runat="server" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-3 col-form-label form-control-label">Rut</label>
                                        <div class="col-lg-9">
                                                <asp:TextBox ID="txtRut" class="form-control" runat="server" required MaxLength="9"></asp:TextBox>
                                                <small id="txtRutHelp" class="form-text text-muted">Sin puntos ni guión</small>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Razón Social</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox ID="txtRazonSocial" class="form-control" runat="server" required></asp:TextBox>
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
                                            <asp:Button ID="btnCrear" class="btn btn-success" runat="server" Text="Registrar" OnClick="btnCrear_Click" />
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
