using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Carrito
{
    public partial class PagMaestra : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            BtnCerrarSesion.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            BtnIniciaSesion.Visible = !HttpContext.Current.User.Identity.IsAuthenticated;
            LabelBienvenida.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            BtnCarrito.Visible = HttpContext.Current.User.Identity.IsAuthenticated; 

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                LabelBienvenida.Text = LabelBienvenida.Text + " " + Session["Nombre"].ToString() + "!";        
            }
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("FormPrincipal.aspx");
        }

        protected void BtnIniciaSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void BtnCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCarrito.aspx");
        }
    }
}