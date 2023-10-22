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
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;

namespace StoreMS.Pages
{
    /// <summary>
    /// Lógica de interacción para Student.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        string user;
        public SignIn(string user)
        {
            InitializeComponent();
            this.user = user;
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
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = text;
            }
        }
        //---------------------------  RESET the TEXTBOXES, COMBOBOX and DATEPICKER ------------------------------------
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = "Enter the ID";
            txtPassword.Text = "Enter the Password";
        }
        private void btnSignIn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (user == "Admin")
            {
                AdminHP adminHP = new AdminHP();
                adminHP.ShowDialog();
            }
            else if (user == "Cashier")
            {
                UserHP userHP = new UserHP();
                userHP.ShowDialog();
            }
            
        }

        private void btnSignIn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");                
                nextIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");                
                txtSignIn.Foreground = (Brush)FindResource("PrimaryBackgroundColor");                
            }
        }

        private void btnSignIn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                nextIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtSignIn.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }
    }
}
