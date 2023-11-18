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
