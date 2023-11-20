using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StoreMS.Pages.Admin
{
    public partial class Logs : Page
    {
        List<LogData> logs = new List<LogData>();

        public Logs()
        {
            InitializeComponent();

            // Assume you have a list of logs, replace this with your actual data
            logs = new List<LogData>
            {
                new LogData { ClassName = "ClassName1", FunctionName = "FunctionName1", ErrorMessage = "Error 1", LogDate = DateTime.Now },
                new LogData { ClassName = "ClassName2", FunctionName = "FunctionName2", ErrorMessage = "Error 2", LogDate = DateTime.Now },
                // Add more log data as needed
            };

            // Sort the logs by LogDate in descending order
            logs = logs.OrderByDescending(log => log.LogDate).ToList();

            logsDataGrid.ItemsSource = logs;
        }

        string text = null;
        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Search Here..."))
            {
                text = textBox.Text;
                textBox.Text = "";
            }
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
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
                    var filteredData = logs.Where(log =>
                        (log.ClassName != null && log.ClassName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (log.FunctionName != null && log.FunctionName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (log.ErrorMessage != null && log.ErrorMessage.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        log.LogDate.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 // Convert to string before checking
                    ).ToList();

                    // Update the DataGrid with the filtered data
                    logsDataGrid.ItemsSource = filteredData;
                }
                else if (logsDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    logsDataGrid.ItemsSource = logs;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
            }
        }
    }

    public class LogData
    {
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime LogDate { get; set; }
        // Additional properties for Logs can be added here
    }
}
