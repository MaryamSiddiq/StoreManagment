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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        List<UserData> users = new List<UserData>();
        public Users()
        {
            InitializeComponent();

            users = new List<UserData>
            {
                new UserData { Name = "John Doe", Username = "johndoe", Role = "Admin", IsActive = true },
                new UserData { Name = "Jane Smith", Username = "janesmith", Role = "User", IsActive = false },
                new UserData { Name = "Bob Johnson", Username = "bobjohnson", Role = "User", IsActive = true }
                // Add more user data as needed
            };

            // Sort the users by IsActive (true first) and then by Name
            users = users
                .OrderByDescending(user => user.IsActive)
                .ThenBy(user => user.Role)
                .ThenBy(user => user.Name)
                .ToList();

            userDataGrid.ItemsSource = users; 
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
            txtSearch.Text = "Search Here...";
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected in the DataGrid
            if (userDataGrid.SelectedItem != null)
            {
                // Get the selected item (assuming your data source is a collection of objects)
                var selectedItem = (UserData)userDataGrid.SelectedItem;
                MessageBox.Show(selectedItem.Name);
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAddUser_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAddUser_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                nextIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtSignIn.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnAddUser_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                nextIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtSignIn.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Get the search text from the TextBox
                string searchText = txtSearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = users.Where(item =>
                        (item.Name != null && item.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (item.Username != null && item.Username.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (item.Role != null && item.Role.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();

                    // Update the DataGrid with the filtered data
                    userDataGrid.ItemsSource = filteredData;
                }
                else if (userDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    userDataGrid.ItemsSource = users;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
            }
        }

    }
}

public class UserData
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
}