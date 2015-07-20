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
        Carrito ocarrito;

        protected string getPrecioOferta()
        {
            if (Eval("PrecioOferta").ToString() != "")
            {
                return "$" + String.Format("{0:f2}", Eval("PrecioOferta"));
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
                    return "<del>$" + String.Format("{0:f2}", Eval("PrecioNormal")) + "</del>";
                else
                {
                    return "<span style=\"color:Red;\">$" + String.Format("{0:f2}", Eval("PrecioNormal")) + "</span>";
                }
            }
            else
            {
                return "";
            }
        }


        protected void actualizarCarrito()
        {
            Button mpButton = (Button)Master.FindControl("BtnCarrito");
            if (mpButton != null)
            {
                mpButton.Text = "Carrito (" + ocarrito.cantidadElementos().ToString() + ")";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Productos oproductos = new Productos();
                RepeaterItems.DataSource = oproductos.traerProductosEnOferta();
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

            if (User.Identity.IsAuthenticated)
            {
                ocarrito = new Carrito(Convert.ToInt32(Session["Usuario"]));
                actualizarCarrito();
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
                //GridView1.DataSource = oproductos.traerProductosPorCategoria(boton.Text);
                //GridView1.DataBind();

                boton.CssClass = "list-group-item active"; //Seleccionar el boton clickeado
                RepeaterItems.DataSource = oproductos.traerProductosPorCategoria(boton.Text);
                RepeaterItems.DataBind();
            }

        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Agregar")
        //    {
        //        if (User.Identity.IsAuthenticated) //Debe logearse para agregar productos al carrito
        //        {
        //            LabelError.Text = "";

        //            int index = Convert.ToInt32(e.CommandArgument);
        //            GridViewRow row = GridView1.Rows[index];
        //            int IdProducto = Convert.ToInt32(row.Cells[2].Text);

        //            try
        //            {
        //                ocarrito.insertaCarrito(IdProducto, 1);
        //                actualizarCarrito();
        //            }
        //            catch (SqlException ex)
        //            {
        //                LabelError.Text = "* " + ex.Message;
        //            }
        //        }
        //        else
        //        {
        //            FormsAuthentication.RedirectToLoginPage();
        //        }

        //    }
        //}


        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

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
                        ocarrito.insertaCarrito(idProducto, 1);
                        actualizarCarrito();
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
