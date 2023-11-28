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

        // Method to load user data into the userDataGrid
        private void LoadUserData()
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "LoadUserData");

                // Show an error message to the user
                MessageBox.Show($"An error occurred while loading user data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to delete a user by username
        private void DeleteUser(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
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
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "DeleteUser");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to add a new user
        private void AddUser(string name, string username, string password, string role, bool isActive)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "AddUser");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to check if a username already exists
        private bool IsUsernameExists(string username)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "IsUsernameExists");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; // Assuming it should not proceed if an error occurs
            }
        }

        // Method to update an existing user
        private void UpdateUser(string username, string name, string role, bool isActive)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "UpdateUser");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler when the Delete button is clicked
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "DeleteButton_Click");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler when the Add User button is clicked
        private void btnAddUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Assuming you have fields to input the new user information
                string newName = txtName.Text;
                if (newName == "" || newName.StartsWith("Enter "))
                {
                    MessageBox.Show("Enter a valid name!");
                    return;
                }
                string newUsername = txtUsername.Text;
                if (newUsername == "" || newUsername.StartsWith("Enter "))
                {
                    MessageBox.Show("Enter a valid username!");
                    return;
                }
                string newPassword = txtPassword.Text;
                if (newPassword == "" || newPassword.StartsWith("Enter "))
                {
                    MessageBox.Show("Enter a valid password!");
                    return;
                }
                if (CBRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Select a valid role!");
                    return;
                }
                string newRole = "Admin";
                if (CBRole.SelectedIndex == 2)
                    newRole = "Cashier";
                
                if (CBActive.SelectedIndex == 0)
                {
                    MessageBox.Show("Select a valid status!");
                    return;
                }
                bool newIsActive = false;
                if (CBActive.SelectedIndex == 2)
                    newIsActive = true;

                AddUser(newName, newUsername, newPassword, newRole, newIsActive);
                ReloadPage();
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "btnAddUser_MouseDown");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler when the Edit button is clicked
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "EditButton_Click");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler when the Search TextBox text is changed
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

                    // Update the userDataGrid with the filtered data
                    userDataGrid.ItemsSource = filteredData;
                }
                else if (userDataGrid != null)
                {
                    // If the search text is empty, reset the userDataGrid to the original data source
                    userDataGrid.ItemsSource = users;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler when the Add User button is hovered over (MouseEnter)
        private void btnAddUser_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender is Border border)
                {
                    border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                    nextIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                    txtSignIn.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "btnAddUser_MouseEnter");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler when the Add User button is left (MouseLeave)
        private void btnAddUser_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender is Border border)
                {
                    border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                    nextIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                    txtSignIn.Foreground = (Brush)FindResource("TextSecundaryColor");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "btnAddUser_MouseLeave");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            txtSearch.Text = "Search Here...";
        }


        // Method to reload the page
        private void ReloadPage()
        {
            try
            {
                // Create a new instance of the Users page
                Users usersPage = new Users();

                // Navigate to the new instance of the Users page
                this.NavigationService.Navigate(usersPage);
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Users.xaml.cs", "ReloadPage");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
