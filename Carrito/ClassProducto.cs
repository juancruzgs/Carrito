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

        public DataTable traerProductosPorCategoria(int idCategoria)
        {
            string cmdtext = "SELECT p.IdProducto,p.Nombre,p.Descripcion,p.PrecioNormal,p.PrecioOferta,p.Foto "+
             "FROM Productos p JOIN Categorias c on c.IdCategoria=p.IdCategoria WHERE c.IdCategoria="+idCategoria;
            DataTable dtcategorias = oconexion.leerdatos(cmdtext);
            return dtcategorias;
        }

        public DataTable traerProductosPorCategoria(string descripcionCategoria)
        {
            string cmdtext = "SELECT p.IdProducto,p.Nombre,p.Descripcion,p.PrecioNormal,p.PrecioOferta,p.Foto " +
             "FROM Productos p JOIN Categorias c on c.IdCategoria=p.IdCategoria WHERE c.Descripcion='" + descripcionCategoria+'\'';
            DataTable dtcategorias = oconexion.leerdatos(cmdtext);
            return dtcategorias;
        }

        public DataTable traerProductosEnOferta()
        {
            string cmdtext = "SELECT IdProducto,Nombre,Descripcion,PrecioNormal,PrecioOferta,Foto " +
             "FROM Productos WHERE PrecioOferta IS NOT NULL";
            DataTable dtcategorias = oconexion.leerdatos(cmdtext);
            return dtcategorias;
        }
        
    }
}