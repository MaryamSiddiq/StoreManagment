using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        List<CustomerData> customers = new List<CustomerData>();

        public Customers()
        {
            InitializeComponent();

            // Sample customer data
            customers = new List<CustomerData>
            {
                new CustomerData { Name = "John Doe", Email = "john@example.com", LoyaltyPoints = 100 },
                new CustomerData { Name = "Jane Smith", Email = "jane@example.com", LoyaltyPoints = 50 },
                // Add more customer data as needed
            };

            // Sort customers by name
            customers = customers
                .OrderBy(customer => customer.Name)
                .ToList();

            customerDataGrid.ItemsSource = customers;
        }
        string text = null;
        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Enter the "))
            {
                text = textBox.Text;
                textBox.Text = "";
            }
            if (textBox.Text.StartsWith("Search Here..."))
            {
                text = textBox.Text;
                textBox.Text = "";
            }
        }
        private void btnAddCustomer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                customerIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd2.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnAddCustomer_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                customerIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtAdd.Foreground = (Brush)FindResource("TextSecundaryColor");
                txtAdd2.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }
        private void btnAddCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic to add a new customer
            // You may open a dialog for user input and add the new customer to the 'customers' list
        }
        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
            }
            if (txtCustomerSearch.Text.Length <= 0)
                txtCustomerSearch.Text = "Search Here...";
        }        
        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected in the DataGrid
            if (customerDataGrid.SelectedItem != null)
            {
                // Get the selected item
                var selectedCustomer = (CustomerData)customerDataGrid.SelectedItem;
                MessageBox.Show(selectedCustomer.Name);
                // Implement your edit logic here. For example, open a dialog to edit the selected customer.
                // You can pass the selectedCustomer to the dialog for editing.

                // After editing, you may need to refresh the DataGrid to reflect the changes.
                // You can do this by reassigning the data source or manually updating the selected customer in the DataGrid.
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.");
            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your logic to delete the selected customer
            // You may want to show a confirmation dialog before deleting
        }
        
        private void txtCustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Get the search text from the TextBox
                string searchText = txtCustomerSearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = customers.Where(customer =>
                        (customer.Name != null && customer.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (customer.Email != null && customer.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        customer.LoyaltyPoints.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();

                    // Update the DataGrid with the filtered data
                    customerDataGrid.ItemsSource = filteredData;
                }
                else if (customerDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    customerDataGrid.ItemsSource = customers;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
            }
        }
    }

    public class CustomerData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
