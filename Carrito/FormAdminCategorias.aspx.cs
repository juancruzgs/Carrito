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
            Categoria categorias = new Categoria();

            if (!Page.IsPostBack)
            {
                GridCategorias.DataSource = categorias.listarCategorias();
                GridCategorias.DataBind();
            }
        }

        protected void GridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Categoria categorias = new Categoria();

            if (e.CommandName == "Eliminar")
            {
                LabelError.Text = "";

                int idCategoria = Convert.ToInt32(e.CommandArgument);

                try
                {
                    categorias.eliminarCategoria(idCategoria);
                }
                catch (SqlException)
                {
                    LabelError.Text = "* No se puedo eliminar la categoría porque tiene productos asignados a ella";
                }
                finally
                {
                    GridCategorias.DataSource = categorias.listarCategorias();
                    GridCategorias.DataBind();
                }
            }
            else if (e.CommandName == "Modificar")
            {
                try
                {
                    LabelError.Text = "";

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridCategorias.Rows[index];

                    int idCategoria = Convert.ToInt32(row.Cells[0].Text);
                    string descripcion = (row.FindControl("TxtDescripcion") as TextBox).Text;

                    categorias.modificarCategoria(idCategoria, descripcion);
                }
                catch (SqlException)
                {
                    LabelError.Text = "* No se puedo realizar la operación solicitada";
                }
                finally
                {
                    GridCategorias.DataSource = categorias.listarCategorias();
                    GridCategorias.DataBind();
                }
            }
        }

        protected void BtnNuevaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                LabelErrorNuevo.Text = "";

                string descripcion = TxtNuevaDescripcion.Text;

                Categoria categorias = new Categoria();
                categorias.nuevaCategoria(descripcion);

                GridCategorias.DataSource = categorias.listarCategorias();
                GridCategorias.DataBind();
            }
            catch (SqlException)
            {
                LabelErrorNuevo.Text = "* Verifique el precio unitario sea mayor al precio de oferta y los valores sean positivos";
            }
        }
    }
}