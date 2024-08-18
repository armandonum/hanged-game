using MySql.Data.MySqlClient;
using System;

public class DatabaseHelper
{
    private readonly string connectionString;

    public DatabaseHelper()
    {
        string server="localhost";
        string database="hangman_db";
         string user="root";
          string password="";
           string port = "3307";

        connectionString = $"Server={server};Database={database};User ID={user};Password={password}; Port={port}";

    }

    public (string word, string description) GetRandomWord()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Word, Description FROM Words ORDER BY RAND() LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (reader.GetString(0), reader.GetString(1));
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"MySQL error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        return (null, null);
    }
}
