﻿using System;
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
    public partial class Categories : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<CategoryData> categories = new List<CategoryData>();

        public Categories()
        {
            InitializeComponent();
            LoadCategoryData();
        }

        // Load category data from the database and populate the DataGrid
        private void LoadCategoryData()
        {
            try
            {
                categoryDataGrid.ItemsSource = null;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM [Category]", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                categories.Add(new CategoryData
                                {
                                    CategoryName = row["Name"].ToString()
                                });
                            }
                        }
                    }
                    connection.Close();
                }

                categoryDataGrid.ItemsSource = categories;
                categoryDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Categories.xaml.cs", "LoadCategoryData");
                MessageBox.Show($"An error occurred while loading category data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Delete a category from the database
        private void DeleteCategory(string categoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string deleteCategoryQuery = "DELETE FROM [Category] WHERE Name = @Name";
                    using (SqlCommand deleteCategoryCommand = new SqlCommand(deleteCategoryQuery, connection))
                    {
                        deleteCategoryCommand.Parameters.AddWithValue("@Name", categoryName);
                        deleteCategoryCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Category Deleted Successfully!");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Categories.xaml.cs", "DeleteCategory");
                MessageBox.Show($"An error occurred while deleting the category: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Add a new category to the database
        private void AddCategory(string categoryName)
        {
            try
            {
                // Check if the category already exists
                if (IsCategoryExists(categoryName))
                {
                    MessageBox.Show("Category already exists. Please choose a different category name.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO [Category] (Name) VALUES (@Name)", connection))
                    {
                        command.Parameters.AddWithValue("@Name", categoryName);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Category Added Successfully!");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Categories.xaml.cs", "AddCategory");
                MessageBox.Show($"An error occurred while adding the category: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Check if a category with the given name already exists
        private bool IsCategoryExists(string categoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Category] WHERE Name = @Name", connection))
                    {
                        command.Parameters.AddWithValue("@Name", categoryName);
                        int count = (int)command.ExecuteScalar();

                        // If count is greater than 0, it means the category already exists
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Categories.xaml.cs", "IsCategoryExists");
                MessageBox.Show($"An error occurred while checking if the category exists: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; // Assume the category exists to avoid further issues
            }
        }

        // Update the name of a category in the database
        private void UpdateCategory(string oldCategoryName, string newCategoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE [Category] SET Name = @NewName WHERE Name = @OldName", connection))
                    {
                        command.Parameters.AddWithValue("@NewName", newCategoryName);
                        command.Parameters.AddWithValue("@OldName", oldCategoryName);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Category Updated Successfully!");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Categories.xaml.cs", "UpdateCategory");
                MessageBox.Show($"An error occurred while updating the category: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Handle the click event for the "Delete" button
        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (categoryDataGrid.SelectedItem != null)
            {
                var selectedItem = (CategoryData)categoryDataGrid.SelectedItem;
                DeleteCategory(selectedItem.CategoryName);
            }
            else
            {
                MessageBox.Show("Please select a category to delete.");
            }
            ReloadPage();
        }

        // Handle the mouse down event for the "Add" button
        private void btnAddCategory_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string newCategoryName = "";
            if (txtCategoryName.Text != "" && !txtCategoryName.Text.StartsWith("Enter "))
                newCategoryName = txtCategoryName.Text;
            else
            {
                MessageBox.Show("Enter a valid category");
                return;
            }
            AddCategory(newCategoryName);
            ReloadPage();
        }

        // Handle the click event for the "Edit" button
        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (categoryDataGrid.SelectedItem != null)
            {
                var selectedItem = (CategoryData)categoryDataGrid.SelectedItem;
                var oldCategoryName = selectedItem.CategoryName;
                // Open the EditCategoryWindow and pass the selected category for editing
                EditCategoryWindow editCategoryWindow = new EditCategoryWindow(selectedItem);
                editCategoryWindow.ShowDialog();

                // Call UpdateCategory if the user confirmed the changes
                UpdateCategory(oldCategoryName, selectedItem.CategoryName);
            }
            else
            {
                MessageBox.Show("Please select a category to edit.");
            }
            ReloadPage();
        }

        // Reload the page by creating a new instance and navigating to it
        private void ReloadPage()
        {
            try
            {
                // Create a new instance of the Categories page
                Categories categoriesPage = new Categories();

                // Navigate to the new instance of the Categories page
                this.NavigationService.Navigate(categoriesPage);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Categories.xaml.cs", "ReloadPage");
                MessageBox.Show($"An error occurred while reloading the page: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Placeholder handling for search and text entry
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
            txtCategorySearch.Text = "Search Here...";
        }

        // Handle mouse enter event for the "Add" button
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

        // Handle mouse leave event for the "Add" button
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

        // Handle text changed event for the search TextBox
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
                Exceptions.LogException(ex, "Categories.xaml.cs", "txtCategorySearch_TextChanged");
            }
        }

        
    }
}
