using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StoreMS.Pages.Admin
{
    public partial class Categories : Page
    {
        List<CategoryData> categories = new List<CategoryData>();
        string text = null;

        public Categories()
        {
            InitializeComponent();

            categories = new List<CategoryData>
            {
                new CategoryData { CategoryName = "Electronics" },
                new CategoryData { CategoryName = "Clothing" },
                // Add more category data as needed
            };

            // Sort the categories by CategoryName
            categories = categories
                .OrderBy(category => category.CategoryName)
                .ToList();

            categoryDataGrid.ItemsSource = categories;
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
            if (txtCategorySearch.Text.Length <= 0)
                txtCategorySearch.Text = "Search Here...";
        }

        private void btnAddCategory_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic to add a new category
        }

        private void btnAddCategory_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                categoryIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd2.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnAddCategory_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                categoryIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtAdd.Foreground = (Brush)FindResource("TextSecundaryColor");
                txtAdd2.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }

        private void txtCategorySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Get the search text from the TextBox
                string searchText = txtCategorySearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = categories.Where(item =>
                        (item.CategoryName != null && item.CategoryName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();

                    // Update the DataGrid with the filtered data
                    categoryDataGrid.ItemsSource = filteredData;
                }
                else if (categoryDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    categoryDataGrid.ItemsSource = categories;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
            }
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected in the DataGrid
            if (categoryDataGrid.SelectedItem != null)
            {
                // Get the selected item (assuming your data source is a collection of objects)
                var selectedItem = (CategoryData)categoryDataGrid.SelectedItem;
                MessageBox.Show(selectedItem.CategoryName);
                // Implement your edit logic here. For example, open a dialog to edit the selected item.
                // You can pass the selectedItem to the dialog for editing.

                // After editing, you may need to refresh the DataGrid to reflect the changes.
                // You can do this by reassigning the data source or manually updating the selected item in the DataGrid.
            }
            else
            {
                MessageBox.Show("Please select a category to edit.");
            }
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your logic to delete the selected category
        }
    }

    public class CategoryData
    {
        public string CategoryName { get; set; }
    }
}
