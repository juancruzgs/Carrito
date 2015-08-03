<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormAdminProductos.aspx.cs" Inherits="Carrito.FormAdminProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                <asp:TemplateField HeaderText="Foto">
                    <ItemTemplate>
                        <asp:FileUpload ID="FileUploadFoto" runat="server">
                        </asp:FileUpload>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Unitario">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPrecioNormal" runat="server" onkeypress="return isNumberKey(event)" Width="100" Text='<%# Eval("PrecioNormal") %>'>
                        </asp:TextBox>  
                        <asp:RequiredFieldValidator ID="RequiredGridPrecio" runat="server" ControlToValidate="TxtPrecioNormal" SetFocusOnError="True" Text="*" ForeColor="Red" ValidationGroup="Grid" ErrorMessage="Complete el Precio Unitario"></asp:RequiredFieldValidator>              
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Oferta">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtPrecioOferta" runat="server" Width="100" onkeypress="return isNumberKey(event)" Text='<%# Eval("PrecioOferta") %>' >
                        </asp:TextBox>  
                        <asp:CompareValidator ID="CompareGridPrecios" runat="server" SetFocusOnError="True" Text="*" ForeColor="Red" ControlToValidate="TxtPrecioOferta" ControlToCompare="TxtPrecioNormal" Operator="LessThan" ValidationGroup="Grid" ErrorMessage="El precio unitario debe ser mayor al precio de oferta"></asp:CompareValidator>              
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stock">
                    <ItemTemplate>
                        <asp:TextBox ID="TxtStock" runat="server" Width="60" Text='<%# Eval("StockActual") %>' TextMode="Number">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredGridStock" runat="server" ControlToValidate="TxtStock" SetFocusOnError="True" Text="*" ForeColor="Red" Display="Dynamic" ValidationGroup="Grid" ErrorMessage="Complete el Stock"></asp:RequiredFieldValidator>                
                        <asp:RangeValidator ID="RangeGidrStock" runat="server" ControlToValidate="TxtStock" SetFocusOnError="True" Text="*" ForeColor="Red" MinimumValue="0" MaximumValue="9999" ValidationGroup="Grid" ErrorMessage="El stock debe ser positivo" ViewStateMode="Inherit"></asp:RangeValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnModificaProducto" runat="server" class="btn btn-success" Text="Modificar" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' ValidationGroup="Grid" />
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
        <asp:ValidationSummary ID="SummaryGrid" runat="server" ValidationGroup="Grid" ForeColor="Red" />
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>

    <div><h1 id="H2">Nuevo Producto</h1></div>

    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Nombre</label>
        <div class="col-sm-10" style="width:200px">
            <asp:TextBox id="TxtNuevoNombre" runat="server" class="form-control"></asp:TextBox>            
        </div>  
        <asp:RequiredFieldValidator ID="RequiredNombre" runat="server" ControlToValidate="TxtNuevoNombre" SetFocusOnError="True" Text="* Complete el Nombre" ForeColor="Red" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
    </div>
    <br />
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
                <asp:FileUpload ID="FileUploadNuevaFoto" runat="server">
                </asp:FileUpload>
        </div>   
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Precio Unitario</label>
        <div class="col-sm-10" style="width:200px">
            <asp:TextBox id="TxtNuevoPrecioUnitario" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
        </div>   
        <asp:RequiredFieldValidator ID="RequiredPrecio" runat="server" ControlToValidate="TxtNuevoPrecioUnitario" SetFocusOnError="True" Text="* Complete el Precio" ForeColor="Red" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
    </div>
    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Precio Oferta</label>
        <div class="col-sm-10" style="width:200px">
            <asp:TextBox id="TxtNuevoPrecioOferta" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
        </div>   
        <asp:CompareValidator ID="ComparePrecios" runat="server" SetFocusOnError="True" Text="* El precio unitario debe ser mayor al precio de oferta" ForeColor="Red" ControlToValidate="TxtNuevoPrecioOferta" ControlToCompare="TxtNuevoPrecioUnitario" Operator="LessThan" ValidationGroup="Nuevo"></asp:CompareValidator>
    </div>
    <br /><br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Stock</label>
        <div class="col-sm-10" style="width:200px">
            <asp:TextBox id="TxtNuevoStock" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
        </div>   
        <asp:RequiredFieldValidator ID="RequiredStock" runat="server" ControlToValidate="TxtNuevoStock" SetFocusOnError="True" Text="* Complete el Stock" ForeColor="Red" Display="Dynamic" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeStock" runat="server" ControlToValidate="TxtNuevoStock" SetFocusOnError="True" Text="* Ingrese un número positivo" ForeColor="Red" MinimumValue="0" MaximumValue="9999" ValidationGroup="Nuevo"></asp:RangeValidator>
    </div>
    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label"></label>
        <div class="col-sm-10" style="width:200px">
            <asp:Button ID="BtnNuevoProducto" runat="server" Text="Nuevo" 
                class="btn btn-success" onclick="BtnNuevoProducto_Click" ValidationGroup="Nuevo" />
        </div>   
    </div>

    <br /><br />
    <div>
        <asp:Label ID="LabelErrorNuevo" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
</asp:Content>
