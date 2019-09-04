<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CalculadoraParaCompras.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>
        Calculadora para compras 
    </h1>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="txtNombre"  ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" CssClass="alert alert-primary" ErrorMessage="Este campo es necesario"></asp:RequiredFieldValidator>
    <div class="cajaItems form-group">
        <input id="Button1" type="button" onclick="AddItem()" class="btn btn-dark" value="Agregar producto" />

    </div>
    <div class="cajaTotales">
        Total :<!-- <asp:Label ID="lblTotal" runat="server" Text="---"></asp:Label>--> 
       <asp:TextBox ID="txtTotal" runat="server" CssClass="txtTotal" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnGuarda" class="btn btn-primary" runat="server" Text="Guardar total de compra" OnClick="btnGuarda_Click" />
    </div>
    <script>
        let txtTotal = document.getElementById("MainContent_txtTotal")
        function AddItem() {
            $(".cajaItems").append(" <br/>");
            $(".cajaItems").append(" <input type='text' class='nombreProudcto' placeholder='Nombre del producto'>");
            $(".cajaItems").append(" <input type='number' class='cantidad' placeholder='Cant' onkeyup='CalculatotalItem(this)' >");
            $(".cajaItems").append(" <input type='number' class='precio' placeholder='Prec' onkeyup='CalculatotalItem(this)' >");
            $(".cajaItems").append("<label class='totalItem'> &nbsp; --- &nbsp; </label>");
            $(".cajaItems").append("<input id='Button1' type='button' onclick='AddItem()' class='btn btn - dark' value='+' />")
        }
        function CalculatotalItem(elemento) {
            let lstlbl = document.getElementsByClassName("totalItem")
            let totalitem = 0;
            let totalDeitems = 0;
            if (elemento.className == 'cantidad') {
                totalitem = elemento.value * elemento.nextSibling.nextSibling.value
                //console.log("precui",elemento.nextSibling.nextSibling.value)
                if (!isNaN(totalitem)) {
                    elemento.nextSibling.nextSibling.nextSibling.innerText = totalitem
                    
                }
            } else if (elemento.className == 'precio') {
                totalitem = elemento.previousSibling.previousSibling.value * elemento.value
                //console.log("cantidad",elemento.previousSibling.previousSibling.value)
                if (!isNaN(totalitem)) {
                    elemento.nextSibling.innerText = totalitem
                } 

            }

            for (i = 0; i < lstlbl.length; i++) {
                   totalDeitems = totalDeitems + parseInt(  lstlbl[i].innerHTML)
            }
            txtTotal.value = totalDeitems


        }
    </script>
</asp:Content>
