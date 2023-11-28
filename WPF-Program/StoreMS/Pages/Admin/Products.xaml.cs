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
    // Products Page class
    public partial class Products : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        private List<ProductData> products = new List<ProductData>();
        private List<CategoryData> categoryData = new List<CategoryData>();

        // Constructor
        public Products()
        {
            InitializeComponent();
            LoadProductData();
            LoadCategoryData();
        }

        // Method to load category data from the database
        private void LoadCategoryData()
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Products", "LoadCategoryData");
                MessageBox.Show($"An error occurred while loading category data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to load product data from the database
        private void LoadProductData()
        {
            productDataGrid.ItemsSource = null;

            try
            {
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Products", "LoadProductData");
                MessageBox.Show($"An error occurred while loading product data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            productDataGrid.ItemsSource = products;
            productDataGrid.Items.Refresh();
        }

        // Method to delete a product
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
                }
                MessageBox.Show("Product Deleted Successfully!");
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Products", "DeleteProduct");
                MessageBox.Show($"An error occurred while deleting the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to add a new product
        private void AddProduct(string name, decimal price, int quantity, string description, string category)
        {
            try
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
                }
                MessageBox.Show("Product Added Successfully!");
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Products", "AddProduct");
                MessageBox.Show($"An error occurred while adding the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to check if a product name already exists
        private bool IsProductNameExists(string name)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Products", "IsProductNameExists");
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Method to update a product
        private void UpdateProduct(string productName, decimal price, int quantity, string description, string category)
        {
            try
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
                }
                MessageBox.Show("Product Updated Successfully!");
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Products", "UpdateProduct");
                MessageBox.Show($"An error occurred while updating the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the delete product button click
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

        // Event handler for the add product button mouse down
        private void btnAddProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            string newName = txtName.Text;
            if (newName == "" || newName.StartsWith("Enter "))
            {
                MessageBox.Show("Enter a valid name");
                return;
            }
            decimal newPrice = decimal.MinValue;
            if (decimal.TryParse(txtPrice.Text, out newPrice))
            {
                newPrice = Convert.ToDecimal(txtPrice.Text);
            }
            else
            {
                MessageBox.Show("Enter a valid Price");
                return;
            }
            int newQuantity = int.MinValue;
            if (int.TryParse(txtQuantity.Text, out newQuantity))
            {
                newQuantity = Convert.ToInt32(txtQuantity.Text);
            }
            else
            {
                MessageBox.Show("Enter a valid quantity");
                return;
            }
            string newDescription = txtDescription.Text;
            if (newDescription == "" || newDescription.StartsWith("Enter "))
            {
                MessageBox.Show("Enter a valid description");
                return;
            }
            string newCategory = CBCategory.SelectedItem?.ToString();
            if (newCategory == "" || newCategory.StartsWith("Select "))
            {
                MessageBox.Show("Select a valid category");
                return;
            }

            AddProduct(newName, newPrice, newQuantity, newDescription, newCategory);
            ReloadPage();
        }

        // Event handler for the edit product button click
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

        // Method to reload the page
        private void ReloadPage()
        {
            // Create a new instance of the Products page
            Products productsPage = new Products();

            // Navigate to the new instance of the Products page
            this.NavigationService.Navigate(productsPage);
        }

        string text = null;

        // Event handler for when a text box gets focus
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

        // Event handler for when a text box loses focus
        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
            }
            txtProductSearch.Text = "Search Here...";
        }

        // Event handler for when the mouse enters the add product button
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

        // Event handler for when the mouse leaves the add product button
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

        // Event handler for when the text in the product search box changes
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
                // Log the exception
                Exceptions.LogException(ex, "Products", "txtProductSearch_TextChanged");
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
