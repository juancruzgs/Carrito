<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormPrincipal.aspx.cs" Inherits="Carrito.FormPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
    <link href="css/shop-item.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">

            <div class="col-md-3">
                <p class="lead">Categorías</p>
                <div class="list-group">
                    <asp:Panel ID="PanelCategorias" runat="server">
                    </asp:Panel>
                </div>
            </div>

            <div class="col-md-9">   
                <div class="row">

                    <asp:Repeater ID="RepeaterItems" runat="server" 
                        onitemcommand="RepeaterItems_ItemCommand" EnableViewState="True">
                        <ItemTemplate>
                            <div class="col-sm-4 col-lg-4 col-md-4">
                                <div class="thumbnail" style="height: 450px;">
                                    <img src="<%# Eval("Foto")%>" alt="" style="height : 200px" >
                                    <div class="caption">
                                        <h4 style="color:#337AB7"><%# Eval("Nombre")%></h4>
                                        <p><%# Eval("Descripcion")%></p>
                                        <h4 id="precios">
                                            <span style="color:Red; margin-right: 15px;"><strong><%# getPrecioOferta() %></strong></span><%# getPrecioNormal() %>
                                        </h4>                                                                             
                                        <asp:Button ID="ButtonAgregar" runat="server" Text="Comprar" CssClass="btn btn-success" style="position: absolute; right: 20px; bottom: 25px; width:250px" CommandName="Agregar" CommandArgument='<%# Eval("IdProducto")%>'/>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label>

</asp:Content>
