using System;
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
        Producto producto;
        Categoria categoria;

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
            producto = new Producto();
            categoria = new Categoria();

            if (!Page.IsPostBack)
            {
                actualizarGrid();

                ListaNuevaCategoria.DataSource = categoria.listarCategorias();
                ListaNuevaCategoria.DataTextField = "Descripcion";
                ListaNuevaCategoria.DataValueField = "IdCategoria";
                ListaNuevaCategoria.DataBind();
            }
        }


        protected void GridProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList listaCategorias = (e.Row.FindControl("ListaCategorias") as DropDownList);
                listaCategorias.DataSource = categoria.listarCategorias();
                listaCategorias.DataTextField = "Descripcion";
                listaCategorias.DataValueField = "IdCategoria";
                listaCategorias.DataBind();

                string textCategoria = (e.Row.FindControl("TxtCategoria") as Label).Text;
                listaCategorias.Items.FindByText(textCategoria).Selected = true;
            }
        }


        protected void GridProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LabelError.Text = "";

            if (e.CommandName == "Eliminar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);

                try
                {
                    producto.eliminarProducto(idProducto);
                    actualizarGrid();
                }
                catch (SqlException)
                {
                    LabelError.Text = "* El producto ya fue comprado por alguien y no se puede eliminar";
                }
            }
            else if (e.CommandName == "Modificar")
            {
                try
                {
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

                    FileUpload fileUpload = (row.FindControl("FileUploadFoto") as FileUpload);
                    string imgPath = subirArchivo(fileUpload);

                    producto.modificaProducto(idProducto, descripcion, idCategoria, precio, precioOferta, stock, imgPath);
                    actualizarGrid();
                }
                catch (FormatException)
                {
                    LabelError.Text = "* Ingrese números enteros positivos";
                }
                catch (SqlException)
                {
                    LabelError.Text = "* Verifique el precio unitario sea mayor al precio de oferta y los valores sean positivos";
                }
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

                string imgPath = subirArchivo(FileUploadNuevaFoto);

                producto.nuevoProducto(nombre, descripcion, idCategoria, precio, precioOferta, stock, imgPath);
                actualizarGrid();
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


        private void actualizarGrid()
        {
            GridProductos.DataSource = producto.listarProductos();
            GridProductos.DataBind();
        }


        private string subirArchivo(FileUpload fileUpload)
        {
            string imgPath = "";
            if (fileUpload.HasFile == true)
            {
                if (fileUpload.PostedFile.ContentType == "image/jpeg")
                {
                    string imgName = fileUpload.FileName.ToString();
                    imgPath = "/imgs/" + imgName;

                    if (fileUpload.PostedFile != null && fileUpload.PostedFile.FileName != "")
                    {
                        fileUpload.SaveAs(Server.MapPath(imgPath));
                    }
                }
            }
            return imgPath;
        }
    }
}