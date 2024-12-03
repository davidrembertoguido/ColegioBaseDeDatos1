using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginColegio2
{
    internal class Conexioncs
    {

        //prueba de git
        private SqlConnection conexion;
        string cadenaConexion = "Server=localhost;Database=ColegioBD;Integrated Security=True;";

        public Conexioncs()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        public SqlConnection ObtenerConexion()
        {
            // Abre la conexión si está cerrada antes de devolverla
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }


        public bool ValidarUsuario(string usuario, string contrasena)
        {
            AbrirConexion();  // Asegura que la conexión esté abierta antes de ejecutar el comando
            using (var comando = new SqlCommand())
            {
                comando.Connection = conexion;
                comando.CommandText = @"select * from Usuario where Nombre = @nombre and CONVERT(nvarchar(max), DECRYPTBYPASSPHRASE('password', Contrasena)) = @contrasena";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@nombre", usuario);
                comando.Parameters.AddWithValue("@contrasena", contrasena);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    return lector.HasRows;
                }
            }
            CerrarConexion(); // Cierra la conexión después de ejecutar el comando
        }

    }
}

