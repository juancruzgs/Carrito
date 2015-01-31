using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //Conexion a base de datos
using System.Data.SqlClient;

namespace Carrito
{
    public class Carrito
    {
        Conexion oconexion = new Conexion();
        int idUsuario;

        public Carrito(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }
       
        public void insertaCarrito(int idProducto, int cantidad)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@IdProducto", idProducto);
            parametros[2] = new SqlParameter("@Cantidad", cantidad);

            try
            {
            oconexion.ejecutarProc("InsertaDetalle", parametros);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int cantidadElementos()
        {
            string cmd = "SELECT COUNT(*) FROM CarritoDetalle cd JOIN Carrito c on c.IdCarrito=cd.IdCarrito WHERE c.IdUsuario='" + idUsuario + "'";

            int resultado = Convert.ToInt32(oconexion.ejecutarescalar(cmd));
            return resultado;
        }

        public DataTable listarDetalle()
        {
            string cmd = "SELECT p.IdProducto,p.Nombre,p.Descripcion,cd.Cantidad,cd.PrecioLista,cd.Subtotal,cd.TotalIva,cd.PrecioFinal"+
                        " FROM CarritoDetalle cd JOIN Carrito c on c.IdCarrito=cd.IdCarrito JOIN Productos p on p.IdProducto=cd.IdProducto"+
                        " WHERE c.IdUsuario='" + idUsuario + "'";
            DataTable dtdetalle = oconexion.leerdatos(cmd);
           
            return dtdetalle;
        }

        public void eliminaProductoDetalle(int idProducto)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@IdProducto", idProducto);
           
            oconexion.ejecutarProc("EliminaProductoDetalle", parametros);
        }

        public void actualizaCantidad(int idProducto, int cantidad)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@IdProducto", idProducto);
            parametros[2] = new SqlParameter("@Cantidad", cantidad);

            try
            {
                oconexion.ejecutarProc("ActualizaCantidad", parametros);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void eliminaCarrito()
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);

            oconexion.ejecutarProc("EliminaCarrito", parametros);
        }

        public decimal totalCarrito()
        {
            string cmd = "SELECT Total FROM Carrito WHERE IdUsuario='" + idUsuario + "'";

            decimal resultado=Convert.ToDecimal( oconexion.ejecutarescalar(cmd));
            return resultado;
        }
    }
}