using System;
using System.Data.SqlClient;

namespace Centralita
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define la cadena de conexión
            string connectionString = "Data Source=IQTEK-VEN-NASHA;Initial Catalog=Centralita;User ID=sa;Password=Masiel2019ea1.";

            // Crea la conexión
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Abre la conexión
                connection.Open();

                // Pide al usuario que introduzca los detalles de la llamada
                Console.WriteLine("Introduzca el número de origen:");
                string numeroOrigen = Console.ReadLine();
                Console.WriteLine("Introduzca el número de destino:");
                string numeroDestino = Console.ReadLine();
                Console.WriteLine("Introduzca la duración de la llamada (en minutos):");
                int duracion = int.Parse(Console.ReadLine());

                // Inserta los detalles de la llamada en la tabla "llamadas"
                string query = "INSERT INTO llamadas (numeroOrigen, numeroDestino, Duracion) VALUES (@numeroOrigen, @numeroDestino, @Duracion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@numeroOrigen", numeroOrigen);
                command.Parameters.AddWithValue("@numeroDestino", numeroDestino);
                command.Parameters.AddWithValue("@duracion", duracion);
                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine("Llamada registrada correctamente. Filas afectadas: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión
                connection.Close();
            }

            Console.ReadKey();
        }
    }
}
