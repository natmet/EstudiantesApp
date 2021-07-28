using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesApp
{
    class Consultas
    {
        public void consultar() {

            string connStr = "server=localhost;user=root;database=estudiantes;port=3307;password=toor";


            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Conectandose a la base de datos Mysql...");
                conn.Open();

                string sql = "select * from estudiante limit 0,10;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader lector = cmd.ExecuteReader();


                while (lector.Read())
                {
                    Console.WriteLine(lector[0] + " -- " + lector[1] + " -- " + lector[2]);
                }
                lector.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            Console.WriteLine("Cerrando conexion...");
            Console.Read();
        }
    }
}
