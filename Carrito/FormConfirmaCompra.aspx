<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormConfirmaCompra.aspx.cs" Inherits="Carrito.FormConfirmaCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <div><h1 id="TituloCarrito">Resumen de Compra</h1></div>

    <div>
        <asp:GridView ID="GridDetalle" runat="server"                 
            AutoGenerateColumns="False" 
            CellPadding="4"
            CssClass="table table-striped table-bordered">

            <Columns>

                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioFinal" HeaderText="Precio Final" DataFormatString="{0:c}" />
         
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

    <br /><br />
    
    <div><h1 id="H1">Datos de Tarjeta</h1></div>

    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Tarjeta</label>
        <div class="col-sm-10" style="width:200px">

            <asp:DropDownList ID="ListaTipo" runat="server" class="form-control">
                <asp:ListItem>VISA</asp:ListItem>
                <asp:ListItem>MASTERCARD</asp:ListItem>
            </asp:DropDownList>

        </div>   
    </div>
    
    <br />
    <div class="form-group">
        <label class="col-sm-1 control-label">Número</label>
        <div class="col-sm-10" style="width:200px">

            <asp:TextBox id="TxtNumero" runat="server" class="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>

        </div>   
    </div>

    <br /><br />
        <div class="form-group">
        <label class="col-sm-1 control-label"></label>
        <div class="col-sm-10" style="width:200px">

            <asp:Button ID="BtnConfirmaCompra" runat="server" Text="Confirmar" 
                class="btn btn-success" onclick="BtnConfirmaCompra_Click"   />

        </div>   
    </div>

    <div>
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label> 
    </div>
</asp:Content>