<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarHuesped.aspx.cs" Inherits="Hostal.WEB.AgregarHuesped" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        Nombre<br />
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        Apellido<br />
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />
        Rut<br />
        <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
        <br />
        Telefono<br />
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
    </asp:Panel>
</asp:Content>
