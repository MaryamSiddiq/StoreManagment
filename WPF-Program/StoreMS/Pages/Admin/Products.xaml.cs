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
    public partial class Products : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<ProductData> products = new List<ProductData>();
        List<CategoryData> categoryData = new List<CategoryData>();

        public Products()
        {
            InitializeComponent();
            LoadProductData();
            LoadCategoryData();
        }
        private void LoadCategoryData()
        {            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [Category]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryData.Add(new CategoryData
                            {
                                CategoryName = reader["Name"].ToString(),                                   
                            });
                            CBCategory.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
                connection.Close();
            }            
        }


        private void LoadProductData()
        {
            productDataGrid.ItemsSource = null;

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
                                Category = row["Category"].ToString(),
                                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                            });
                        }
                    }
                }
                connection.Close();
            }

            productDataGrid.ItemsSource = products;
            productDataGrid.Items.Refresh();
        }

        private void DeleteProduct(string productName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string deleteProductQuery = "DELETE FROM [Product] WHERE Name = @ProductName";
                    using (SqlCommand deleteProductCommand = new SqlCommand(deleteProductQuery, connection))
                    {
                        deleteProductCommand.Parameters.AddWithValue("@ProductName", productName);
                        deleteProductCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Product Deleted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddProduct(string name, decimal price, int quantity, string description, string category)
        {
            // Check if the product name already exists
            if (IsProductNameExists(name))
            {
                MessageBox.Show("Product name already exists. Please choose a different name.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO [Product] (Name, Price, Quantity, Description, Category, CreatedAt, UpdatedAt) VALUES (@Name, @Price, @Quantity, @Description, @Category, GETDATE(), GETDATE())", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Category", category);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("Product Added Successfully!");
        }

        private bool IsProductNameExists(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Product] WHERE Name = @Name", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void UpdateProduct(string productName, decimal price, int quantity, string description, string category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE [Product] SET Price = @Price, Quantity = @Quantity, Description = @Description, Category = @Category, UpdatedAt = GETDATE() WHERE Name = @ProductName", connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Category", category);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("Product Updated Successfully!");
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null)
            {
                var selectedItem = (ProductData)productDataGrid.SelectedItem;
                DeleteProduct(selectedItem.ProductName);
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
            ReloadPage();
        }

        private void btnAddProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Assuming you have fields to input the new product information
            string newName = txtName.Text; // Replace with your actual value
            decimal newPrice = Convert.ToDecimal(txtPrice.Text); // Replace with your actual value
            int newQuantity = Convert.ToInt32(txtQuantity.Text); // Replace with your actual value
            string newDescription = txtDescription.Text; // Replace with your actual value
            string newCategory = CBCategory.SelectedItem.ToString();

            AddProduct(newName, newPrice, newQuantity, newDescription, newCategory);
            ReloadPage();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null)
            {
                var selectedItem = (ProductData)productDataGrid.SelectedItem;

                // Open the EditProductWindow and pass the selected product for editing
                EditProductWindow editProductWindow = new EditProductWindow(selectedItem, categoryData);
                editProductWindow.ShowDialog();

                // Call UpdateProduct if the user confirmed the changes
                UpdateProduct(selectedItem.ProductName, selectedItem.Price, selectedItem.Quantity, selectedItem.Description, selectedItem.Category);
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
            ReloadPage();
        }

        private void ReloadPage()
        {
            // Create a new instance of the Products page
            Products productsPage = new Products();

            // Navigate to the new instance of the Products page
            this.NavigationService.Navigate(productsPage);
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

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
            }
            txtProductSearch.Text = "Search Here...";
        }

        private void btnAddProduct_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                productIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd2.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnAddProduct_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                productIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtAdd.Foreground = (Brush)FindResource("TextSecundaryColor");
                txtAdd2.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }
        private void txtProductSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = txtProductSearch.Text;

                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = products
                        .Where(item =>
                            (item.ProductName != null && item.ProductName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Description != null && item.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Category != null && item.Category.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();

                    productDataGrid.ItemsSource = filteredData;
                }
                else if (productDataGrid != null)
                {
                    productDataGrid.ItemsSource = products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}