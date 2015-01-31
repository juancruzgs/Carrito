<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormCarrito.aspx.cs" Inherits="Carrito.FormCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="height: 32px">

        <asp:Button ID="BtnEliminaCarrito" runat="server"
                Text="Eliminar Carrito" CssClass="eliminacarrito" 
            onclick="BtnEliminaCarrito_Click" Width="127px" />

    </div><br />

    <div>

        <asp:GridView ID="GridDetalle" runat="server" 
                onrowdeleting="GridDetalle_RowDeleting" AutoGenerateColumns="False" 
                onrowcancelingedit="GridDetalle_RowCancelingEdit" 
                onrowediting="GridDetalle_RowEditing" onrowupdating="GridDetalle_RowUpdating"
                BorderStyle="Solid" GridLines="Vertical" Font-Bold="True" 
                Font-Size="Large">

            <Columns>

                <asp:BoundField DataField="IdProducto" HeaderText="Código" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                    ReadOnly="True" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioLista" HeaderText="Precio Unitario" ReadOnly="True" DataFormatString="$ {0:F2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" 
                    DataFormatString="$ {0:F2}" ItemStyle-Wrap="True" ReadOnly="True" >
                    <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="TotalIva" HeaderText="Total IVA" ReadOnly="True" DataFormatString="$ {0:F2}" />
                <asp:BoundField DataField="PrecioFinal" HeaderText="Precio Final" 
                    ReadOnly="True" DataFormatString="$ {0:F2}" />
                <asp:CommandField ShowEditButton="True" EditText="Modificar Cantidad" UpdateText="Aceptar" />
                <asp:CommandField ShowDeleteButton="True" DeleteText=" Eliminar Producto" />
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>

    </div>

    <div style="height: 31px">
        
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 

    </div>

    <div style="height: 47px">

        <asp:Label ID="LabelTotal" runat="server" CssClass="labeltotal"></asp:Label> <br />

    </div>

    <div>

     <asp:Button ID="BtnConfirmaCompra" runat="server" Text="Confirmar Compra" 
            CssClass="eliminacarrito" onclick="BtnConfirmaCompra_Click" 
            Width="148px" />

    </div>
</asp:Content>
