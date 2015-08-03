using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Carrito
{
    public class Categorias
    {
       Conexion oconexion = new Conexion();

       public DataTable traerCategorias()
       {
           string cmdtext = "SELECT * FROM Categorias";
           DataTable dtcategorias = oconexion.leerdatos(cmdtext);
           return dtcategorias;
       }

       public void eliminarCategoria(int idCategoria)
       {
           SqlParameter[] parametros = new SqlParameter[1];
           parametros[0] = new SqlParameter("@IdCategoria", idCategoria);

           oconexion.ejecutarProc("EliminaCategoria", parametros);           
       }


       public void modificarCategoria(int idCategoria, string descripcion) 
       {
           SqlParameter[] parametros = new SqlParameter[2];
           parametros[0] = new SqlParameter("@IdCategoria", idCategoria);
           parametros[1] = new SqlParameter("@Descripcion", descripcion);

           oconexion.ejecutarProc("ModificaCategoria", parametros);         
       }

       public void nuevaCategoria(string descripcion)
       {
           SqlParameter[] parametros = new SqlParameter[1];
           parametros[0] = new SqlParameter("@Descripcion", descripcion);

           oconexion.ejecutarProc("NuevaCategoria", parametros);     
       }
    }
}