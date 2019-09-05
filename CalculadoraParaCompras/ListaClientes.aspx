<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="CalculadoraParaCompras.ListaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="form-group cont-clientes">
            <asp:DropDownList ID="listaClients" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="listaClients" CssClass="mgValidate" ErrorMessage="Selecione un cliente"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" />
        </div>

    <div class="cont-totalCompras">

        <asp:ListBox ID="lstTotalcompras" runat="server"></asp:ListBox>

    </div>
</asp:Content>
