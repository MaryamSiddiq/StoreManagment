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
using System.Windows.Shapes;

namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private CustomerData editedCustomer;
        public EditCustomerWindow(CustomerData customer)
        {
            InitializeComponent(); 
            editedCustomer = customer;

            // Set initial values in the UI
            txtName.Text = customer.Name;            
            txtLoyaltyPoints.Text = customer.LoyaltyPoints.ToString();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            editedCustomer.Name = txtName.Text;
            editedCustomer.LoyaltyPoints = int.Parse(txtLoyaltyPoints.Text);
            
            // Close the window
            Close();
        }
    }
}
