using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StoreMS.Pages.Admin
{
    public partial class Customers : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        private List<CustomerData> customers = new List<CustomerData>();
        private string text = null;

        public Customers()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        // Load customer data from the database and populate the DataGrid
        private void LoadCustomerData()
        {
            try
            {
                customerDataGrid.ItemsSource = null;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM [Customer]", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                customers.Add(new CustomerData
                                {
                                    Name = row["Name"].ToString(),
                                    Email = row["Email"].ToString(),
                                    LoyaltyPoints = Convert.ToInt32(row["LoyaltyPoints"]),
                                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                                });
                            }
                        }
                    }
                    connection.Close();
                }

                customerDataGrid.ItemsSource = customers;
                customerDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "LoadCustomerData");
                MessageBox.Show($"An error occurred while loading customer data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Delete a customer from the database
        private void DeleteCustomer(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string deleteCustomerQuery = "DELETE FROM [Customer] WHERE Email = @Email";
                    using (SqlCommand deleteCustomerCommand = new SqlCommand(deleteCustomerQuery, connection))
                    {
                        deleteCustomerCommand.Parameters.AddWithValue("@Email", email);
                        deleteCustomerCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Customer Deleted Successfully!");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "DeleteCustomer");
                MessageBox.Show($"An error occurred while deleting the customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Add a new customer to the database
        private void AddCustomer(string name, string email, int loyaltyPoints)
        {
            try
            {
                // Check if the customer already exists
                if (IsCustomerExists(email))
                {
                    MessageBox.Show("Customer already exists. Please choose a different email.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO [Customer] (Name, Email, LoyaltyPoints, CreatedAt, UpdatedAt) VALUES (@Name, @Email, @LoyaltyPoints, GETDATE(), GETDATE())", connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@LoyaltyPoints", loyaltyPoints);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Customer Added Successfully!");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "AddCustomer");
                MessageBox.Show($"An error occurred while adding the customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Check if a customer with the given email already exists
        private bool IsCustomerExists(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Customer] WHERE Email = @Email", connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "IsCustomerExists");
                MessageBox.Show($"An error occurred while checking if the customer exists: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; // Assume the customer exists to avoid further issues
            }
        }

        // Update customer information in the database
        private void UpdateCustomer(string email, string name, int loyaltyPoints)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE [Customer] SET Name = @Name, LoyaltyPoints = @LoyaltyPoints, UpdatedAt = GETDATE() WHERE Email = @Email", connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@LoyaltyPoints", loyaltyPoints);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Customer Updated Successfully!");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "UpdateCustomer");
                MessageBox.Show($"An error occurred while updating the customer: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Handle the click event for the "Delete" button
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (customerDataGrid.SelectedItem != null)
            {
                var selectedItem = (CustomerData)customerDataGrid.SelectedItem;
                DeleteCustomer(selectedItem.Email);
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
            ReloadPage();
        }

        // Handle the mouse down event for the "Add" button
        private void btnAddCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string newName = string.Empty;
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !txtName.Text.StartsWith("Enter "))
            {
                newName = txtName.Text;
            }
            else
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            string newEmail = string.Empty;
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.StartsWith("Enter "))
            {
                newEmail = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }

            int newLoyaltyPoints = 0;
            if (!string.IsNullOrWhiteSpace(txtLoyaltyPoints.Text) && int.TryParse(txtLoyaltyPoints.Text, out newLoyaltyPoints))
            {
                newLoyaltyPoints = Convert.ToInt32(txtLoyaltyPoints.Text);
            }
            else
            {
                MessageBox.Show("Please enter a valid loyalty points value.");
                return;
            }


            AddCustomer(newName, newEmail, newLoyaltyPoints);
            ReloadPage();
        }

        // Handle the click event for the "Edit" button
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (customerDataGrid.SelectedItem != null)
            {
                var selectedItem = (CustomerData)customerDataGrid.SelectedItem;

                EditCustomerWindow editCustomerWindow = new EditCustomerWindow(selectedItem);
                editCustomerWindow.ShowDialog();

                UpdateCustomer(selectedItem.Email, selectedItem.Name, selectedItem.LoyaltyPoints);
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.");
            }
            ReloadPage();
        }

        // Handle the got focus event for text entry placeholders
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

        // Handle the lost focus event for text entry placeholders
        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
            }
            txtCustomerSearch.Text = "Search Here...";
        }

        // Handle the text changed event for the search TextBox
        private void txtCustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = txtCustomerSearch.Text;

                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = customers
                        .Where(item =>
                            (item.Name != null && item.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Email != null && item.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.LoyaltyPoints.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();

                    customerDataGrid.ItemsSource = filteredData;
                }
                else if (customerDataGrid != null)
                {
                    customerDataGrid.ItemsSource = customers;
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "txtCustomerSearch_TextChanged");
                MessageBox.Show($"An error occurred while filtering customers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Handle the mouse enter event for the "Add" button
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

        // Handle the mouse leave event for the "Add" button
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

        // Reload the page by creating a new instance and navigating to it
        private void ReloadPage()
        {
            try
            {
                // Create a new instance of the Customers page
                Customers customersPage = new Customers();

                // Navigate to the new instance of the Customers page
                this.NavigationService.Navigate(customersPage);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Customers.xaml.cs", "ReloadPage");
                MessageBox.Show($"An error occurred while reloading the page: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }        
    }
}
