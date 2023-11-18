using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StoreMS.Pages.Cashier
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class POS : Page
    {
        // Assuming this is your item class, replace it with the actual item class
        public class CartItem
        {
            public string ItemName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        // ObservableCollection to hold the cart items
        private ObservableCollection<CartItem> cartItems;

        public POS()
        {
            InitializeComponent();

            // Initialize the cartItems collection
            cartItems = new ObservableCollection<CartItem>();
            itemsDataGrid.ItemsSource = cartItems;
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsDataGrid.SelectedItem is CartItem selectedItem)
            {
                // Remove the selected item from the collection
                cartItems.Remove(selectedItem);

                // Recalculate and update the total price
                UpdateTotalPrice();
            }
        }
        private void btnAddCart_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                addIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                txtAdd2.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnAddCart_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                addIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtAdd.Foreground = (Brush)FindResource("TextSecundaryColor");
                txtAdd2.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }
        private void btnConfirmOrder_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                txtConfirmOrder.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnConfirmOrder_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                txtConfirmOrder.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }

        private void btnAddCart_MouseDown(object sender, RoutedEventArgs e)
        {
            // Add item to cart
            string itemName = txtItemName.Text.Trim();
            string quantityText = txtItemQuantity.Text.Trim();

            if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(quantityText) && int.TryParse(quantityText, out int quantity))
            {
                decimal price = 10.0m; // Replace with actual price calculation logic
                CartItem newItem = new CartItem { ItemName = itemName, Price = price, Quantity = quantity };
                cartItems.Add(newItem);

                // Recalculate and update the total price
                UpdateTotalPrice();

                // Clear input fields
                txtItemName.Clear();
                txtItemQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid item name and quantity.");
            }
        }
        
        private void btnConfirmOrder_MouseDown(object sender, RoutedEventArgs e)
        {
            // Implement your order confirmation logic here
            MessageBox.Show("Order confirmed!");
        }

        

        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var item in cartItems)
            {
                totalPrice += item.Price * item.Quantity;
            }

            lblTotalPrice.Content = $"Total Price: ${totalPrice:F2}";
        }

        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Search Item Name" || textBox.Text == "Enter the Item Quantity")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "txtItemName")
                {
                    textBox.Text = "Search Item Name";
                }
                else if (textBox.Name == "txtItemQuantity")
                {
                    textBox.Text = "Enter the Item Quantity";
                }

                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void btnConfirmOrder_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
