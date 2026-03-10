using System;
using System.Data.SQLite;

namespace MySQLiteApp.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public SQLiteDataReader ExecuteReader(string query)
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public void BeginTransaction()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    // Transaction logic goes here
                    transaction.Commit();
                }
            }
        }
    }
}