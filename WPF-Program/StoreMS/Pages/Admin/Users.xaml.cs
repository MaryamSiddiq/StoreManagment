using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media; // Add this for Brush

namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<UserData> users = new List<UserData>();
        public Users()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {            
            userDataGrid.ItemsSource = null;            

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [User]", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            users.Add(new UserData
                            {
                                Name = row["Name"].ToString(),
                                Username = row["Username"].ToString(),
                                Role = row["Role"].ToString(),
                                IsActive = Convert.ToBoolean(row["IsActive"]),
                                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                            });
                        }
                    }
                }
                connection.Close();
            }

            userDataGrid.ItemsSource = users;
            userDataGrid.Items.Refresh();
        }

        private void DeleteUser(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    // Now you can safely delete the user
                    string deleteUserQuery = "DELETE FROM [User] WHERE Username = @Username";
                    using (SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection))
                    {
                        deleteUserCommand.Parameters.AddWithValue("@Username", username);
                        deleteUserCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                }                
                MessageBox.Show("User Deleted Successfully!");                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AddUser(string name, string username, string password, string role, bool isActive)
        {
            // Check if the username already exists
            if (IsUsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO [User] (Name, Username, Password, Role, IsActive, CreatedAt, UpdatedAt) VALUES (@Name, @Username, @Password, @Role, @IsActive, GETDATE(), GETDATE())", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("User Added Successfully!");
        }

        private bool IsUsernameExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, it means the username already exists
                    return count > 0;
                }
            }
        }


        private void UpdateUser(string username, string name, string role, bool isActive)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE [User] SET Name = @Name, Role = @Role, IsActive = @IsActive, UpdatedAt = GETDATE() WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("User Updated Successfully!");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (userDataGrid.SelectedItem != null)
            {
                var selectedItem = (UserData)userDataGrid.SelectedItem;
                DeleteUser(selectedItem.Username);
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
            ReloadPage();
        }

        private void btnAddUser_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Assuming you have fields to input the new user information
            string newName = txtName.Text; // Replace with your actual value
            string newUsername = txtUsername.Text; // Replace with your actual value
            string newPassword = txtPassword.Text; // Replace with your actual value
            string newRole = "Admin";
            if (CBRole.SelectedIndex == 2)
                newRole = "Cashier"; // Replace with your actual value
            bool newIsActive = true; // Replace with your actual value

            AddUser(newName, newUsername, newPassword, newRole, newIsActive);
            ReloadPage();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (userDataGrid.SelectedItem != null)
            {
                var selectedItem = (UserData)userDataGrid.SelectedItem;

                // Open the EditUserWindow and pass the selected user for editing
                EditUserWindow editUserWindow = new EditUserWindow(selectedItem);
                editUserWindow.ShowDialog();

                // Call UpdateUser if the user confirmed the changes
                UpdateUser(selectedItem.Username, selectedItem.Name, selectedItem.Role, selectedItem.IsActive);
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
            ReloadPage();
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

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Get the search text from the TextBox
                string searchText = txtSearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = users
                        .Where(item =>
                            (item.Name != null && item.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Username != null && item.Username.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Role != null && item.Role.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();

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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
        private void ReloadPage()
        {
            // Create a new instance of the Users page
            Users usersPage = new Users();

            // Navigate to the new instance of the Users page
            this.NavigationService.Navigate(usersPage);
        }        
    }
}
