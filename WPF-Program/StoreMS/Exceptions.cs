using System;
using System.Data.SqlClient;

public static class Exceptions
{
    // Replace with your actual database connection string
    private static readonly string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";

    public static void LogException(Exception ex, string className, string functionName)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO [ExceptionLog] (ClassName, FunctionName, ErrorMessage, LogDate) VALUES (@ClassName, @FunctionName, @ErrorMessage, GETDATE())", connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@FunctionName", functionName);
                    command.Parameters.AddWithValue("@ErrorMessage", ex.Message);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
        catch (Exception logException)
        {
            // Handle any exception that might occur during the logging process
            Console.WriteLine($"Error logging exception: {logException.Message}");
        }
    }
}
