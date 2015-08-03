<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormCarrito.aspx.cs" Inherits="Carrito.FormCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <asp:RequiredFieldValidator ID="RequiredCantidad" runat="server" ControlToValidate="TxtCantidad" SetFocusOnError="True" Text="*" ForeColor="Red" Display="Dynamic" ValidationGroup="Grid" ErrorMessage="Complete la Cantidad"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeCantidad" runat="server" ControlToValidate="TxtCantidad" SetFocusOnError="True" Text="*" ForeColor="Red" MinimumValue="1" MaximumValue="9999" ValidationGroup="Grid" ErrorMessage="Ingrese una Cantidad positiva"></asp:RangeValidator>                
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

    <br />
    <div>
        <asp:ValidationSummary ID="SummaryGrid" runat="server" ValidationGroup="Grid" ForeColor="Red" />
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
        
    <div style="margin-top: 30px">
        <asp:Button ID="BtnEliminaCarrito" runat="server"
                Text="Eliminar Carrito" class="btn btn-danger" onclick="BtnEliminaCarrito_Click" />
    
        <asp:Button ID="BtnActualizarCarrito" runat="server" style="margin-left: 15px; margin-right: 15px;"
                Text="Actualizar" class="btn btn-success" onclick="BtnActualizarCarrito_Click1" ValidationGroup="Grid" />

         <asp:Button ID="BtnConfirmaCompra" runat="server" Text="Confirmar Compra" 
                class="btn btn-success" onclick="BtnConfirmaCompra_Click"  />
    </div>

</asp:Content>
