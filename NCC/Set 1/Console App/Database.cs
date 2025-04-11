using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Set1
{
    public static class DatabaseDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- ADO.NET Database Connection ---\n");

            string connectionString = "Server=localhost;Database=mydb2;User Id=root;Password=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Employee Records:\n");
                        Console.WriteLine("ID\tName\t\tSalary");
                        Console.WriteLine("----------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}\t{reader["Name"]}\t{reader["Salary"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- End of ADO.NET Database Connection ---");
        }
    }
}
