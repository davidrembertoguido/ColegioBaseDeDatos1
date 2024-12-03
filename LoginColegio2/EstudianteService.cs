using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoginColegio2
{
    internal class EstudianteService
    {
        private Conexion conexion;

        public EstudianteService()
        {
            conexion = new Conexion();
        }

        public void AgregarEstudiante(string pNombre, string sNombre, string pApellido, string sApellido, string codigoEstudiante, DateTime fechaNacimiento, string direccion, DateTime fechaIngreso, bool genero)
        {
            string consulta = "AgregarEstudiante"; // Procedimiento almacenado

            // Asegúrate de abrir la conexión solo si está cerrada
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros con los nombres correctos que están en la base de datos
                    cmd.Parameters.AddWithValue("@PNombre", pNombre);
                    cmd.Parameters.AddWithValue("@SNombre", sNombre);
                    cmd.Parameters.AddWithValue("@PApellido", pApellido);
                    cmd.Parameters.AddWithValue("@SApellido", sApellido);
                    cmd.Parameters.AddWithValue("@CodigoEstudiante", codigoEstudiante);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Fecha_Ingreso", fechaIngreso);
                    cmd.Parameters.AddWithValue("@Genero", genero);

                    // Ejecutamos el procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }

}

