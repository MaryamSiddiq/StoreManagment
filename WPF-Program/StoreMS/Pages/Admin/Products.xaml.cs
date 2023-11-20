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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        List<ProductData> products = new List<ProductData>();
        public Products()
        {
            InitializeComponent();

            products = new List<ProductData>
            {
                new ProductData { ProductName = "Laptop", Price = 999.99, Quantity = 10, Description = "Powerful laptop for work and gaming", Category = "Electronics" },
                new ProductData { ProductName = "T-Shirt", Price = 19.99, Quantity = 50, Description = "Comfortable cotton T-shirt", Category = "Clothing" },
                // Add more product data as needed
            };

            // Sort the products by Category and then by ProductName
            products = products
                .OrderBy(product => product.Category)
                .ThenBy(product => product.ProductName)
                .ToList();

            productDataGrid.ItemsSource = products;
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
            if (txtProductSearch.Text.Length <=0 )
                txtProductSearch.Text = "Search Here...";
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected in the DataGrid
            if (productDataGrid.SelectedItem != null)
            {
                // Get the selected item (assuming your data source is a collection of objects)
                var selectedItem = (ProductData)productDataGrid.SelectedItem;
                MessageBox.Show(selectedItem.ProductName);
                // Implement your edit logic here. For example, open a dialog to edit the selected item.
                // You can pass the selectedItem to the dialog for editing.

                // After editing, you may need to refresh the DataGrid to reflect the changes.
                // You can do this by reassigning the data source or manually updating the selected item in the DataGrid.
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your logic to delete the selected product
        }

        private void btnAddProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic to add a new product
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
                // Get the search text from the TextBox
                string searchText = txtProductSearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = products.Where(item =>
                        (item.ProductName != null && item.ProductName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (item.Description != null && item.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        item.Price.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 || // Convert to string before checking
                        (item.Category != null && item.Category.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();


                    // Update the DataGrid with the filtered data
                    productDataGrid.ItemsSource = filteredData;
                }
                else if (productDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    productDataGrid.ItemsSource = products;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
            }
        }
    }
}

public class ProductData
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
