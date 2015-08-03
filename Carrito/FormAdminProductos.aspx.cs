﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;

namespace Carrito
{
    public partial class FormAdminProductos : System.Web.UI.Page
    {
        protected void Page_Preinit(object sender, EventArgs e)
        {
            /*Validar que el usuario este logeado y sea Administrador */
            if (!User.Identity.IsAuthenticated && Convert.ToInt32(Session["Permiso"]) != 1)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Productos productos = new Productos();

            if (!Page.IsPostBack)
            {
                GridProductos.DataSource = productos.listarProductos();
                GridProductos.DataBind();

                Categorias categorias = new Categorias();
                ListaNuevaCategoria.DataSource = categorias.traerCategorias();
                ListaNuevaCategoria.DataTextField = "Descripcion";
                ListaNuevaCategoria.DataValueField = "IdCategoria";
                ListaNuevaCategoria.DataBind();
            }
        }

        protected void GridProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);

                Productos productos = new Productos();
                LabelError.Text = "";

                try
                {
                    productos.eliminarProducto(idProducto);
                }
                catch (SqlException)
                {
                    LabelError.Text = "* El producto ya fue comprado por alguien y no se puede eliminar";
                }
                finally
                {
                    GridProductos.DataSource = productos.listarProductos();
                    GridProductos.DataBind();
                }
            }
            else if (e.CommandName == "Modificar")
            {
                Productos productos = new Productos();

                try
                {
                    LabelError.Text = "";

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridProductos.Rows[index];

                    int idProducto = Convert.ToInt32(row.Cells[0].Text);
                    string descripcion = (row.FindControl("TxtDescripcion") as TextBox).Text;
                    int idCategoria = Convert.ToInt32((row.FindControl("ListaCategorias") as DropDownList).SelectedValue);
                    decimal precio = Convert.ToDecimal((row.FindControl("TxtPrecioNormal") as TextBox).Text);

                    string stringOferta = (row.FindControl("TxtPrecioOferta") as TextBox).Text;
                    decimal precioOferta = 0;
                    if (stringOferta != "")
                    {
                        precioOferta = Convert.ToDecimal(stringOferta);
                    }
                    int stock = Convert.ToInt32((row.FindControl("TxtStock") as TextBox).Text);

                    productos.modificaProducto(idProducto, descripcion, idCategoria, precio, precioOferta, stock);
                }
                catch (FormatException)
                {
                    LabelError.Text = "* Ingrese números enteros positivos";
                }
                catch (SqlException)
                {
                    LabelError.Text = "* Verifique el precio unitario sea mayor al precio de oferta y los valores sean positivos";
                }
                finally
                {
                    GridProductos.DataSource = productos.listarProductos();
                    GridProductos.DataBind();
                }
            }
        }

        protected void GridProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Categorias categorias = new Categorias();

                //Find the DropDownList in the Row
                DropDownList listaCategorias = (e.Row.FindControl("ListaCategorias") as DropDownList);
                listaCategorias.DataSource = categorias.traerCategorias();
                listaCategorias.DataTextField = "Descripcion";
                listaCategorias.DataValueField = "IdCategoria";
                listaCategorias.DataBind();

                //Select the Country of Customer in DropDownList
                string country = (e.Row.FindControl("TxtCategoria") as Label).Text;
                listaCategorias.Items.FindByText(country).Selected = true;
            }
        }

        protected void BtnNuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                LabelErrorNuevo.Text = "";

                string nombre = TxtNuevoNombre.Text;
                string descripcion = TxtNuevaDescripcion.Text;
                int idCategoria = Convert.ToInt32(ListaNuevaCategoria.SelectedValue);
                decimal precio = Convert.ToDecimal(TxtNuevoPrecioUnitario.Text);

                string stringOferta = TxtNuevoPrecioOferta.Text;
                decimal precioOferta = 0;
                if (stringOferta != "")
                {
                    precioOferta = Convert.ToDecimal(stringOferta);
                }
                int stock = Convert.ToInt32(TxtNuevoStock.Text);

                Productos productos = new Productos();
                productos.nuevoProducto(nombre, descripcion, idCategoria, precio, precioOferta, stock);

                GridProductos.DataSource = productos.listarProductos();
                GridProductos.DataBind();
            }
            catch (FormatException)
            {
                LabelErrorNuevo.Text = "* Ingrese números enteros positivos";
            }
            catch (SqlException)
            {
                LabelErrorNuevo.Text = "* Verifique el precio unitario sea mayor al precio de oferta y los valores sean positivos";
            }
        }
    }
}