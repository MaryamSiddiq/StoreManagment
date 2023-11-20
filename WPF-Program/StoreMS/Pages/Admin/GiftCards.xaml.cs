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


namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for GiftCards.xaml
    /// </summary>
    public partial class GiftCards : Page
    {
        List<GiftCardData> giftCards = new List<GiftCardData>();

        public GiftCards()
        {
            InitializeComponent();

            // Sample gift card data
            giftCards = new List<GiftCardData>
            {
                new GiftCardData { CardCode = "ABC123", Balance = 50.0, IsActive = true },
                new GiftCardData { CardCode = "DEF456", Balance = 25.0, IsActive = false },
                // Add more gift card data as needed
            };

            // Sort the gift cards by CardCode
            giftCards = giftCards
                .OrderBy(card => card.CardCode)
                .ToList();

            giftCardDataGrid.ItemsSource = giftCards;
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
            if (txtGiftCardSearch.Text.Length <= 0)
                txtGiftCardSearch.Text = "Search Here...";
        }
        private void btnGenerateCards_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("TertiaryBackgroundColor");
                generateIcon.Fill = (Brush)FindResource("PrimaryBackgroundColor");
                txtGenerate.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
                txtGenerate2.Foreground = (Brush)FindResource("PrimaryBackgroundColor");
            }
        }

        private void btnGenerateCards_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (System.Windows.Media.Brush)FindResource("PrimaryBackgroundColor");
                generateIcon.Fill = (Brush)FindResource("TextSecundaryColor");
                txtGenerate.Foreground = (Brush)FindResource("TextSecundaryColor");
                txtGenerate2.Foreground = (Brush)FindResource("TextSecundaryColor");
            }
        }

        private void btnGenerateCards_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic to generate gift cards
            try
            {
                // Get the number of cards to generate
                int numberOfCards = int.Parse(txtNumberOfCards.Text);

                // Generate new gift cards
                for (int i = 0; i < numberOfCards; i++)
                {
                    string cardCode = GenerateRandomCardCode();
                    double balance = GenerateRandomBalance();
                    bool isActive = true;

                    // Add the new gift card to the list
                    giftCards.Add(new GiftCardData { CardCode = cardCode, Balance = balance, IsActive = isActive });
                }

                // Refresh the DataGrid to reflect the changes
                giftCardDataGrid.ItemsSource = null;
                giftCardDataGrid.ItemsSource = giftCards;

                // Optionally, you can save the generated cards to a database or file.
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for the number of cards.");
            }
        }

        private string GenerateRandomCardCode()
        {
            // Implement your logic to generate a random card code
            // This is just a placeholder, you might want to use a more sophisticated algorithm
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        private double GenerateRandomBalance()
        {
            // Implement your logic to generate a random balance
            // This is just a placeholder, you might want to use a more sophisticated algorithm
            Random random = new Random();
            return random.Next(10, 1000);
        }

        private void txtGiftCardSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Get the search text from the TextBox
                string searchText = txtGiftCardSearch.Text;

                // Implement your search logic using LINQ to filter your data source based on searchText
                if (!string.IsNullOrWhiteSpace(searchText) && searchText != "Search Here...")
                {
                    var filteredData = giftCards.Where(card =>
                        card.CardCode != null && card.CardCode.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        card.Balance.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 || // Convert to string before checking
                        card.IsActive.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();

                    // Update the DataGrid with the filtered data
                    giftCardDataGrid.ItemsSource = filteredData;
                }
                else if (giftCardDataGrid != null)
                {
                    // If the search text is empty, reset the DataGrid to the original data source
                    giftCardDataGrid.ItemsSource = giftCards;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here or add logging as needed
            }
        }
    }

    public class GiftCardData
    {
        public string CardCode { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
