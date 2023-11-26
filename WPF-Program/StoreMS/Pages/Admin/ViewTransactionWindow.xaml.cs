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
    /// Interaction logic for ViewTransactionWindow.xaml
    /// </summary>
    public partial class ViewTransactionWindow : Window
    {
        TransactionData transactionData;
        // Create a list to store CartItem objects
        List<CartItem> cartItems = new List<CartItem>();
        public ViewTransactionWindow(TransactionData transaction)
        {
            InitializeComponent();
            this.transactionData = transaction;
            lblDateTime.Content += transaction.DateTime.ToString();
            lblEmail.Content += transaction.CustomerEmail;
            lblGiftCard.Content += transaction.GiftCardDiscount.ToString();
            lblLoyalty.Content += transaction.LoyaltyDiscount.ToString();
            lblTotal.Content += transaction.TotalAmount.ToString();
            lblPaid.Content += transaction.PaidAmount.ToString();
            loadDataGrid(transaction.ProductsList);
        }

        private void loadDataGrid(string productsList)
        {
            try
            {
                // Split the productsList by semicolon
                string[] productEntries = productsList.Split(';');                

                foreach (string entry in productEntries)
                {
                    // Split each entry by dash to get item details
                    string[] itemDetails = entry.Split('-');

                    // Ensure there are three components (ItemName, Price, Quantity)
                    if (itemDetails.Length == 3 &&
                        decimal.TryParse(itemDetails[1], out decimal price) &&
                        int.TryParse(itemDetails[2], out int quantity))
                    {
                        // Create a new CartItem object and add it to the list
                        CartItem cartItem = new CartItem(itemDetails[0], price, quantity);
                        cartItems.Add(cartItem);
                    }
                    else
                    {
                        // Handle invalid entry format
                        // You may want to log a warning or take appropriate action
                        MessageBox.Show($"Invalid entry format: {entry}");
                    }
                }

                // Now you have a list of CartItem objects (cartItems)
                // You can use this list to populate your DataGrid or perform other operations
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            DataGrid.ItemsSource = cartItems;
            DataGrid.Items.Refresh();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
