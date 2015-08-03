using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections;

namespace Carrito
{
    public partial class FormCarrito : System.Web.UI.Page
    {
        Carrito carrito;
        PagMaestra master;

        protected void Page_Preinit(object sender, EventArgs e)
        {
            /*Validar que el usuario este logeado*/
            if (!User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = new Carrito(Convert.ToInt32(Session["Usuario"]));
            master = (PagMaestra)this.Master;

            if (!Page.IsPostBack)
            {
                actualizarCarrito();
            }
        }


        protected void GridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarProducto")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                carrito.eliminaProductoDetalle(idProducto);

                actualizarCarrito();
                master.actualizarCarrito();
            }
        }


        protected void BtnEliminaCarrito_Click(object sender, EventArgs e)
        {
            carrito.eliminaCarrito();

            actualizarCarrito();
            master.actualizarCarrito();
        }


        protected void BtnActualizarCarrito_Click1(object sender, EventArgs e)
        {
            try 
            {
                LabelError.Text = "";

                int[] idProductos = new int[GridDetalle.Rows.Count];
                int[] cantidades = new int[GridDetalle.Rows.Count];
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridViewRow row = GridDetalle.Rows[i];

                    idProductos[i] = Convert.ToInt32(row.Cells[0].Text);

                    TextBox txtCantidad = (TextBox)row.FindControl("TxtCantidad");
                    cantidades[i] = Convert.ToInt32(txtCantidad.Text);
                }

                carrito.actualizarCantidades(idProductos, cantidades);
            }
            catch (FormatException)
            {
                LabelError.Text = "* Ingrese un número entero positivo";
            }
            catch (SqlException)
            {
                LabelError.Text = "* No hay stock del producto";
            }
            finally
            {
                actualizarCarrito();
                master.actualizarCarrito();
            }
        }


        protected void BtnConfirmaCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormConfirmaCompra.aspx");
        }


        private void actualizarCarrito()
        {
            GridDetalle.DataSource = carrito.listarDetalle();
            GridDetalle.DataBind();

            decimal total = carrito.totalCarrito();
            if (total > 0)
            {
                LabelTotal.Text = string.Format("{0:c}", carrito.totalCarrito());
            }
            else
            {
                LabelTotalText.Text = "";
                LabelTotal.Text = "";
                TituloCarrito.InnerText = "Su carrito se encuentra vacío";
                BtnActualizarCarrito.Visible = false;
                BtnEliminaCarrito.Visible = false;
                BtnConfirmaCompra.Visible = false;
            }
        }

    }
}