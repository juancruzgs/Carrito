using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace Carrito
{
    public partial class FormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Usuario ousuario = new Usuario();

            DataTable dt = ousuario.infoUsuario(Login1.UserName, Login1.Password);
            if (dt.Rows.Count != 0)
            {
                Session["Usuario"] = dt.Rows[0][0].ToString();
                Session["Permiso"] = dt.Rows[0][1].ToString();
                Session["Nombre"] = dt.Rows[0][2].ToString();

                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                
            }
        }
    }
}