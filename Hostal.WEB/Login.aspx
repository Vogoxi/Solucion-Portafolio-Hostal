<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hostal.WEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round">
<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
<link rel="Stylesheet" href="css/StyleSheet.css" type="text/css" />
    <title>Iniciar Sesion</title>
</head>
<body>
        <div class="container">
            <div class="wrapper">
                    <form id="form1" class="form-signin" runat="server"> 
                            <div>
                                <asp:Login ID="LoginPanel" style="margin-left: 25px" runat="server" DisplayRememberMe="False" FailureText="Usuario y/o contraseña incorrectos" LoginButtonText="Ingresar" OnAuthenticate="LoginPanel_Authenticate" PasswordLabelText="Contraseña:" PasswordRequiredErrorMessage="Se requiere contraseña" UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Se requiere usuario" Height="254px" Width="276px">
                                    <LayoutTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td align="center" class="form-signin-heading"><h4>¡Bienvenido!</h4>             
                                                                <hr class="colorgraph"/>
                                                                <h4>Iniciar Sesión</h4>
                                                            </td>                       
                                                        </tr>                                                    
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="UserName" placeholder="Usuario" class="form-control" runat="server" Width="100%" Height="20%" required></asp:TextBox>                                                            
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <asp:TextBox ID="Password" placeholder="Contraseña" class="form-control" runat="server" TextMode="Password" Width="100%" Height="70%
                                                                    " required></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="color:Red;">
                                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>      
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Button ID="LoginButton" class="btn btn-lg btn-primary btn-block" runat="server" CommandName="Login" Text="Ingresar" ValidationGroup="LoginPanel" />
                                                            </br>
                                                                <center><a href="SignUp.aspx">Registrarse</a></center>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:Login>
                            </div>
                    </form>
            </div>
        </div>
</body>
</html>
