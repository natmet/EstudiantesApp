using MySql.Data.MySqlClient;
using System;

namespace EstudiantesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int opcion = 0;
            do
            {
                Console.WriteLine("Estudiantes Base de Datos");
                Console.WriteLine("Selecciona una opcion");
                Console.WriteLine("1. Listar Datos");
                Console.WriteLine("2. Insertar Datos");
                Console.WriteLine("0. Salir ");
         
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {

                    case 1:
                        consultar();
                        break;

                    case 2:
                        insertar();
                        break;

                    default:
                        Console.WriteLine("Digite una opcion valida");
                            break;

                }

            } while (opcion != 0);
                                   
        }

        public static void consultar()
        {

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
                    
                    Console.WriteLine("ID:"+lector[0] + " Nombre:" + lector[1] + "   Apellido:" + lector[2] + "   Sexo:" + lector[3] + "   Ciudad:" + lector[4]);
                }
                lector.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            Console.WriteLine(" ");

        }

        public static void insertar() {

            string connStr = "server=localhost;user=root;database=estudiantes;port=3307;password=toor";


            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Conectandose a la base de datos Mysql...");

                conn.Open();

                Console.WriteLine("Digite el id");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite el Nombre");
                var nombre = Console.ReadLine();

                Console.WriteLine("Digite el apellido");
                var apellido = Console.ReadLine();

                Console.WriteLine("Digite el sexo");
                var sexo = Console.ReadLine();

                Console.WriteLine("Digite el direccion");
                var direccion = Console.ReadLine();

                string sql = $"INSERT INTO estudiante VALUES ('{id}','{nombre}','{apellido}', '{sexo}', '{direccion}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                Console.WriteLine(" ");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

    }
}