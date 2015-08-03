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
    public partial class FormAdminCategorias : System.Web.UI.Page
    {
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
            categoria = new Categoria();

            if (!Page.IsPostBack)
            {
                actualizarGrid();
            }
        }


        protected void GridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LabelError.Text = "";

            if (e.CommandName == "Eliminar")
            {
                int idCategoria = Convert.ToInt32(e.CommandArgument);

                try
                {
                    categoria.eliminarCategoria(idCategoria);
                    actualizarGrid();
                }
                catch (SqlException)
                {
                    LabelError.Text = "* No se puedo eliminar la categoría porque tiene productos asignados a ella";
                }
            }
            else if (e.CommandName == "Modificar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridCategorias.Rows[index];

                    int idCategoria = Convert.ToInt32(row.Cells[0].Text);
                    string descripcion = (row.FindControl("TxtDescripcion") as TextBox).Text;

                    categoria.modificarCategoria(idCategoria, descripcion);
                    actualizarGrid();
                }
                catch (SqlException)
                {
                    LabelError.Text = "* No se puedo realizar la operación solicitada";
                }
            }
        }

        protected void BtnNuevaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                LabelErrorNuevo.Text = "";

                string descripcion = TxtNuevaDescripcion.Text;

                categoria.nuevaCategoria(descripcion);
                actualizarGrid();
            }
            catch (SqlException)
            {
                LabelErrorNuevo.Text = "* Verifique el precio unitario sea mayor al precio de oferta y los valores sean positivos";
            }
        }


        private void actualizarGrid()
        {
            GridCategorias.DataSource = categoria.listarCategorias();
            GridCategorias.DataBind();
        }
    }
}