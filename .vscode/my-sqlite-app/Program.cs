using System;

namespace MySQLiteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the database connection
            DatabaseHelper dbHelper = new DatabaseHelper();

            // Example of how to use the DatabaseHelper
            try
            {
                dbHelper.Connect();
                Console.WriteLine("Database connection established.");

                // Here you can add logic to interact with the database
                // e.g., dbHelper.ExecuteQuery("SELECT * FROM ExampleTable");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                dbHelper.Disconnect();
                Console.WriteLine("Database connection closed.");
            }
        }
    }
}