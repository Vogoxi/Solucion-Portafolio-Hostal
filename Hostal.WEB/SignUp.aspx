<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Hostal.WEB.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <!-- <style>
  @media (min-width: 1200px) {
    .container{
        max-width: 970px;
    }
  }
  </style> -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container">
      <div class="form-group row">
          <label class="col-sm-2 col-form-label">Nombre de Usuario</label>
          <div class="col-sm-3">
              <asp:TextBox ID="txtUsuario"  class="form-control" runat="server"></asp:TextBox>
          </div>
      </div>
      <div class="form-group row">
        <label class="col-sm-2 col-form-label">Contraseña</label>
        <div class="col-sm-3">
            <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
        </div>   
      </div>
      <div class="form-group row">
          <label class="col-sm-2 col-form-label">Rut</label>
          <div class="col-sm-3">
              <asp:TextBox ID="txtRut" class="form-control" runat="server"></asp:TextBox>
          </div>   
      </div>
      <div class="form-group row">
          <label class="col-sm-2 col-form-label">Razón Social</label>
          <div class="col-sm-3">
              <asp:TextBox ID="txtRazonSocial" class="form-control" runat="server"></asp:TextBox>
          </div>    
      </div>
      <div class="form-group row">
          <label class="col-sm-2 col-form-label">Giro</label>
          <div class="col-sm-3">
              <asp:TextBox ID="txtGiro" class="form-control" runat="server"></asp:TextBox>
          </div>
      </div>
      <div class="form-group row">
          <label class="col-sm-2 col-form-label">Dirección</label>
          <div class="col-sm-3">
              <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
          </div>    
      </div>
      <div class="form-group row">
          <label class="col-sm-2 col-form-label">Telefono</label>
          <div class="col-sm-3">
              <asp:TextBox ID="txtTelefono" class="form-control" runat="server"></asp:TextBox>
          </div>    
      </div>
      <br />
      <asp:Label ID="lblStatus" class="col-sm-2 col-form-label" runat="server"></asp:Label>
      <br />
      <asp:Button ID="btnCrear" runat="server" class="btn btn-success" OnClick="btnCrear_Click" Text="Crear Cuenta" />
    </br>
  </div>
</asp:Content>
