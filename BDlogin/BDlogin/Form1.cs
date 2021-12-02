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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            String usuario, contra;
            usuario = textUsuarioLogin.Text;
            contra = textContraLogin.Text;

            if (usuario == "tana@gmail.com" && contra == "12345678")
            {
                FormUsuarios ausuarios = new FormUsuarios();
                ausuarios.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ingrese datos validos o por favor, registrese");
            }
        }

            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            Form Registrar = new FormRegistrarse();
            Registrar.Show();
            this.Hide();
        }

        
        }
    }
