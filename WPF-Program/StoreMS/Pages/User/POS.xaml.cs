using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace StoreMS.Pages.Cashier
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class POS : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<string> products = new List<string>();
        decimal cartPrice = 0.0M;
        decimal loyaltyDisc = 0.0M;
        decimal GiftCardDisc = 0.0M;
        decimal totalPrice = 0.0M;
        

        // ObservableCollection to hold the cart items
        private ObservableCollection<CartItem> cartItems;

        public POS()
        {
            InitializeComponent();
            LoadProductNames();

            // Initial population of the ListBox with all items
            cartItems = new ObservableCollection<CartItem>();
            itemsDataGrid.ItemsSource = cartItems;
        }
        private void updatePriceLabels()
        {
            decimal totalSum = cartItems.Sum(item => item.Total);
            cartPrice = totalSum;
            lblPrice.Content = "Cart Price: Rs." + cartPrice.ToString();
            lblLoyaltyPoint.Content = "Loyalty Disc.: Rs." + loyaltyDisc.ToString();
            lblGiftCard.Content = "Gift Card Disc.: Rs." + GiftCardDisc.ToString();
            totalPrice = cartPrice - loyaltyDisc - GiftCardDisc;
            lblTotalPrice.Content = "Total Price: Rs." + totalPrice.ToString();
            txtItemName.Text = "Search the Item Name";
            txtItemQuantity.Text = "Enter the Item Quantity";
        }
        
        private void LoadProductNames()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT ID, Name FROM Product";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int ID = int.Parse(row["ID"].ToString());
                            string Name = row["Name"].ToString();
                            products.Add((ID.ToString() + "-" + Name));
                        }
                    }
                }
            }
        }
        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsDataGrid.SelectedItem is CartItem selectedItem)
            {
                // Remove the selected item from the collection
                cartItems.Remove(selectedItem);
                // Update the DataGrid
                itemsDataGrid.Items.Refresh();

                // Update the quantity in the database
                UpdateQuantityInDatabase(selectedItem.ItemName, selectedItem.Quantity, "Add");

                updatePriceLabels();
            }
        }
        private void btnAddCart_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                addIcon.Fill = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                txtAdd.Foreground = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                txtAdd2.Foreground = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnAddCart_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                addIcon.Fill = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
                txtAdd.Foreground = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
                txtAdd2.Foreground = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
            }
        }       

        private void btnAddCart_MouseDown(object sender, RoutedEventArgs e)
        {
            // Add item to cart
            string itemName = txtItemName.Text.Trim();
            itemName = itemName.Split('-')[1];
            string quantityText = txtItemQuantity.Text.Trim();

            if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(quantityText) && int.TryParse(quantityText, out int quantity))
            {
                if (IsItemAvailableInDatabase(itemName, quantity))
                {
                    // Item is available, create a CartItem object
                    decimal itemPrice = GetItemPriceFromDatabase(itemName);
                    CartItem cartItem = new CartItem(itemName, itemPrice, quantity);
                    // Now you can use the cartItem object as needed

                    // Update the quantity in the database
                    bool success = UpdateQuantityInDatabase(itemName, quantity, "Remove");
                    if (success)
                    {
                        cartItems.Add(cartItem);
                    }
                }
                else
                {
                    MessageBox.Show("Not enough quantity available.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid item name and quantity.");
            }
            updatePriceLabels();
        }
        private bool IsItemAvailableInDatabase(string itemName, int requestedQuantity)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Quantity FROM [Product] WHERE Name = @ItemName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemName", itemName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int availableQuantity = reader.GetInt32(0);
                            return availableQuantity >= requestedQuantity;
                        }
                    }
                }
                connection.Close();
            }

            return false;
        }
        private decimal GetItemPriceFromDatabase(string itemName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Price FROM Product WHERE Name = @ItemName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemName", itemName);

                    object result = command.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                    {
                        return price;
                    }
                }
                connection.Close();
            }
            return 0.0m;
        }
        private bool UpdateQuantityInDatabase(string itemName, int quantity, string action)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE Product SET Quantity = Quantity - @RequestedQuantity WHERE Name = @ItemName";
                if (action == "Add")
                    updateQuery = "UPDATE Product SET Quantity = Quantity + @RequestedQuantity WHERE Name = @ItemName";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@RequestedQuantity", quantity);
                    updateCommand.Parameters.AddWithValue("@ItemName", itemName);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Handle the case where the update did not succeed
                        return false;
                    }
                }

                connection.Close();
            }
            return true;
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

        string text = null;
        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Enter the ") || textBox.Text.StartsWith("Search the ") || textBox.Text.StartsWith("Enter GiftCard"))
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
        
        private void btnGiftCardEnter_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                nextIcon.Fill = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnGiftCardEnter_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                nextIcon.Fill = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
            }
        }
        private void btnGiftCardEnter_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string giftCardCode = txtGiftCardCode.Text.Trim();

            // Query the database to check the gift card
            decimal balance = CheckGiftCard(giftCardCode);

            if (balance >= 0)
            {
                // Gift card is valid, and its balance is returned
                GiftCardDisc = balance;

                // You can also update the IsActive to false in the database
                UpdateGiftCardStatus(giftCardCode);
                updatePriceLabels();

                // Perform other actions as needed
            }
            else
            {
                // Gift card is not valid or inactive
                MessageBox.Show("Invalid or inactive gift card.");
            }
        }

        private decimal CheckGiftCard(string cardCode)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Balance, IsActive FROM GiftCard WHERE CardCode = @CardCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardCode", cardCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));

                            if (isActive)
                            {
                                // Gift card is active, return the balance
                                return reader.GetDecimal(reader.GetOrdinal("Balance"));
                            }
                        }
                    }
                }
                connection.Close();
            }

            // Gift card not found or not active
            return -1;
        }

        private void UpdateGiftCardStatus(string cardCode)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE GiftCard SET IsActive = 0 WHERE CardCode = @CardCode";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@CardCode", cardCode);
                    updateCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        private void txtCustomerName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtLabelPlace_GotFocus(sender, e);

            // Get the email from txtCustomerEmail
            string customerEmail = txtCustomerEmail.Text.Trim();

            // Check if the customer with the given email exists in the database
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Assuming your Customer table has columns ID, Name, Email, and LoyaltyPoints
                string query = "SELECT Name, LoyaltyPoints FROM Customer WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", customerEmail);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Customer found, populate txtCustomerName and get LoyaltyPoints
                            string customerName = reader["Name"].ToString();
                            int loyaltyPoints = Convert.ToInt32(reader["LoyaltyPoints"]);

                            txtCustomerName.Text = customerName;
                            // Assuming you have a txtLoyaltyPoints TextBox, update its text
                            loyaltyDisc = loyaltyPoints;
                            updatePriceLabels();
                        }
                        else
                        {
                            // Customer not found, you may handle this case based on your requirements
                        }
                    }
                }
                connection.Close();
            }
        }
        private void btnConfirmOrder_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                txtConfirmOrder.Foreground = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnConfirmOrder_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                txtConfirmOrder.Foreground = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
            }
        }
        private void btnConfirmOrder_MouseDown(object sender, RoutedEventArgs e)
        {
            try
            {
                // Implement your order confirmation logic here
                string productList = getProductList();
                decimal totalAmount = cartPrice;
                decimal amount = totalPrice;
                string customerEmail = txtCustomerEmail.Text;
                string giftCardCode = txtGiftCardCode.Text;
                int loyaltyPoints = Convert.ToInt32(loyaltyDisc); // Replace with your actual logic to get loyalty points

                // Insert order into the [Order] table
                int orderID = InsertOrder(productList, totalAmount);

                if (orderID == -1)
                    return;
                // Retrieve CustomerID using the provided email
                int customerID = GetCustomerIDByEmail(customerEmail);

                // Retrieve GiftCardID using the provided gift card code
                int giftCardID = GetGiftCardIDByCode(giftCardCode);

                // Insert transaction into the [Transaction] table
                InsertTransaction(orderID, customerID <= 0 ? 0 : customerID , giftCardID <= 0 ? 0 : giftCardID, amount, loyaltyPoints);
                
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "POS.xaml.cs", "btnConfirmOrder_MouseDown");
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public int InsertOrder(string productList, decimal totalAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    int id = 0;
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [Order] (ProductsList, TotalAmount, CreatedAt, UpdatedAt) VALUES (@ProductsList, @TotalAmount, GETDATE(), GETDATE()); SELECT SCOPE_IDENTITY();", connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductsList", productList);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);                        
                        // Retrieve the inserted order ID
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    connection.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "POS.xaml.cs", "InsertOrder");
                return -1;
            }
            
        }
        public int GetCustomerIDByEmail(string customerEmail)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    int id = -1;
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ID FROM Customer WHERE Email = @Email", connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", customerEmail);

                        // Retrieve the CustomerID
                        object result = cmd.ExecuteScalar();
                        id = result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
                    }
                    connection.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "POS.xaml.cs", "GetCustomerIDByEmail");
                return -1;
            }            
        }
        public int GetGiftCardIDByCode(string giftCardCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    int id = 0;
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ID FROM GiftCard WHERE CardCode = @CardCode", connection))
                    {
                        cmd.Parameters.AddWithValue("@CardCode", giftCardCode);

                        // Retrieve the GiftCardID
                        object result = cmd.ExecuteScalar();
                        id = result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
                    }
                    connection.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "POS.xaml.cs", "GetCustomerIDByEmail");
                return -1;
            }
            
        }
        public void InsertTransaction(int orderID, int? customerID, int? giftCardID, decimal amount, int? loyaltyPoints)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Transaction] (OrderID, CustomerID, GiftCardID, Amount, LoyaltyPrice, CreatedAt, UpdatedAt) VALUES (@OrderID, @CustomerID, @GiftCardID, @Amount, @LoyaltyPrice, GETDATE(), GETDATE())", connection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);

                    if (customerID.HasValue && customerID.Value > 0)
                        cmd.Parameters.AddWithValue("@CustomerID", customerID.Value);
                    else
                        cmd.Parameters.AddWithValue("@CustomerID", DBNull.Value);

                    if (giftCardID.HasValue && giftCardID.Value > 0)
                        cmd.Parameters.AddWithValue("@GiftCardID", giftCardID.Value);
                    else
                        cmd.Parameters.AddWithValue("@GiftCardID", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Amount", amount);

                    if (loyaltyPoints.HasValue && loyaltyPoints.Value > 0)
                        cmd.Parameters.AddWithValue("@LoyaltyPrice", loyaltyPoints.Value);
                    else
                        cmd.Parameters.AddWithValue("@LoyaltyPrice", DBNull.Value);

                    // Execute the insert query
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private string getProductList()
        {
            StringBuilder productListBuilder = new StringBuilder();

            foreach (var item in itemsDataGrid.Items)
            {
                // Assuming your item has properties ItemName, Price, and Quantity
                string itemName = (string)item.GetType().GetProperty("ItemName").GetValue(item, null);
                decimal price = (decimal)item.GetType().GetProperty("Price").GetValue(item, null);
                int quantity = (int)item.GetType().GetProperty("Quantity").GetValue(item, null);

                string productInfo = $"{itemName}-{price}-{quantity};";
                productListBuilder.Append(productInfo);
            }

            return productListBuilder.ToString().TrimEnd(';');

        }
        
    }
}
