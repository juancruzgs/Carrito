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
    public partial class FormConfirmaCompra : System.Web.UI.Page
    {
        Carrito carrito;
        Compra compra;
        private static decimal ENVIO = 10;

        protected void Page_Preinit(object sender, EventArgs e)
        {
            /*Validar que el usuario este logeado*/
            if (!User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            } 
            else 
            {
                carrito = new Carrito(Convert.ToInt32(Session["Usuario"]));
                if (carrito.totalCarrito() == 0)
                {
                    Response.Redirect("FormPrincipal.aspx");
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            compra = new Compra();

            if (!Page.IsPostBack)
            {
                GridDetalle.DataSource = carrito.listarDetalle();
                GridDetalle.DataBind();

                LabelEnvio.Text = string.Format("{0:c}", ENVIO);
                LabelTotal.Text = string.Format("{0:c}", carrito.totalCarrito() + ENVIO);
            }
        }

        protected void BtnConfirmaCompra_Click(object sender, EventArgs e)
        {
            try
            {
                LabelError.Text = "";

                string tarjeta = ListaTipo.SelectedValue;
                int tarjetaNumero = Convert.ToInt32(TxtNumero.Text);

                compra.insertaCompra(Convert.ToInt32(Session["Usuario"]), ENVIO, tarjeta, tarjetaNumero); //$10 de envio 
                carrito.eliminaCarrito();

                Response.Redirect("FormPrincipal.aspx");
            }
            catch (FormatException)
            {
                LabelError.Text = "* El número de tarjeta sólo puede contener caracteres númericos";
            }
            catch (SqlException)
            {
                LabelError.Text = "* No se pudo realizar la transacción";
            }
        }
    }
}