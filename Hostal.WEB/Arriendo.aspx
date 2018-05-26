<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Arriendo.aspx.cs" Inherits="Hostal.WEB.Arriendo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server">
            <asp:DropDownList ID="ddlHuespedes" runat="server">
            </asp:DropDownList>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
