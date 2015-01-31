using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //Conexion a base de datos
using System.Data.SqlClient;

namespace Carrito
{
    public class Conexion
    {

        SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ProgC;Integrated Security=True");
         

            public void conectar()
            {
                if (cn.State == ConnectionState.Open)
                    throw new Exception("Conexión abierta");

                cn.Open();
            }

            public void desconectar()
            {
                if (cn.State == ConnectionState.Closed)
                    throw new Exception("Conexión cerrada");
                cn.Close();
            }

            public DataTable leerdatos(string cmdtext)
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(cmdtext, cn);
                conectar();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                desconectar();
                return dt;
            }

            public void ejecutarsql(string cmdtext)
            {
                SqlCommand cmd = new SqlCommand(cmdtext, cn);
                conectar();
                cmd.ExecuteNonQuery();
                desconectar();
            }

            public object ejecutarescalar(string cmdtext)
            {
                SqlCommand cmd = new SqlCommand(cmdtext, cn);
                conectar();
                object resultado = cmd.ExecuteScalar();
                desconectar();
                return resultado;
            }

            public void ejecutarProc(string nombreSP, SqlParameter[] parametros)
            {
                SqlCommand cmd = new SqlCommand(nombreSP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parametros)
                    cmd.Parameters.Add(p);
                conectar();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    desconectar();
                }
            }
        
    }

   
}