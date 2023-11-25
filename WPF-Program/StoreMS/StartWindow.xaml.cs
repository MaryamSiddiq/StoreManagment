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
        public StartWindow()
        {
            
            InitializeComponent();
            CBRole.Focus();     
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
    }
}
