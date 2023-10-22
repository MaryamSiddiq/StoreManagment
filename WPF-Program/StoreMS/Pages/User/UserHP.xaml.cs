using System;
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
    public partial class UserHP : Window
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

        public UserHP()
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
        private void btnBorrowBook_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnBorrowBook;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Borrow Book";
            }
        }

        private void btnBorrowBook_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnRequestBook_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnRequestBook;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Request Book";
            }
        }

        private void btnRequestBook_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnReviewBook_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnReviewBook;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Review Book";
            }
        }

        private void btnReviewBook_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }      

        private void btnLists_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnLists;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Lists";
            }
        }
        private void btnLists_MouseLeave(object sender, MouseEventArgs e)
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
        
        private void btnBorrowBook_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRequestBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReviewBook_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnLists_Click(object sender, RoutedEventArgs e)
        {
            //fContainer.Navigate(Student);
        }
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {            

        }        
       
    }
}
