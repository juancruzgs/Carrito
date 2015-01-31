using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Carrito
{
    public class Usuario
    {
        Conexion oconexion = new Conexion();


        public DataTable infoUsuario(string nombreUsuario, string contraseña)
        {
            string cmd = "SELECT IdUsuario,Permiso,NombreUsuario FROM Usuario WHERE NombreUsuario='" + nombreUsuario + "' and Contraseña='" + contraseña + "'";
            DataTable dt = oconexion.leerdatos(cmd);
            return dt;
        }

    }
}