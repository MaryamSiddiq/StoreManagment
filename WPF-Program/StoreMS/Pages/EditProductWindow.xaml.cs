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

namespace StoreMS.Pages
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private ProductData editedProduct;
        public EditProductWindow(ProductData product, List<CategoryData> categories)
        {
            InitializeComponent();
            
            CBCategory.Items.Clear();
            foreach (var category in categories)
            {
                CBCategory.Items.Add(category.CategoryName);
            }

            editedProduct = product;
            // Set initial values in the UI
            txtPrice.Text = product.Price.ToString();
            txtQuantity.Text = product.Quantity.ToString();
            txtDescription.Text = product.Description.ToString();
            CBCategory.Text = product.Category;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Update the editedUser with new values
            editedProduct.Price = Decimal.Parse(txtPrice.Text);
            editedProduct.Quantity = int.Parse(txtQuantity.Text);
            editedProduct.Description = txtDescription.Text;
            editedProduct.Category = CBCategory.Text;            

            // Close the window
            Close();
        }
    }
}
