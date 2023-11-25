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

        private void LoadCustomerData()
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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddCustomer(string name, string email, int loyaltyPoints)
        {
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

        private bool IsCustomerExists(string email)
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

        private void UpdateCustomer(string email, string name, int loyaltyPoints)
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

        private void btnAddCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string newName = txtName.Text;
            string newEmail = txtEmail.Text;
            int newLoyaltyPoints = Convert.ToInt32(txtLoyaltyPoints.Text);

            AddCustomer(newName, newEmail, newLoyaltyPoints);
            ReloadPage();
        }

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

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
            }
            txtCustomerSearch.Text = "Search Here...";
        }

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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void ReloadPage()
        {
            Customers customersPage = new Customers();
            this.NavigationService.Navigate(customersPage);
        }
    }
}