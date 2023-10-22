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
        Uri Student;
        Uri Advisor;
        Uri Project;
        Uri Group;
        Uri SGroup;
        Uri AssignProject;
        Uri AssignAdvisor;
        Uri Evaluation;
        Uri MarkEvaluation;
        Uri Report;

        public AdminHP()
        {
            InitializeComponent();
            Student = new Uri("Pages/Student.xaml", UriKind.RelativeOrAbsolute);            
            Advisor = new Uri("Pages/Advisor.xaml", UriKind.RelativeOrAbsolute);
            Project = new Uri("Pages/Project.xaml", UriKind.RelativeOrAbsolute);
            Group = new Uri("Pages/Group.xaml", UriKind.RelativeOrAbsolute);
            SGroup = new Uri("Pages/SGroup.xaml", UriKind.RelativeOrAbsolute);
            AssignProject = new Uri("Pages/AssignProject.xaml", UriKind.RelativeOrAbsolute);
            AssignAdvisor = new Uri("Pages/AssignAdvisor.xaml", UriKind.RelativeOrAbsolute);
            Evaluation = new Uri("Pages/Evaluation.xaml", UriKind.RelativeOrAbsolute);
            MarkEvaluation = new Uri("Pages/MarkEvaluation.xaml", UriKind.RelativeOrAbsolute);
            Report = new Uri("Pages/Report.xaml", UriKind.RelativeOrAbsolute);            
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnAuthor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnAuthor;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Authors";
            }
        }

        private void btnAuthor_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnPublisher_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnPublisher;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Publishers";
            }
        }

        private void btnPublisher_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnGenre_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnGenre;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Genres";
            }
        }

        private void btnGenre_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }      

        private void btnCategory_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnCategory;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Categories";
            }
        }
        private void btnCategory_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        private void btnBooks_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnBooks;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Books";
            }
        }

        private void btnBooks_MouseLeave(object sender, MouseEventArgs e)
        {
            
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        

        private void btnInventory_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnInventory;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Inventory";
            }
        }

        private void btnInventory_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnLibrarian_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnLibrarian;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Librarians";
            }
        }

        private void btnLibrarian_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        private void btnReturnBook_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnReturnBook;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Return Books";
            }
        }

        private void btnReturnBook_MouseLeave(object sender, MouseEventArgs e)
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

        private void btnAuthor_Click(object sender, RoutedEventArgs e)
        {
            //fContainer.Navigate(Student);
        }

        private void btnPublisher_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnGenre_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
                      
        }

        private void btnLibrarian_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            
        }    
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {            

        }        
       
    }
}
