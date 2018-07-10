<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CuponHostal.aspx.cs" Inherits="Hostal.WEB.CuponHostal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server">
        <asp:ScriptManager EnablePageMethods="True" runat="server"></asp:ScriptManager>
        <div class="container py-3">
            <div class="row">
                <div class="mx-auto col-sm-12">
                            <!-- form user info -->
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="mb-0">Muchas Gracias Por Su Reserva</h4>
                                </div>
                                <div class="card-body">
                                <embed src="#" width="1000" height="600" type='application/pdf' runat="server" id="pdfPreview"/>
                                </div>
                                </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <script src="../js/Datatables/jquery.dataTables.min.js"></script>
</asp:Content>
