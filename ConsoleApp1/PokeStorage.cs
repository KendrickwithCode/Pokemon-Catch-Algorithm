using System;
using Microsoft.Data.Sqlite;

namespace ConsoleApp1
{
    public class PokeStorage
    {
        private string connectionString;

        public PokeStorage(string databaseFilePath)
        {
            connectionString = $"Data Source ={databaseFilePath}";
        }

        public void CreateStorage()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS CaughtPokemon (
                    Number INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    HP INTEGER NOT NULL,
                    Status TEXT NOT NULL
                )";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SavePokemon(Pokemon pokemon)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                INSERT or IGNORE INTO CaughtPokemon (Number, Name, HP, Status)
                VALUES (@Number, @Name, @HP, @Status)";

                using (var command = new SqliteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Number", pokemon.PokedexNo);
                    command.Parameters.AddWithValue("@Name", pokemon.PokemonName);
                    command.Parameters.AddWithValue("@HP", pokemon.Hitpoints);
                    command.Parameters.AddWithValue("@Status", pokemon.Status.Name);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}