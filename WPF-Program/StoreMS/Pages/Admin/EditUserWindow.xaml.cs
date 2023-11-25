using System.Windows;

namespace StoreMS.Pages.Admin
{
    public partial class EditUserWindow : Window
    {
        private UserData editedUser;

        public EditUserWindow(UserData user)
        {
            InitializeComponent();
            editedUser = user;

            // Set initial values in the UI
            txtNewName.Text = user.Name;
            if (user.Role == "Admin")
                CBRole.SelectedIndex = 1;
            else
                CBRole.SelectedIndex = 2;
            chkNewIsActive.IsChecked = user.IsActive;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Update the editedUser with new values
            editedUser.Name = txtNewName.Text;
            editedUser.Role = CBRole.Text;
            editedUser.IsActive = chkNewIsActive.IsChecked ?? false;

            // Close the window
            Close();
        }
    }
}
