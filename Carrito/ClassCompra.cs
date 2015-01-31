using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Carrito
{
    public class Compra
    {
        Conexion oconexion = new Conexion();

        public void insertaCompra(int idUsuario, decimal totalEnvio)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@TotalEnvio", totalEnvio);

            oconexion.ejecutarProc("InsertaCompra", parametros);
         

        }
    }
}