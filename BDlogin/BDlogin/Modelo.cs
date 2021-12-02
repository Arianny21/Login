using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDlogin
{
    class Modelo
    {

        public Usuarios porUsuarios(String email)
        {
            MySqlDataReader reader;
            MySqlConnection GetConnection = Conexion.GetConnection();
            MySqlConnection conexion = GetConnection;
            conexion.Open();

            String sql = "Select nombre, apellido, email, telefono contraseña FROM usuarios WHERE email LIKE @email";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@email", email);

            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Nombre = reader["Nombre"].ToString();
                usr.Apellido = reader["Apellido"].ToString();
                usr.Telefono = reader["Telefono"].ToString();
                usr.Email = reader["Email"].ToString();
                usr.Contraseña = reader["Contraseña"].ToString();
            }
            return usr;

        }
        
            }

        }

