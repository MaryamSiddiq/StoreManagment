using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StoreMS.Pages.User
{
    public partial class Inventory : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<ProductData> products = new List<ProductData>();

        public Inventory()
        {
            InitializeComponent();
            LoadProductData();
        }

        private void LoadProductData()
        {
            itemDataGrid.ItemsSource = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [Product]", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            products.Add(new ProductData
                            {
                                ProductName = row["Name"].ToString(),
                                Price = Convert.ToDecimal(row["Price"]),
                                Quantity = Convert.ToInt32(row["Quantity"]),
                                Description = row["Description"].ToString(),
                                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                            });
                        }
                    }
                }
                connection.Close();
            }

            itemDataGrid.ItemsSource = products;
            itemDataGrid.Items.Refresh();
        }
        string text = null;
        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            // Replace with your logic when the search TextBox gets focus
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Search Here...")
            {
                textBox.Text = "";
            }
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            // Replace with your logic when the search TextBox loses focus
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search Here...";
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text;

                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = products
                        .Where(item =>
                            (item.ProductName != null && item.ProductName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Description != null && item.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();

                    itemDataGrid.ItemsSource = filteredData;
                }
                else if (itemDataGrid != null)
                {
                    itemDataGrid.ItemsSource = products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Add your methods for Add, Update, and Delete products here, similar to the Users backend

        // Example:
        // private void AddProduct(string name, decimal price, int quantity, string description)
        // {
        //     using (SqlConnection connection = new SqlConnection(ConnectionString))
        //     {
        //         connection.Open();
        //         // Add your INSERT query here
        //     }
        //     MessageBox.Show("Product Added Successfully!");
        // }

        // private void UpdateProduct(string name, decimal price, int quantity, string description)
        // {
        //     using (SqlConnection connection = new SqlConnection(ConnectionString))
        //     {
        //         connection.Open();
        //         // Add your UPDATE query here
        //     }
        //     MessageBox.Show("Product Updated Successfully!");
        // }

        // private void DeleteProduct(string name)
        // {
        //     using (SqlConnection connection = new SqlConnection(ConnectionString))
        //     {
        //         connection.Open();
        //         // Add your DELETE query here
        //     }
        //     MessageBox.Show("Product Deleted Successfully!");
        // }

        // You can add other necessary methods based on your requirements

        // Example:
        // private bool IsProductNameExists(string name)
        // {
        //     using (SqlConnection connection = new SqlConnection(ConnectionString))
        //     {
        //         connection.Open();
        //         // Add your SELECT query here to check if the product name exists
        //     }
        //     return false; // Modify this based on your check
        // }

        // You can add additional methods based on your requirements

        private void ReloadPage()
        {
            // Create a new instance of the Inventory page
            Inventory inventoryPage = new Inventory();

            // Navigate to the new instance of the Inventory page
            this.NavigationService.Navigate(inventoryPage);
        }

        // Add your event handlers and other methods as needed
    }
}