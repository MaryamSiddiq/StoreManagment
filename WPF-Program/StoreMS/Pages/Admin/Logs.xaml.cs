using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : Page
    {
        // Replace with your actual database connection string
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<ExceptionLogData> exceptionLogs = new List<ExceptionLogData>();

        public Logs()
        {
            InitializeComponent();
            LoadExceptionLogs();
        }

        private void LoadExceptionLogs()
        {
            try
            {
                logsDataGrid.ItemsSource = null;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM [ExceptionLog]", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                exceptionLogs.Add(new ExceptionLogData
                                {
                                    ClassName = row["ClassName"].ToString(),
                                    FunctionName = row["FunctionName"].ToString(),
                                    ErrorMessage = row["ErrorMessage"].ToString(),
                                    LogDate = Convert.ToDateTime(row["LogDate"])
                                });
                            }
                        }
                    }
                    connection.Close();
                }

                logsDataGrid.ItemsSource = exceptionLogs;
                logsDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                // Log the exception in the ExceptionLog table
                Exceptions.LogException(ex, "ExceptionLogsPage.xaml.cs", "LoadExceptionLogs");

                // Handle the exception as needed (e.g., show a message to the user)
                MessageBox.Show($"An error occurred while loading exception logs: {ex.Message}");
            }
        }

        private void txtLogsSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Get the search text from the TextBox
                string searchText = txtLogsSearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = exceptionLogs
                        .Where(item =>
                            (item.ClassName != null && item.ClassName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.FunctionName != null && item.FunctionName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.ErrorMessage != null && item.ErrorMessage.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.LogDate.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();

                    // Update the DataGrid with the filtered data
                    logsDataGrid.ItemsSource = filteredData;
                }
                else if (logsDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    logsDataGrid.ItemsSource = exceptionLogs;
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "ExceptionLogs.xaml.cs", "txtLogsSearch_TextChanged");
                // Handle any exceptions here or add logging as needed
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Search Here..."))
            {
                textBox.Text = "";
            }
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search Here...";
            }
        }
    }

    public class ExceptionLogData
    {
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime LogDate { get; set; }
    }
}
