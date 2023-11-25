﻿using System;
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
    public class GiftCardData
    {
        public string CardCode { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }

    public partial class GiftCards : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        private List<GiftCardData> giftCards = new List<GiftCardData>();
        private string text = null;

        public GiftCards()
        {
            InitializeComponent();
            LoadGiftCardData();
        }

        private void LoadGiftCardData()
        {
            giftCardDataGrid.ItemsSource = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [GiftCard]", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            giftCards.Add(new GiftCardData
                            {
                                CardCode = row["CardCode"].ToString(),
                                Balance = Convert.ToDecimal(row["Balance"]),
                                IsActive = Convert.ToBoolean(row["IsActive"])
                            });
                        }
                    }
                }
                connection.Close();
            }

            giftCardDataGrid.ItemsSource = giftCards;
            giftCardDataGrid.Items.Refresh();
        }

        private void GenerateGiftCards(int numberOfCards)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    for (int i = 0; i < numberOfCards; i++)
                    {
                        string cardCode = GenerateCardCode();
                        decimal initialBalance = decimal.Parse(txtBalance.Text);
                        bool isActive = true;

                        using (SqlCommand command = new SqlCommand("INSERT INTO [GiftCard] (CardCode, Balance, IsActive, CreatedAt, UpdatedAt) VALUES (@CardCode, @Balance, @IsActive, GETDATE(), GETDATE())", connection))
                        {
                            command.Parameters.AddWithValue("@CardCode", cardCode);
                            command.Parameters.AddWithValue("@Balance", initialBalance);
                            command.Parameters.AddWithValue("@IsActive", isActive);
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
                MessageBox.Show($"{numberOfCards} Gift Cards Generated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GenerateCardCode()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                while (true)
                {
                    // Generate a random card code
                    Random random = new Random();
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    string newCardCode = new string(Enumerable.Repeat(chars, 12)
                        .Select(s => s[random.Next(s.Length)]).ToArray());

                    // Check if the generated card code already exists in the database
                    using (SqlCommand checkCardCodeCommand = new SqlCommand("SELECT COUNT(*) FROM [GiftCard] WHERE CardCode = @CardCode", connection))
                    {
                        checkCardCodeCommand.Parameters.AddWithValue("@CardCode", newCardCode);
                        int count = (int)checkCardCodeCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            // Card code is unique, return it
                            return newCardCode;
                        }
                    }
                }
            }
        }


        private void DeleteGiftCard(string cardCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string deleteGiftCardQuery = "DELETE FROM [GiftCard] WHERE CardCode = @CardCode";
                    using (SqlCommand deleteGiftCardCommand = new SqlCommand(deleteGiftCardQuery, connection))
                    {
                        deleteGiftCardCommand.Parameters.AddWithValue("@CardCode", cardCode);
                        deleteGiftCardCommand.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Gift Card Deleted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (giftCardDataGrid.SelectedItem != null)
            {
                var selectedItem = (GiftCardData)giftCardDataGrid.SelectedItem;
                DeleteGiftCard(selectedItem.CardCode);
            }
            else
            {
                MessageBox.Show("Please select a gift card to delete.");
            }
            ReloadPage();
        }

        private void btnGenerateCards_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (int.TryParse(txtNumberOfCards.Text, out int numberOfCards))
            {
                GenerateGiftCards(numberOfCards);
            }
            else
            {
                MessageBox.Show("Please enter a valid number of cards.");
            }
            ReloadPage();
        }

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
            txtGiftCardSearch.Text = "Search Here...";
        }

        private void txtGiftCardSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = txtGiftCardSearch.Text;

                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = giftCards
                        .Where(item =>
                            (item.CardCode != null && item.CardCode.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.Balance.ToString() != null && item.Balance.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (item.IsActive.ToString() != null && item.IsActive.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                        .ToList();

                    giftCardDataGrid.ItemsSource = filteredData;
                }
                else if (giftCardDataGrid != null)
                {
                    giftCardDataGrid.ItemsSource = giftCards;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGenerateCards_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("TertiaryBackgroundColor");
                generateIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtGenerate.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                txtGenerate2.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnGenerateCards_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)FindResource("PrimaryBackgroundColor");
                generateIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtGenerate.Foreground = (Brush)FindResource("TextSecundaryColor");
                txtGenerate2.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }

        private void ReloadPage()
        {
            GiftCards giftCardsPage = new GiftCards();
            this.NavigationService.Navigate(giftCardsPage);
        }
    }
}
