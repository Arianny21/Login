using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDlogin
{
    public partial class FormRegistrarse : Form
    {
        public FormRegistrarse()
        {
            InitializeComponent();
        }

        static string conexion = "SERVER=127.0.0.1; PORT=3306; DATABASE=bdlogin1; UID=root; PASSWORD=;";
        MySqlConnection cn = new MySqlConnection(conexion);

        public DataTable llenar_grid()
        {
            cn.Open();
            DataTable dt = new DataTable();
            String llenar = "Select * from usuarios";
            MySqlCommand cmd = new MySqlCommand(llenar, cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();

            return dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                cn.Open();

            String insertar = "INSERT INTO usuarios( NOMBRE, APELLIDO, TELEFONO, EMAIL, CONTRASEÑA)values(@nombre, @apellido, @telefono, @email, @contraseña)";
            MySqlCommand cmd = new MySqlCommand(insertar, cn);

            cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", textApellido.Text);
            cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@contraseña", textContra.Text);

            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Los datos fueron agregados exitosamente.");
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            Form IniciarSesion = new FormLogin();
            IniciarSesion.Show();
            this.Hide();
        }
    }
}
