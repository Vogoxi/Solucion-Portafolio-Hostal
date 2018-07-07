<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Hostal.WEB.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/main.js"></script>
    <style>
    body {
        background: url(https://www.eurotel.cl/img/01.jpg) no-repeat center center fixed; 
        -webkit-background-size: cover;
        -moz-background-size: cover;
        -o-background-size: cover;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-3">
            <div class="row">
                <div class="mx-auto col-sm-6">
                            <!-- form user info -->
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Nuevo Usuario</h4>
                                </div>
                                <div class="card-body">
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Usuario</label>
                                            <div class="col-lg-9">                               
                                                <asp:TextBox ID="txtUsuario"  class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtUsuario" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Contraseña</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox type="password" ID="txtPassword" class="form-control" runat="server" ControlToCompare="txtPassword"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_contrasenia" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Repetir Contraseña</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox type="password" ID="txtRepPassword" class="form-control" runat="server"></asp:TextBox>
                                                <asp:CompareValidator ID="cv_RepPass" runat="server" ErrorMessage="*Las contraseñas deben ser iguales" ControlToCompare="txtPassword" ControlToValidate="txtRepPassword" ForeColor="Red"></asp:CompareValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label">Rut</label>
                                            <div class="col-lg-9">
                                                    <asp:TextBox ID="txtRut" class="form-control" runat="server" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv_rut" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtRut" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <small id="txtRutHelp" class="form-text text-muted">Sin puntos y con guión</small>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Razón Social</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox ID="txtRazonSocial" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv_razonSocial" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtRazonSocial" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Giro</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox ID="txtGiro" class="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_giro" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtGiro" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        <div class="form-group row">
                                                    <label class="col-lg-3 col-form-label form-control-label">Dirección</label>
                                                    <div class="col-lg-9">
                                                            <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtDireccion" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                        <div class="form-group row">
                                                <label class="col-lg-3 col-form-label form-control-label">Teléfono</label>
                                                <div class="col-lg-9">
                                                        <asp:TextBox ID="txtTelefono" class="form-control" runat="server" MaxLength="9" placeholder="Ej: 912345678" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_telefono" runat="server" ErrorMessage="*Obligatorio" ControlToValidate="txtTelefono" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-lg-9">
                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                </div>     
                                            </div>
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label form-control-label"></label>
                                            
                                            <div class="col-lg-9">
                                                <a href="Login.aspx" class="btn btn-secondary">Volver</a>
                                                <asp:Button ID="btnCrear" class="btn btn-success" runat="server" Text="Registrar" OnClick="btnCrear_Click" />
                                            </div>
                                        </div>
                                </div>
                            </div>
                            <!-- /form user info -->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
