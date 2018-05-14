<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Hostal.WEB.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div>
      Usuario<br />
      <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
      <br />
      Contraseña<br />
      <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
      <br />
      Rut
      <br />
      <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
      <br />
      Razon Social<br />
      <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
      <br />
      Giro<br />
      <asp:TextBox ID="txtGiro" runat="server"></asp:TextBox>
      <br />
      Direccion<br />
      <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
      <br />
      Telefono<br />
      <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Label ID="lblStatus" runat="server"></asp:Label>
      <br />
      <br />
      <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear Cuenta" />
      </br>
  </div>
</asp:Content>
