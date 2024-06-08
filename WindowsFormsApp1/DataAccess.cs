using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DataAccess
    
        {
            public const string CONNECTION_STRING = "Data Source=KATHERINE;Escuela.mdf;Integrated Security=True";

            public const string CADENA_SQL_SERVER = "katherine Server=;Integrated Security=true;Initial Catalog=ALUMNO";
            //ADO.NET
            public List<Alumno> GetAllAdoNet()
            {
                List<Alumno> alumnos = new List<Alumno>();
                try
                {
                    SqlConnection conn = new SqlConnection(CONNECTION_STRING);
                    conn.Open();
                    string query = "SELECT id, nombres, apellidos, carnet, telefono FROM Alumno";
                    SqlCommand sqlCommand = new SqlCommand(query, conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Alumno a = new Alumno
                        {
                            Id = reader.GetInt32(0),
                            Nombres = reader.GetString(1),
                            Apellidos = reader.GetString(2),
                            Carnet = reader.GetString(3),
                            Telefono = reader.GetString(4)
                        };
                        alumnos.Add(a);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return alumnos;
            }

            public List<Alumno> GetAllDapper()
            {
                List<Alumno> alumnos = new List<Alumno>();
                try
                {
                    SqlConnection conn = new SqlConnection(CADENA_SQL_SERVER);
                    conn.Open();
                    string query = "SELECT id, nombres, apellidos, carnet, telefono FROM Alumno";
                    alumnos = conn.Query<Alumno>(query).ToList();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return alumnos;
            }
        }
    }

}
