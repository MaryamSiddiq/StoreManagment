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
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string filter = txtItemName.Text.ToLower();
                List<string> filteredItems = products.FindAll(item => item.ToLower().Contains(filter));

                listBoxSuggestions.ItemsSource = filteredItems;
                popupSuggestions.IsOpen = filteredItems.Count > 0;

                if (e.Key == Key.Down)
                {
                    // Move focus to the ListBox when down arrow is pressed
                    listBoxSuggestions.Focus();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "txtItemName_KeyUp");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listBoxSuggestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listBoxSuggestions.SelectedIndex != -1)
                {
                    txtItemName.Text = listBoxSuggestions.SelectedItem.ToString();
                    //popupSuggestions.IsOpen = false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "listBoxSuggestions_SelectionChanged");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtItemName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    // Handle Enter key press
                    HandleEnterKeyPress();
                }
                if (e.Key == Key.Tab)
                {
                    // Handle Tab key press
                    txtItemQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "txtItemName_PreviewKeyDown");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtItemQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Tab)
                {
                    // Handle Tab key press
                    btnAddCart.Focus();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "txtItemQuantity_KeyUp");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void listBoxSuggestions_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    // Handle Enter key press
                    HandleEnterKeyPress();
                }
                if (e.Key == Key.Tab)
                {
                    // Handle Tab key press
                    txtItemQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "listBoxSuggestions_PreviewKeyDown");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void HandleEnterKeyPress()
        {
            try
            {
                if (listBoxSuggestions.SelectedIndex != -1)
                {
                    txtItemName.Text = listBoxSuggestions.SelectedItem.ToString();
                    popupSuggestions.IsOpen = false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "HandleEnterKeyPress");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadProductNames()
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "LoadProductNames");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "DeleteItemButton_Click");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddCart_MouseDown(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "btnAddCart_MouseDown");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnAddCart_MouseEnter(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Border border)
                {
                    // Change UI elements on mouse enter
                    border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                    addIcon.Fill = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                    txtAdd.Foreground = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                    txtAdd2.Foreground = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "btnAddCart_MouseEnter");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddCart_MouseLeave(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Border border)
                {
                    // Change UI elements on mouse leave
                    border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                    addIcon.Fill = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
                    txtAdd.Foreground = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
                    txtAdd2.Foreground = (System.Windows.Media.Brush)FindResource("TextSecundaryColor");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "btnAddCart_MouseLeave");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsItemAvailableInDatabase(string itemName, int requestedQuantity)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "IsItemAvailableInDatabase");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
        }

        private decimal GetItemPriceFromDatabase(string itemName)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "GetItemPriceFromDatabase");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0.0m;
        }

        private bool UpdateQuantityInDatabase(string itemName, int quantity, string action)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "UpdateQuantityInDatabase");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (string.IsNullOrWhiteSpace(giftCardCode) || giftCardCode.StartsWith("Enter "))
            {
                MessageBox.Show("Enter a valid GiftCard code");
                return;
            }
            // Query the database to check the gift card
            decimal balance = CheckGiftCard(giftCardCode);

            if (balance >= 0)
            {
                // Gift card is valid, and its balance is returned
                GiftCardDisc = balance;

                // Update the IsActive to false in the database
                UpdateGiftCardStatus(giftCardCode);
                updatePriceLabels();
            }
            else
            {
                // Gift card is not valid or inactive
                MessageBox.Show("Invalid or inactive gift card.");
            }
        }

        private decimal CheckGiftCard(string cardCode)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "CheckGiftCard");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Gift card not found or not active
            return -1;
        }

        private void UpdateGiftCardStatus(string cardCode)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "UpdateGiftCardStatus");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        bool customerFound = false;
        private void txtCustomerName_GotFocus(object sender, RoutedEventArgs e)
        {
            try
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
                                // Using the loyalty points of customer to give discount
                                if (loyaltyPoints >= 1000)
                                {
                                    loyaltyDisc = loyaltyPoints;
                                    UpdateLoyaltyPoints(customerEmail, loyaltyPoints, "Subtract");
                                }
                                else
                                {
                                    MessageBox.Show("Loyalty Points are less than 1000");
                                }
                                updatePriceLabels();
                                customerFound = true;
                            }
                            else
                            {
                                // Customer not found, you may handle this case based on your requirements
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "txtCustomerName_GotFocus");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool UpdateLoyaltyPoints(string customerEmail, int newLoyaltyPoints, string action)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Customer SET LoyaltyPoints = LoyaltyPoints - @NewLoyaltyPoints WHERE Email = @Email";
                    if (action == "Add")
                        updateQuery = "UPDATE Customer SET LoyaltyPoints = LoyaltyPoints + @NewLoyaltyPoints WHERE Email = @Email";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Email", customerEmail);
                        updateCommand.Parameters.AddWithValue("@NewLoyaltyPoints", newLoyaltyPoints);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // The update was successful
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "POS.xaml.cs", "UpdateLoyaltyPoints");

                // Show an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
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
                // Implementing order confirmation logic here
                string productList = getProductList();
                if (string.IsNullOrEmpty(productList))
                {
                    MessageBox.Show("Add Products to cart first!");
                    return;
                }
                decimal totalAmount = cartPrice;
                decimal amount = totalPrice;
                string customerEmail = txtCustomerEmail.Text;
                string giftCardCode = txtGiftCardCode.Text;
                int loyaltyPoints = Convert.ToInt32(loyaltyDisc);

                // Insert order into the [Order] table
                int orderID = InsertOrder(productList, totalAmount);

                if (orderID == -1)
                    return;

                // Retrieve CustomerID using the provided email
                int customerID = GetCustomerIDByEmail(customerEmail);

                // Add customer if not found
                if (customerID == -1 && !string.IsNullOrEmpty(customerEmail) && !customerEmail.StartsWith("Enter "))
                {
                    addCustomer(customerEmail, txtCustomerName.Text);
                    customerID = GetCustomerIDByEmail(customerEmail);
                }

                // Retrieve GiftCardID using the provided gift card code
                int giftCardID = GetGiftCardIDByCode(giftCardCode);

                // Insert transaction into the [Transaction] table
                InsertTransaction(orderID, customerID <= 0 ? (int?)null : customerID, giftCardID <= 0 ? (int?)null : giftCardID, amount, loyaltyPoints);

                // Update loyalty points
                UpdateLoyaltyPoints(customerEmail, (int)(totalPrice * 0.03M), "Add");

                // Print the receipt
                printReceipt(customerID <= 0 ? "N/A" : customerEmail);

                // Reload or perform other actions after successful insertion
                ReloadPage();
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "btnConfirmOrder_MouseDown");
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void addCustomer(string Email, string Name)
        {
            // Handle adding a new customer to the database
            string name = Name;
            if (Name.StartsWith("Enter "))
                name = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO [Customer] (Name, Email, LoyaltyPoints, CreatedAt, UpdatedAt) VALUES (@Name, @Email, @LoyaltyPoints, GETDATE(), GETDATE())", connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@LoyaltyPoints", 0);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "addCustomer");
                MessageBox.Show($"Error adding customer: {ex.Message}");
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
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "InsertOrder");
                MessageBox.Show($"Error inserting order: {ex.Message}");
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
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "GetCustomerIDByEmail");
                MessageBox.Show($"Error getting customer ID: {ex.Message}");
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
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "GetGiftCardIDByCode");
                MessageBox.Show($"Error getting gift card ID: {ex.Message}");
                return -1;
            }
        }

        public void InsertTransaction(int orderID, int? customerID, int? giftCardID, decimal amount, int? loyaltyPoints)
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "InsertTransaction");
                MessageBox.Show($"Error inserting transaction: {ex.Message}");
            }
        }

        private string getProductList()
        {
            try
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
            catch (Exception ex)
            {
                // Log the exception and show an error message
                Exceptions.LogException(ex, "POS.xaml.cs", "getProductList");
                MessageBox.Show($"Error getting product list: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// /////////////// Printing Logic /////////////////////
        /// </summary>
        /// 

        string receiptEmail = "N/A";
        private void printReceipt(string customerEmail)
        {
            receiptEmail = "N/A";
            receiptEmail = customerEmail;

            // Create a PrintDocument instance
            PrintDocument pd = new PrintDocument();

            // Set the width to 300 and let the height be automatic
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 300, 0);

            // Hook up the PrintPage event
            pd.PrintPage += new PrintPageEventHandler(PrintReceiptPage);

            // Start printing
            pd.Print();
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            
            // Define the drawing area for the receipt content
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Use a Graphics object to draw the content
            using (Graphics g = e.Graphics)
            {               
                using (Font font = new Font("Arial", 12))
                {
                    // Draw each element of the receipt
                    g.DrawString("                 The Daily Mart", new Font("Arial", 16), System.Drawing.Brushes.Black, x, y);
                    y += 25;
                    g.DrawString("       123 Main St. , Multan Road,", new Font("Arial", 16), System.Drawing.Brushes.Black, x, y);
                    y += 25;
                    g.DrawString("         Lahore, Pakistan, 54000", new Font("Arial", 16), System.Drawing.Brushes.Black, x, y);
                    y += 25;
                    g.DrawString("----------------------------------------------------", new Font("Arial", 16), System.Drawing.Brushes.Black, x, y);
                    y += 25;

                    g.DrawString("Customer Email: " + receiptEmail, new Font("Arial", 13), System.Drawing.Brushes.Black, x, y);
                    y += 15;
                    g.DrawString("----------------------------------------------------", new Font("Arial", 16), System.Drawing.Brushes.Black, x, y);
                    y += 40;
                    g.DrawString("Name", new Font("Arial", 13), System.Drawing.Brushes.Black, x, y);
                    g.DrawString("Quantity", new Font("Arial", 13), System.Drawing.Brushes.Black, x + 205, y);
                    g.DrawString("Price", new Font("Arial", 13), System.Drawing.Brushes.Black, x + 280, y);
                    y += 30;
                    foreach (var item in cartItems)
                    {
                        g.DrawString(item.ItemName, font, System.Drawing.Brushes.Black, x, y);
                        g.DrawString(item.Quantity.ToString(), font, System.Drawing.Brushes.Black, x + 240, y);
                        g.DrawString(item.Price.ToString("C"), font, System.Drawing.Brushes.Black, x + 280, y);
                        y += 20;
                    }

                    y += 20;
                    g.DrawString("Total Price:             Rs." + cartPrice.ToString(), new Font("Arial", 13), System.Drawing.Brushes.Black, x + 100, y);
                    y += 20;
                    g.DrawString("GiftCard Discount:  Rs." + GiftCardDisc.ToString(), new Font("Arial", 13), System.Drawing.Brushes.Black, x + 100, y);
                    y += 20;
                    g.DrawString("Loyalty Discount:    Rs." + loyaltyDisc.ToString(), new Font("Arial", 13), System.Drawing.Brushes.Black, x + 100, y);
                    y += 20;
                    g.DrawString("Total Paid Amount: Rs." + totalPrice.ToString(), new Font("Arial", 13), System.Drawing.Brushes.Black, x + 100, y);
                    y += 10;


                    y += 20;
                    g.DrawString("----------------------------------------------------", new Font("Arial", 16), System.Drawing.Brushes.Black, x, y);
                    y += 20;
                    g.DrawString("THANK YOU FOR SHOPPING", new Font("Arial", 20), System.Drawing.Brushes.Black, x, y);
                    y += 40;
                    g.DrawString("                                            Print Time:" + DateTime.Now.ToString(), new Font("Arial", 10), System.Drawing.Brushes.Black, x, y);
                }
            }
        }
        private void ReloadPage()
        {
            // Create a new instance of the Users page
            POS posPage = new POS();

            // Navigate to the new instance of the Users page
            this.NavigationService.Navigate(posPage);
        }        
    }
}
