using MySql.Data.MySqlClient;
using System;

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string server, string database, string user, string password,string port = "3307")
    {
        connectionString = $"Server={server};Database={database};User ID={user};Password={password}; Port={port}";
    }


    /// <summary>
    /// Get a random word and its description from the database.
    /// </summary>
    /// <reurns>Tuple containing the word and description</returns>
    public (string word, string description) GetRandomWord()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Word, description FROM Words ORDER BY RAND() LIMIT 1";
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
