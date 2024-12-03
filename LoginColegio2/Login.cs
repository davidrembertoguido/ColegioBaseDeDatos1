using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginColegio2
{
    public partial class Login : Form
    {

        private Conexioncs conexion;

        public Login()
        {
            InitializeComponent();
            conexion = new Conexioncs();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener el usuario y la contraseña de los campos de texto
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContra.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, ingrese un usuario y una contraseña.");
                return;
            }

            try
            {
                // Validar el usuario utilizando el procedimiento almacenado
                conexion.AbrirConexion();
                bool esValido = conexion.ValidarUsuario(usuario, contrasena);

                if (esValido)
                {
                    MessageBox.Show("Bienvenido...");
                    // Redirigir al formulario principal
                    Inicio iniciar = new Inicio();
                    iniciar.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el login: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion(); // Asegurarse de cerrar la conexión
            }
        }
    }
}
