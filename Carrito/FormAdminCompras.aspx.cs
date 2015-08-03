using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Carrito
{
    public partial class FormAdministrador : System.Web.UI.Page
    {
        Compra compra;

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
            compra = new Compra();

            if (!Page.IsPostBack)
            {
                GridCompras.DataSource = compra.listarCompras();
                GridCompras.DataBind();
            }
        }


        protected void GridCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCompra = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Confirmar")
            {
                compra.confirmarCompra(idCompra);
                GridCompras.DataSource = compra.listarCompras();
                GridCompras.DataBind();
            }
            else if (e.CommandName == "Detalle")
            {
                GridDetalle.DataSource = compra.compraDetalle(idCompra);
                GridDetalle.DataBind();
            }
        }
    }
}