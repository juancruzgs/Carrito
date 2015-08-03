<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormAdminCategorias.aspx.cs" Inherits="Carrito.FormAdminCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css"> 
        
        .hiddencol
        {
            display : none;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div><h1 id="H1">Categorías</h1></div>

    <div>
        <asp:GridView ID="GridCategorias" runat="server"                 
            AutoGenerateColumns="False" 
            CellPadding="4"
            CssClass="table table-striped table-bordered" 
            onrowcommand="GridCategorias_RowCommand" >

            <Columns>

                <asp:BoundField DataField="IdCategoria" HeaderText="Código" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescripcion" runat="server" Text='<%# Eval("Descripcion") %>' >
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnModificaCategoria" runat="server" class="btn btn-success" Text="Modificar" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnEliminaCategoria" runat="server" class="btn btn-danger" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdCategoria") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>
    </div>

    <div>
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>

    <div><h1 id="H2">Nueva Categoría</h1></div>

    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Descripcion</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNuevaDescripcion" runat="server" class="form-control"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label"></label>
        <div class="col-sm-10" style="width:200px">

            <asp:Button ID="BtnNuevaCategoria" runat="server" Text="Nuevo" 
                class="btn btn-success" onclick="BtnNuevaCategoria_Click" />

        </div>   
    </div>

    <br /><br />
    <div>
        <asp:Label ID="LabelErrorNuevo" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
</asp:Content>
