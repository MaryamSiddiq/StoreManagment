using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreMS.Pages.User
{
    public partial class Inventory : Page
    {
        public ObservableCollection<Item> Items { get; set; }

        public Inventory()
        {
            InitializeComponent();

            // Initialize the ObservableCollection with example items
            Items = new ObservableCollection<Item>
            {
                new Item { ItemName = "Item1", Price = 10.99, Quantity = 50 },
                new Item { ItemName = "Item2", Price = 25.50, Quantity = 30 },
                new Item { ItemName = "Item3", Price = 5.99, Quantity = 100 },
            };

            // Set the DataGrid's ItemsSource to the ObservableCollection
            itemDataGrid.ItemsSource = Items;
        }

        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            // Replace with your logic when the search TextBox gets focus
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Search Here...")
            {
                textBox.Text = "";
            }
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            // Replace with your logic when the search TextBox loses focus
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search Here...";
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Replace with your logic when the search TextBox text changes
            string searchText = txtSearch.Text.ToLower(); // Convert the search text to lowercase for case-insensitive comparison

            // Filter the items based on the search text
            var filteredItems = Items.Where(item => item.ItemName.ToLower().Contains(searchText)
                                                || item.Price.ToString().Contains(searchText)
                                                || item.Quantity.ToString().Contains(searchText));

            // Update the DataGrid's ItemsSource with the filtered items
            itemDataGrid.ItemsSource = filteredItems.ToList();
        }

    }

    // Example Item class
    public class Item
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
