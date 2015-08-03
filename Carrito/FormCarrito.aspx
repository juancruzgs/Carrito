<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormCarrito.aspx.cs" Inherits="Carrito.FormCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css"> 
        
        .hiddencol
        {
            display : none;
        }
        
    </style>

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
                        <asp:TextBox ID="TxtCantidad" runat="server" Width="60" TextMode="Number" Text='<%# Eval("Cantidad") %>' >
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PrecioLista" HeaderText="Precio Unitario" DataFormatString="{0:c}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:c}" />
                <asp:BoundField DataField="TotalIva" HeaderText="Total IVA" DataFormatString="{0:c}" />
                <asp:BoundField DataField="PrecioFinal" HeaderText="Precio Final" DataFormatString="{0:c}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnEliminaProducto" runat="server" class="btn btn-danger" Text="Eliminar" CommandName="EliminarProducto" CommandArgument='<%# Eval("IdProducto") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>
    </div>

    <div>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" CssClass="labeltotaltext" Text="Total: "></asp:Label> 
            <asp:Label ID="LabelTotal" runat="server" CssClass="labeltotal"></asp:Label>
        </strong>
    </div>

    <div>
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
        
    <div style="margin-top: 30px">
        <asp:Button ID="BtnEliminaCarrito" runat="server"
                Text="Eliminar Carrito" class="btn btn-danger" onclick="BtnEliminaCarrito_Click" />
    
        <asp:Button ID="BtnActualizarCarrito" runat="server" style="margin-left: 15px; margin-right: 15px;"
                Text="Actualizar" class="btn btn-success" onclick="BtnActualizarCarrito_Click1" />

         <asp:Button ID="BtnConfirmaCompra" runat="server" Text="Confirmar Compra" 
                class="btn btn-success" onclick="BtnConfirmaCompra_Click"  />
    </div>

</asp:Content>
