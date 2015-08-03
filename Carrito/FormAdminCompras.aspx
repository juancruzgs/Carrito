<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormAdminCompras.aspx.cs" Inherits="Carrito.FormAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div><h1 id="H1">Ordenes de Compra</h1></div>

    <div>
        <asp:GridView ID="GridCompras" runat="server"                 
            AutoGenerateColumns="False" 
            CellPadding="4"
            CssClass="table table-striped table-bordered" 
            onrowcommand="GridCompras_RowCommand" >

            <Columns>

                <asp:BoundField DataField="IdCompra" HeaderText="IdCompra" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:c}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnDetalle" runat="server" class="btn btn-primary" Text="Detalle" CommandName="Detalle" CommandArgument='<%# Eval("IdCompra") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnConfirmar" runat="server" class="btn btn-success" Text="Confirmar Compra" CommandName="Confirmar" CommandArgument='<%# Eval("IdCompra") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>
    </div>

    <div><h1 id="H2">Detalle de Compra</h1></div>

    <div>
        <asp:GridView ID="GridDetalle" runat="server"                 
            AutoGenerateColumns="False" 
            CellPadding="4"
            CssClass="table table-striped table-bordered" >

            <Columns>

                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:c}" />
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>
    </div>
</asp:Content>
