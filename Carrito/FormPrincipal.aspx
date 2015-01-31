<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="FormPrincipal.aspx.cs" Inherits="Carrito.FormPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
        <link href="css/shop-item.css" rel="stylesheet" />
        
        <style type="text/css">
            
            .list-group-item {
              color: #555;
            }
            .list-group-item .list-group-item-heading {
              color: #333;
            }
            .list-group-item:hover,
            .list-group-item:focus {
              color: #555;
              text-decoration: none;
              background-color: #f5f5f5;
            }
            
        </style>

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

                    <asp:Repeater ID="RepeaterItems" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-4 col-lg-4 col-md-4">
                                <div class="thumbnail" style="height: 450px;">
                                    <img src="<%# Eval("Foto")%>" alt="">
                                    <div class="caption">
                                        <h4 style="color:#337AB7"><%# Eval("Nombre")%></h4>
                                        <p><%# Eval("Descripcion")%></p>
                                        <div style="position: absolute; right: 50px; bottom: 50px;">
                                        <h4 class="pull-right"><%# getPrecioNormal() %></h4>
                                        <h4 class="pull-right" style="color:Red; padding-right:15px"><strong><%# getPrecioOferta() %></strong></h4>
                                        </div>
                                        <asp:Button ID="ButtonAgregar" runat="server" Text="Comprar" CssClass="btn btn-success" style="position: absolute; right: 20px; bottom: 25px; width:250px" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

            </div>

        </div>

    </div>

    <div>

        <asp:GridView ID="GridView1" runat="server" style="width: 73px" 
            onrowcommand="GridView1_RowCommand" AutoGenerateColumns="False" 
            BorderStyle="Solid" GridLines="Vertical" Font-Bold="True" 
            Font-Size="Large" onselectedindexchanged="GridView1_SelectedIndexChanged">

            <Columns>

                <asp:ButtonField ButtonType="Button" Text="Agregar a Carrito" 
                    CommandName="Agregar" ControlStyle-Width="150px" 
                    ControlStyle-CssClass="botoncarrito" >
                    <ControlStyle CssClass="botoncarrito" Width="150px"></ControlStyle>
                </asp:ButtonField>

                <asp:ImageField DataImageUrlField="Foto" HeaderText="Imagen"></asp:ImageField>
                <asp:BoundField DataField="IdProducto" HeaderText="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="PrecioNormal" HeaderText="Precio Normal" 
                    DataFormatString="$ {0:F2}" ItemStyle-Wrap="False" ItemStyle-Width="100px" >
                    <ItemStyle Wrap="False" Width="100px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="PrecioOferta" HeaderText="Precio Oferta" 
                    DataFormatString="$ {0:F2}" ItemStyle-Wrap="False" ItemStyle-Width="100px" >
                    <ItemStyle Wrap="False" Width="100px"></ItemStyle>
                </asp:BoundField>

            </Columns>
           
            <HeaderStyle BackColor="#008AE6" />
           
        </asp:GridView>
        
        <asp:Label ID="LabelError" runat="server" CssClass="labelerror"></asp:Label>

    </div>

</asp:Content>
