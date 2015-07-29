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

        public void insertaCompra(int idUsuario, decimal totalEnvio, string tarjeta, int tarjetaNumero)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@IdUsuario", idUsuario);
            parametros[1] = new SqlParameter("@TotalEnvio", totalEnvio);
            parametros[2] = new SqlParameter("@Tarjeta", tarjeta);
            parametros[3] = new SqlParameter("@TarjetaNumero", tarjetaNumero);

            oconexion.ejecutarProc("InsertaCompra", parametros);
        }
    }
}