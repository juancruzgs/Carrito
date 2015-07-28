using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace Carrito
{
    public partial class FormPrincipal : System.Web.UI.Page
    {

        protected string getPrecioOferta()
        {
            if (Eval("PrecioOferta").ToString() != "")
            {
                return String.Format("{0:c}", Eval("PrecioOferta"));
            }
            else
            {
                return "";
            }
        }


        protected string getPrecioNormal()
        {
            if (Eval("PrecioNormal").ToString() != "")
            {
                if (Eval("PrecioOferta").ToString() != "")
                    return "<del>" + String.Format("{0:c}", Eval("PrecioNormal")) + "</del>";
                else
                {
                    return "<span style=\"color:Red;\"><strong>" + String.Format("{0:c}", Eval("PrecioNormal")) + "</strong></span>";
                }
            }
            else
            {
                return "";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Productos productos = new Productos();
                RepeaterItems.DataSource = productos.listarProductosEnOferta();
                RepeaterItems.DataBind();
            }

            Categorias categorias = new Categorias();
            DataTable dtTable = categorias.traerCategorias();

            foreach (DataRow dtRow in dtTable.Rows)
            {
                string desc = dtRow["Descripcion"].ToString();
                Button boton = new Button();
                boton.Text = desc;
                boton.CssClass = "list-group-item";
                boton.Width = 250;
                boton.Click += new EventHandler(this.BtnCategorias_Click);
                PanelCategorias.Controls.Add(boton);
            }
        }


        protected void BtnCategorias_Click(object sender, EventArgs e)
        {

            Button boton = (Button)sender;
            if (boton != null)
            {

                foreach (Control bt in PanelCategorias.Controls)
                {
                    if (bt.GetType() == typeof(Button))
                    {
                        Button btAux = (Button)bt;
                        btAux.CssClass = "list-group-item"; //Sacar la selección a todos los botones
                    }
                }

                Productos oproductos = new Productos();

                boton.CssClass = "list-group-item active"; //Seleccionar el boton clickeado
                RepeaterItems.DataSource = oproductos.listarProductosPorCategoria(boton.Text);
                RepeaterItems.DataBind();
            }
        }


        protected void RepeaterItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                if (User.Identity.IsAuthenticated) //Debe logearse para agregar productos al carrito
                {
                    LabelError.Text = "";
                    int idProducto = Convert.ToInt32(e.CommandArgument);

                    try
                    {
                        PagMaestra master = (PagMaestra)this.Master;
                        master.insertaCarrito(idProducto, 1);
                        master.actualizarCarrito();
                    }
                    catch (SqlException ex)
                    {
                        LabelError.Text = "* " + ex.Message;
                    }
                }
                else
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
    }
}
