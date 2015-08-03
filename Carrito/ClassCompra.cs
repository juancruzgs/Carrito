using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Carrito
{
    public class Compra
    {
        Conexion oconexion = new Conexion();

        public void insertaCompra(int idUsuario, decimal totalEnvio, string tarjeta, int tarjetaNumero)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@TotalEnvio", totalEnvio);
            parametros[2] = new SqlParameter("@Tarjeta", tarjeta);
            parametros[3] = new SqlParameter("@TarjetaNumero", tarjetaNumero);

            oconexion.ejecutarProc("InsertaCompra", parametros);
        }


        public DataTable listarCompras()
        {
            string cmd = "SELECT IdCompra,Fecha,Subtotal + TotalEnvio AS Total FROM Compras WHERE Estado='P'";
            DataTable dtdetalle = oconexion.leerdatos(cmd);

            return dtdetalle;
        }


        public DataTable compraDetalle(int idCompra)
        {
            string cmd = "SELECT p.Nombre,c.Cantidad,c.Subtotal + c.TotalIVA AS Total" + 
            " FROM ComprasDetalle c JOIN Productos p on c.IdProducto=p.IdProducto WHERE c.IdCompra=" + idCompra;
            DataTable dtdetalle = oconexion.leerdatos(cmd);

            return dtdetalle;
        }


        public void confirmarCompra(int idCompra)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdCompra", idCompra);

            oconexion.ejecutarProc("ConfirmaCompra", parametros);       
        }
    }
}