using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginColegio2
{
    public partial class Alumno : Form
    {
        private Conexion conexion;

        public Alumno()
        {
            InitializeComponent();
            conexion = new Conexion();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbGenero.Items.Add("Masculino"); // Representa 1 en la base de datos
            cbGenero.Items.Add("Femenino");  // Representa 0 en la base de datos
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string primerNombre = txtNombre.Text;
            string segundoNombre = txtSNombre.Text;
            string primerApellido = txtApellido.Text;
            string segundoApellido = txtSApellido.Text;
            string codigoEstudiante = txtCodigo.Text;
            DateTime fechaNacimiento = dtFecha.Value;  // Aquí obtienes la fecha de nacimiento
            string direccion = txtDireccion.Text;
            DateTime fechaIngreso = DateTime.Now;  // O la fecha que consideres (puedes usar la fecha actual)
                                                   // Asumimos que "Masculino" es true y "Femenino" es false

            // Crear una instancia de EstudianteService
            EstudianteService estudianteService = new EstudianteService();

            // Llamar al método AgregarEstudiante
            try
            {
                estudianteService.AgregarEstudiante(primerNombre, segundoNombre, primerApellido, segundoApellido, codigoEstudiante, fechaNacimiento, direccion, fechaIngreso, cbGenero.SelectedIndex == 1);
                MessageBox.Show("Estudiante agregado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar estudiante: " + ex.Message);
            }

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (((TextBox)x).Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Complete el campo " + ((TextBox)x).Name.Substring(3));
                        return;
                    }
                }
                else if (x is ComboBox)
                {
                    if (((ComboBox)x).SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione el genero del estudiante");
                        return;
                    }
                }
                else if (x is DateTimePicker)
                {
                    if (!ValidateAge())
                    {
                        MessageBox.Show("La edad del estudiante tiene que ser mayor o igual a 0");
                    }
                }
            }
        }

        private bool ValidateAge()
        {
            DateTime fechaNacimiento = dtFecha.Value;
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            return edad >= 0 ? true : false;
        }



    }
}
