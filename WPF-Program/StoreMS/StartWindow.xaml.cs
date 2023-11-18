using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StoreMS.Pages;

namespace StoreMS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        ItemsControl ReceiptItems = new ItemsControl();
        public StartWindow()
        {
            
            InitializeComponent();
            CBRole.Focus();
            List<ReceiptItem> items = new List<ReceiptItem>
            {
                new ReceiptItem { Name = "Item 1", Price = 25.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
                new ReceiptItem { Name = "Item 2", Price = 30.00M },
            };

            ReceiptItems.ItemsSource = items;
        }               
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBRole.SelectedIndex == 1)
            {
                // Pass the string as a parameter when navigating to SignInL.
                SignIn signInLPage = new SignIn("Admin");
                fContainer.Navigate(signInLPage);
            }
            else if (CBRole.SelectedIndex == 2)
            {
                // Pass the string as a parameter when navigating to SignInL.
                SignIn signInLPage = new SignIn("Cashier");
                fContainer.Navigate(signInLPage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintReceiptPage);
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
                    g.DrawString("The Daily Mart", new Font("Arial", 16), Brushes.Black, x, y);
                    y += 25;
                    g.DrawString("123 Main St. , Multan Road,", new Font("Arial", 16), Brushes.Black, x, y);
                    y += 25;
                    g.DrawString("Lahore, Pakistan, 54000", new Font("Arial", 16), Brushes.Black, x, y);
                    y += 30;

                    foreach (ReceiptItem item in ReceiptItems.ItemsSource)
                    {
                        g.DrawString(item.Name, font, Brushes.Black, x, y);
                        g.DrawString(item.Price.ToString("C"), font, Brushes.Black, x + 120, y);
                        y += 20;
                    }

                    g.DrawString("Total: $100.00", font, Brushes.Black, x, y);

                    y += 40;
                    g.DrawString("THANK YOU FOR SHOPPING", new Font("Arial", 20), Brushes.Black, x, y);
                }
            }
        }
    }
}

public class ReceiptItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
