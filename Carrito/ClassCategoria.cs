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

    }
}