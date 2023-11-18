using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StoreMS.Pages.User
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        string text = null;

        public Account()
        {
            InitializeComponent();

            // Assuming you have a method to fetch user data, you can populate the user information here
            PopulateUserData();
        }

        private void PopulateUserData()
        {
            // Replace this with your logic to fetch and populate user data
            txtUsername.Text = "SampleUsername"; // Replace with the actual username
            txtName.Text = "Sample Name"; // Replace with the actual name
            txtPassword.Text = "Sample Password"; // Replace with the actual password
        }

        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Enter the "))
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
        }

        private void btnSaveChanges_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic to save changes
            // For example, you can retrieve the data from the textboxes and update the user information
            string newName = txtName.Text;
            string newPassword = txtPassword.Text;

            // Replace the following with your logic to update the user data
            // UpdateUserData(newName, newPassword);
        }

        private void btnSaveChanges_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                txtSaveChanges.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnSaveChanges_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                txtSaveChanges.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }
    }
}
