<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DatosUsuario.aspx.cs" Inherits="Hostal.WEB.DatosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="js/main.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container py-3">
                <div class="row">
                    <div class="mx-auto col-sm-6">
                                <!-- form user info -->
                                <div class="card">
                                    <div class="card-header">
                                        <center><h4 class="mb-0">Datos Usuario</h4></center>
                                    </div>
                                    <div class="card-body">
                                        <form class="form" role="form">
                                            <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Usuario</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox ID="txtUsuario"  class="form-control" runat="server" disabled></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Contraseña Nueva</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox type="password" ID="txtPassword" class="form-control" runat="server" required></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Repetir Contraseña Nueva</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox type="password" ID="txtRepPassword" class="form-control" runat="server" required></asp:TextBox>
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
                                                    <asp:Button ID="btnCrear" class="btn btn-success" runat="server" Text="Actualizar" OnClick="btnCrear_Click" />
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
