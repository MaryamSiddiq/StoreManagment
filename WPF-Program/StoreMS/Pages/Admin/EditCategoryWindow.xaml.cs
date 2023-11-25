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
using System.Windows.Shapes;

namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private CategoryData editedCategory;
        public EditCategoryWindow(CategoryData category)
        {
            InitializeComponent();
            editedCategory = category;

            // Set initial values in the UI
            txtNewName.Text = category.CategoryName;            
        }        
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Update the editedUser with new values
            editedCategory.CategoryName = txtNewName.Text;
            
            // Close the window
            Close();
        }
    }
}
