using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDlogin
{
    class Conexion
    {
        public static MySqlConnection GetConnection()
        {
            string CadenaConexion = "SERVER=127.0.0.1; PORT=3306; DATABASE=bdlogin1; UID=root; PASSWORD=;";
         MySqlConnection conexion = new MySqlConnection(CadenaConexion);

            return conexion;
        }

    }
}
