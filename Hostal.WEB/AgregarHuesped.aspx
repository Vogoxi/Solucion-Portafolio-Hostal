<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarHuesped.aspx.cs" Inherits="Hostal.WEB.AgregarHuesped" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function soloNumeros(e){
        var key = window.Event ? e.which : e.keyCode
        return (key >= 48 && key <= 57)
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div class="container py-3">
            <div class="row">
                <div class="mx-auto col-sm-6">
                            <!-- form user info -->
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Registrar Nuevo Huesped</h4>
                                </div>
                                <div class="card-body">
                                    <form class="form" role="form">
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Nombre</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox class="form-control" ID="txtNombre" runat="server" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Apellido</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox class="form-control" ID="txtApellido" runat="server" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Rut</label>
                                            <div class="col-lg-9">
                                                <asp:TextBox class="form-control" ID="txtRut" runat="server" required MaxLength="9"></asp:TextBox>
                                                <small id="txtRutHelp" class="form-text text-muted">Sin puntos ni guión</small>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Teléfono</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox class="form-control" ID="txtTelefono" runat="server" onKeyPress="return soloNumeros(event)" placeholder="Ej: 912345678"  MaxLength="9" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label"></label>
                                            <asp:Label ID="lblStatus1" runat="server" required></asp:Label>
                                            <div class="col-lg-9">
                                                <a href="login.php" class="btn btn-secondary">Cancelar</a>
                                                <input type="submit" class="btn btn-success" value="Agregar" />
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                            <!-- /form user info -->
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
