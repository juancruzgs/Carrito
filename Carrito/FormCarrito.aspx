<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormCarrito.aspx.cs" Inherits="Carrito.FormCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css"> 
        
        .hiddencol
        {
            display : none;
        }
        
    </style>
    
    <SCRIPT language=Javascript>
           function isNumberKey(evt) {
               var charCode = (evt.which) ? evt.which : event.keyCode
               if (charCode > 31 && (charCode < 48 || charCode > 57))
                   return false;

               return true;
           }
   </SCRIPT>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div><h1 id="TituloCarrito" runat="server">Carrito de Compras</h1></div>

    <div>
        <asp:GridView ID="GridDetalle" runat="server"                 
            AutoGenerateColumns="False" 
            CellPadding="4"
            CssClass="table table-striped table-bordered" 
            onrowcommand="GridDetalle_RowCommand">

            <Columns>

                <asp:BoundField DataField="IdProducto" HeaderText="Código" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtCantidad" runat="server" Width="40" onkeypress="return isNumberKey(event)" Text='<%# Eval("Cantidad") %>' >
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PrecioLista" HeaderText="Precio Unitario" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:c}" />
                <asp:BoundField DataField="TotalIva" HeaderText="Total IVA" DataFormatString="{0:c}" />
                <asp:BoundField DataField="PrecioFinal" HeaderText="Precio Final" DataFormatString="{0:c}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnEliminaProducto" runat="server" Text="Eliminar" CommandName="EliminarProducto" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                    </ItemTemplate>
                </asp:TemplateField>
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>
    </div>

    <div>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Total: "></asp:Label> 
            <asp:Label ID="LabelTotal" runat="server" CssClass="labeltotal"></asp:Label>
        </strong>
    </div>

    <div>
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
        
    <div style="height: 32px">
        <asp:Button ID="BtnEliminaCarrito" runat="server"
                Text="Eliminar Carrito" CssClass="eliminacarrito" 
            onclick="BtnEliminaCarrito_Click" Width="127px" />
    </div><br />
    
    <div style="height: 32px">
        <asp:Button ID="BtnActualizarCarrito" runat="server"
                Text="Actualizar" CssClass="eliminacarrito" 
            Width="127px" onclick="BtnActualizarCarrito_Click1" />
    </div><br />

    <div>
     <asp:Button ID="BtnConfirmaCompra" runat="server" Text="Confirmar Compra" 
            CssClass="eliminacarrito" onclick="BtnConfirmaCompra_Click" 
            Width="148px" />
    </div>

</asp:Content>
