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
    public partial class FormCarrito : System.Web.UI.Page
    {
        Carrito ocarrito;

        protected void actualizarCarrito()
        {
            Button mpButton = (Button)Master.FindControl("BtnCarrito");
            if (mpButton != null)
            {
                mpButton.Text = "Carrito (" + ocarrito.cantidadElementos().ToString() + ")";
            }
        }

       
        protected void Page_Preinit(object sender, EventArgs e) /*Para validar que el usuario este logeado*/
        {
            if (!User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ocarrito = new Carrito(Convert.ToInt32(Session["Usuario"]));

            if (!Page.IsPostBack)
            {
                GridDetalle.DataSource = ocarrito.listarDetalle();
                GridDetalle.DataBind();

                LabelTotal.Text = "TOTAL = $" + string.Format("{0:F2}",ocarrito.totalCarrito() );
            }

        }
      
        protected void GridDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int index = Convert.ToInt32(e.RowIndex); 
            GridViewRow row = GridDetalle.Rows[index];

            int idProducto = Convert.ToInt32(row.Cells[0].Text);
            ocarrito.eliminaProductoDetalle(idProducto);

            GridDetalle.DataSource = ocarrito.listarDetalle();
            GridDetalle.DataBind();

            LabelTotal.Text = "TOTAL = $" + string.Format("{0:F2}", ocarrito.totalCarrito());
            actualizarCarrito();
        }

        protected void GridDetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridDetalle.EditIndex = e.NewEditIndex;
            LabelError.Text = "";
            
            GridDetalle.DataSource = ocarrito.listarDetalle();
            GridDetalle.DataBind();
        }

        protected void GridDetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridDetalle.EditIndex = -1;

            GridDetalle.DataSource = ocarrito.listarDetalle();
            GridDetalle.DataBind();
        }

        protected void GridDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Productos oproducto = new Productos();

            GridViewRow row = GridDetalle.Rows[e.RowIndex];
            TextBox txtCantidad = (TextBox)row.Cells[3].Controls[0];

            try
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int idProducto = Convert.ToInt32(row.Cells[0].Text);
                ocarrito.actualizaCantidad(idProducto, cantidad);
            }
            catch (FormatException) //No se ingreso un número en la cantidad
            {
                LabelError.Text = "* INGRESE UN NÚMERO ENTERO";
            }
            catch (SqlException ex) //Controla que haya stock del producto
            {
                LabelError.Text = "* "+ex.Message;
            }
            finally
            {
                GridDetalle.EditIndex = -1;

                GridDetalle.DataSource = ocarrito.listarDetalle();
                GridDetalle.DataBind();

                LabelTotal.Text = "TOTAL = $" + string.Format("{0:F2}", ocarrito.totalCarrito());
            }
        }

        protected void BtnEliminaCarrito_Click(object sender, EventArgs e)
        {
            ocarrito.eliminaCarrito();

            GridDetalle.DataSource = ocarrito.listarDetalle();
            GridDetalle.DataBind();

            LabelTotal.Text = "TOTAL = $" + string.Format("{0:F2}", ocarrito.totalCarrito());
            actualizarCarrito();

        }

        protected void BtnConfirmaCompra_Click(object sender, EventArgs e)
        {
            Compra ocompra = new Compra();

            ocompra.insertaCompra(Convert.ToInt32(Session["Usuario"]), 10); //$10 de envio 
            ocarrito.eliminaCarrito();

            Response.Redirect("FormPrincipal.aspx");
        }


    }
}