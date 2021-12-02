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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textUsuario.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textTelefono.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textContraseña.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();

            String insertar = "INSERT INTO usuarios(ID, NOMBRE, APELLIDO, TELEFONO, EMAIL, CONTRASEÑA)values(@id, @nombre, @apellido, @telefono, @email, @contraseña)";
            MySqlCommand cmd = new MySqlCommand(insertar, cn);

            cmd.Parameters.AddWithValue("@id", textUsuario.Text);
            cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", textApellido.Text);
            cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@contraseña", textContraseña.Text);

            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Los datos fueron agregados exitosamente.");


            dataGridView1.DataSource = llenar_grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            string modificar = "UPDATE usuarios SET ID=@id, NOMBRE=@nombre, APELLIDO=@apellido, TELEFONO=@telefono, EMAIL=@email, CONTRASEÑA=@contraseña WHERE ID=@id";

            MySqlCommand cmd = new MySqlCommand(modificar, cn);

            cmd.Parameters.AddWithValue("@id", textUsuario.Text);
            cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", textApellido.Text);
            cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@contraseña", textContraseña.Text);

            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Datos modificados correctamente");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();

            String eliminar = "DELETE FROM usuarios WHERE ID=@id";

            MySqlCommand cmd = new MySqlCommand(eliminar, cn);
            cmd.Parameters.AddWithValue("@id", textUsuario.Text);
            cmd.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Los datos fueron borrados exitosamente.");

            dataGridView1.DataSource = llenar_grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textUsuario.Clear();
            textNombre.Clear();
            textApellido.Clear();
            textTelefono.Clear();
            textEmail.Clear();
            textContraseña.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form formulario1 = new FormLogin();
            formulario1.Show();
            this.Hide();
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenar_grid();
        }
    }
}
