using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreMS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class AdminHP : Window
    {
        Uri Dashboard;
        Uri Users;
        Uri Products;
        Uri Customers;
        Uri Categories;
        Uri GiftCards;
        Uri Transactions;
        Uri Reports;
        Uri Logs;
        
        public AdminHP()
        {
            InitializeComponent();
            Dashboard = new Uri("Pages/Admin/Dashboard.xaml", UriKind.RelativeOrAbsolute);
            Users = new Uri("Pages/Admin/Users.xaml", UriKind.RelativeOrAbsolute);
            Products = new Uri("Pages/Admin/Products.xaml", UriKind.RelativeOrAbsolute);
            Customers = new Uri("Pages/Admin/Customers.xaml", UriKind.RelativeOrAbsolute);
            Categories = new Uri("Pages/Admin/Categories.xaml", UriKind.RelativeOrAbsolute);
            GiftCards = new Uri("Pages/Admin/GiftCards.xaml", UriKind.RelativeOrAbsolute);
            Transactions = new Uri("Pages/Admin/Transactions.xaml", UriKind.RelativeOrAbsolute);            
            Reports = new Uri("Pages/Admin/Reports.xaml", UriKind.RelativeOrAbsolute);            
            Logs = new Uri("Pages/Admin/Logs.xaml", UriKind.RelativeOrAbsolute);            
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnDashboard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnDashboard;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Dashboard";
            }
        }

        private void btnDashboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnUser_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnUser;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Users";
            }
        }

        private void btnUser_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnProduct_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnProduct;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Products";
            }
        }

        private void btnProduct_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }              
        private void btnCustomer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnCustomer;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Customers";
            }
        }

        private void btnCustomer_MouseLeave(object sender, MouseEventArgs e)
        {
            
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        

        private void btnGiftCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnGiftCard;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Gift Cards";
            }
        }

        private void btnGiftCard_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnTransaction_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnTransaction;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Transactions";
            }
        }

        private void btnTransaction_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        private void btnReport_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnReport;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Reports";
            }
        }

        private void btnReport_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        
        private void btnLogs_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnLogs;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Logs";
            }
        }

        private void btnLogs_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
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

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Dashboard);
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Users);           
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Products);            
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Categories);
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Customers);            
        }

        private void btnGiftCard_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(GiftCards);            
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Transactions);
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Reports);
        }    
        private void btnLogs_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(Logs);
        }        
       
    }
}
