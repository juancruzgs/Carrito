using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Carrito
{
    public class Productos
    {
        Conexion oconexion = new Conexion();

        public DataTable listarProductos()
        {
            string cmdtext = "SELECT p.IdProducto, c.Descripcion AS Categoria, p.Nombre, p.Descripcion, p.PrecioNormal, p.PrecioOferta, p.StockActual, p.Foto " +
                "FROM Productos p JOIN Categorias c on c.IdCategoria=p.IdCategoria";
            DataTable dtProductos = oconexion.leerdatos(cmdtext);
            return dtProductos;
        }

        public DataTable listarProductosPorCategoria(int idCategoria)
        {
            string cmdtext = "SELECT p.IdProducto,p.Nombre,p.Descripcion,p.PrecioNormal,p.PrecioOferta,p.Foto "+
             "FROM Productos p JOIN Categorias c on c.IdCategoria=p.IdCategoria WHERE c.IdCategoria="+idCategoria;
            DataTable dtProductos = oconexion.leerdatos(cmdtext);
            return dtProductos;
        }

        public DataTable listarProductosPorCategoria(string descripcionCategoria)
        {
            string cmdtext = "SELECT p.IdProducto,p.Nombre,p.Descripcion,p.PrecioNormal,p.PrecioOferta,p.Foto " +
             "FROM Productos p JOIN Categorias c on c.IdCategoria=p.IdCategoria WHERE c.Descripcion='" + descripcionCategoria+'\'';
            DataTable dtProductos = oconexion.leerdatos(cmdtext);
            return dtProductos;
        }

        public DataTable listarProductosEnOferta()
        {
            string cmdtext = "SELECT IdProducto,Nombre,Descripcion,PrecioNormal,PrecioOferta,Foto " +
             "FROM Productos WHERE PrecioOferta IS NOT NULL";
            DataTable dtProductos = oconexion.leerdatos(cmdtext);
            return dtProductos;
        }

        public void eliminarProducto(int idProducto)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdProducto", idProducto);

            oconexion.ejecutarProc("EliminaProducto", parametros);    
        }

        public void modificaProducto(int idProducto, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int stock)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@IdProducto", idProducto);
            parametros[1] = new SqlParameter("@Descripcion", descripcion);
            parametros[2] = new SqlParameter("@IdCategoria", idCategoria);
            parametros[3] = new SqlParameter("@PrecioNormal", precio);

            if (precioOferta == 0)
            {
                parametros[4] = new SqlParameter("@PrecioOferta", DBNull.Value);
            }
            else
            {
                parametros[4] = new SqlParameter("@PrecioOferta", precioOferta);
            }

            parametros[5] = new SqlParameter("@Stock", stock);

            oconexion.ejecutarProc("ModificaProducto", parametros);             
        }

        public void nuevoProducto(string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int stock)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@Nombre", nombre);
            parametros[1] = new SqlParameter("@Descripcion", descripcion);
            parametros[2] = new SqlParameter("@IdCategoria", idCategoria);
            parametros[3] = new SqlParameter("@PrecioNormal", precio);

            if (precioOferta == 0)
            {
                parametros[4] = new SqlParameter("@PrecioOferta", DBNull.Value);
            }
            else
            {
                parametros[4] = new SqlParameter("@PrecioOferta", precioOferta);
            }

            parametros[5] = new SqlParameter("@Stock", stock);

            oconexion.ejecutarProc("NuevoProducto", parametros);    
        }
    }
}