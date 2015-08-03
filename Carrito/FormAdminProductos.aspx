<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormAdminProductos.aspx.cs" Inherits="Carrito.FormAdminProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css"> 
        
        .hiddencol
        {
            display : none;
        }
        
    </style>

    <SCRIPT language="javascript">

            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode < 31 || charCode === 44 || charCode === 46 || (charCode >= 48 && charCode <= 57))
                    return true;

                return false;
            }

   </SCRIPT>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div><h1 id="H1">Productos</h1></div>

    <div>
        <asp:GridView ID="GridProductos" runat="server"                 
            AutoGenerateColumns="False" 
            CellPadding="4"
            CssClass="table table-striped table-bordered" 
            onrowcommand="GridProductos_RowCommand" 
            onrowdatabound="GridProductos_RowDataBound">

            <Columns>

                <asp:BoundField DataField="IdProducto" HeaderText="Código" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtDescripcion" runat="server" Text='<%# Eval("Descripcion") %>' >
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Categoria">
                    <ItemTemplate>
                        <asp:Label ID="TxtCategoria" runat="server" Text='<%# Eval("Categoria") %>' Visible = "false" />
                        <asp:DropDownList ID="ListaCategorias" runat="server">
                        </asp:DropDownList>              
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Foto" HeaderText="Foto" />
                <asp:TemplateField HeaderText="Precio Unitario">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPrecioNormal" runat="server" onkeypress="return isNumberKey(event)" Width="100" Text='<%# Eval("PrecioNormal") %>'>
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Oferta">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPrecioOferta" runat="server" Width="100" onkeypress="return isNumberKey(event)" Text='<%# Eval("PrecioOferta") %>' >
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtStock" runat="server" Width="60" Text='<%# Eval("StockActual") %>' TextMode="Number">
                        </asp:TextBox>                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnModificaProducto" runat="server" class="btn btn-success" Text="Modificar" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnEliminaProducto" runat="server" class="btn btn-danger" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdProducto") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            
            </Columns>
        
            <HeaderStyle BackColor="#008AE6" />

        </asp:GridView>
    </div>

    <div>
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>

    <div><h1 id="H2">Nuevo Producto</h1></div>

    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Nombre</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNuevoNombre" runat="server" class="form-control"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Descripcion</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNuevaDescripcion" runat="server" class="form-control"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Categoria</label>
        <div class="col-sm-10" style="width:200px">

            <asp:DropDownList ID="ListaNuevaCategoria" runat="server" class="form-control">
            </asp:DropDownList>   

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Foto</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="Foto" runat="server" class="form-control"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Precio Unitario</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNuevoPrecioUnitario" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Precio Oferta</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNuevoPrecioOferta" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Stock</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNuevoStock" runat="server" class="form-control" TextMode="Number"></asp:TextBox>

        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label"></label>
        <div class="col-sm-10" style="width:200px">

            <asp:Button ID="BtnNuevoProducto" runat="server" Text="Nuevo" 
                class="btn btn-success" onclick="BtnNuevoProducto_Click" />

        </div>   
    </div>

    <br /><br />
    <div>
        <asp:Label ID="LabelErrorNuevo" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
</asp:Content>
