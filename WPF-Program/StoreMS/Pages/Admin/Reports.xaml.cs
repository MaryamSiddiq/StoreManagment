using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {
        public Reports()
        {
            InitializeComponent();            
        }
        private void txtLabelPlace_GotFocus(object sender, RoutedEventArgs e)
        {
            // Replace with your logic when the search TextBox gets focus
            System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)sender;
            if (textBox.Text == "Search Here...")
            {
                textBox.Text = "";
            }
        }

        private void txtLabelPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            // Replace with your logic when the search TextBox loses focus
            System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search Here...";
            }
        }

         //----------------------------------  SHOW DATAGRID in FULL-SCREEN ---------------------------------------------
        private void OpenFullScreen()
        {
            System.Windows.Controls.DataGrid dataGrid = new System.Windows.Controls.DataGrid();
            dataGrid.ItemsSource = DataGV.ItemsSource;
            dataGrid.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            Window window = new Window
            {
                WindowState = WindowState.Maximized,
                Content = dataGrid
            };
            window.ShowDialog();
        }
        private void btnFScreen_Click(object sender, RoutedEventArgs e)
        {
            OpenFullScreen();
        }

        //*******************************************************************************************************
        //******************************** READ DATA from Database (READ) ***************************************
        //*******************************************************************************************************
        string query = "";
        bool firstTime = true;
        private void readDataFromDatabase()
        {
            try
            {                
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataGV.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {                
                if (!firstTime)
                {
                    Exceptions.LogException(ex, "Reports.xaml.cs", "readDataFromDatabase");
                    System.Windows.MessageBox.Show(ex.Message);
                }
                firstTime = false;
            }
            
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                readDataFromDatabase();
                if (DataGV != null)
                {
                    var filteredData = from item in DataGV.ItemsSource.Cast<DataRowView>()
                                       where item.Row.ItemArray.Any(field => field.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                                       select item;
                    DataGV.ItemsSource = filteredData;
                }
                
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Reports.xaml.cs", "txtSearch_TextChanged");
                System.Windows.MessageBox.Show(ex.Message);
            }
            
        }

        private void CBReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBReport.SelectedIndex == 2)
            {
                query = "SELECT Name, Price, Category, Quantity FROM [Product] WHERE Quantity < 100; ";
            }
            else if (CBReport.SelectedIndex == 1)
            {
                query = "SELECT Name, Price, Category, Quantity FROM Product;";
            }
            else if (CBReport.SelectedIndex == 3)
            {
                query = "SELECT Name, Username, Role, CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Non-Active' END AS [Account Status] FROM [User] ORDER BY IsActive DESC; ";
            }
            else if (CBReport.SelectedIndex == 4)
            {
                query = "Select Name, Email, LoyaltyPoints from Customer; ";
            }
            else if (CBReport.SelectedIndex == 5)
            {
                query = "SELECT CONVERT(date, CreatedAt) AS[Date], SUM(Amount) AS Revenue FROM [Transaction] GROUP BY CONVERT(date, CreatedAt) ORDER BY [Date] DESC; ";
            }
            else if (CBReport.SelectedIndex == 6)
            {
                query = "SELECT FORMAT(CreatedAt, 'MM-yyyy') AS[Month], SUM(Amount) AS Revenue FROM [Transaction] GROUP BY FORMAT(CreatedAt, 'MM-yyyy') ORDER BY [Month] DESC; ";             
            }
            else if (CBReport.SelectedIndex == 7)
            {                
                query = "WITH ProductSales AS ( SELECT O.ID AS OrderID, P.Category, SUM(P.Price * CONVERT(INT, PARSENAME(REPLACE(Split.value, '-', '.'), 1))) AS TotalSales FROM [Order] O CROSS APPLY STRING_SPLIT(O.ProductsList, ':') Split INNER JOIN Product P ON LEFT(Split.value, CHARINDEX('-', Split.value) - 1) = P.Name GROUP BY O.ID, P.Category) " +
                    "SELECT Category, SUM(TotalSales) AS Revenue FROM ProductSales GROUP BY Category; ";
            }
            if (CBReport.SelectedIndex > 0)
            {
                readDataFromDatabase();                
            }
        }
        //**************************************************************************************************************
        //********************************************** OPERATIONS ****************************************************
        //**************************************************************************************************************

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            readDataFromDatabase();
        }

        private void btnDownload_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CBReport.SelectedIndex == 2)
                DownloadLowQuantityReport();
            else if (CBReport.SelectedIndex == 1)
                DownloadAllProductsReport();
            else if (CBReport.SelectedIndex == 3)
                DownloadUsersReport();
            else if (CBReport.SelectedIndex == 4)
                DownloadCustomersReport();
            else if (CBReport.SelectedIndex == 5)
                DownloadRevenueByDateReport();
            else if (CBReport.SelectedIndex == 6)
                DownloadRevenueByMonthReport();
            else if (CBReport.SelectedIndex == 7)
                DownloadRevenueByCategoryReport();            
            else
            {
                System.Windows.MessageBox.Show("Select Report!");
                return;
            }
        }
        private bool validateId(string TableName, int AId)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM " + TableName + " WHERE Id = @AId", con);
            cmd.Parameters.AddWithValue("@AId", AId);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
                return true;
            else
                return false;
        }
        private DataTable GetDataGridAsDataTable(System.Windows.Controls.DataGrid dg)
        {
            DataTable dt = new DataTable();

            // Add columns to DataTable
            foreach (DataGridColumn column in dg.Columns)
            {
                if (column is DataGridTextColumn)
                {
                    DataGridTextColumn textColumn = column as DataGridTextColumn;
                    dt.Columns.Add(textColumn.SortMemberPath, typeof(string));
                }
                else if (column is DataGridComboBoxColumn)
                {
                    DataGridComboBoxColumn comboColumn = column as DataGridComboBoxColumn;
                    dt.Columns.Add(comboColumn.SortMemberPath, typeof(string));
                }
                // Add more conditions for other column types as needed
            }

            // Add rows to DataTable
            foreach (object item in dg.Items)
            {
                DataRowView row = item as DataRowView;
                if (row != null)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (DataGridColumn column in dg.Columns)
                    {
                        if (column is DataGridTextColumn)
                        {
                            DataGridTextColumn textColumn = column as DataGridTextColumn;
                            newRow[textColumn.SortMemberPath] = row[textColumn.SortMemberPath];
                        }
                        else if (column is DataGridComboBoxColumn)
                        {
                            DataGridComboBoxColumn comboColumn = column as DataGridComboBoxColumn;
                            newRow[comboColumn.SortMemberPath] = row[comboColumn.SortMemberPath];
                        }
                        // Add more conditions for other column types as needed
                    }
                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }
        private void addTableToDocument(DataTable dt, Document document)
        {
            // Create a font object with size 12
            var font = new Font(Font.FontFamily.TIMES_ROMAN, 9);
            var headFont = new Font(Font.FontFamily.TIMES_ROMAN, 11, Font.BOLD);

            // Create a new table
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.WidthPercentage = 100;

            // Add table columns with the font
            foreach (DataColumn column in dt.Columns)
            {
                Phrase phrase = new Phrase(column.ColumnName, headFont);

                // Add the phrase to the cell and set background color
                PdfPCell cell = new PdfPCell(phrase);
                cell.BackgroundColor = new BaseColor(230, 230, 230);
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cell);
            }

            // Add table rows with the font
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    var cell = new PdfPCell(new Phrase(row[column].ToString(), font));
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);
                }
            }

            // Add the table to the PDF document
            document.Add(table);
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------ Low Quantity REPORT ---------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadLowQuantityReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "Low Quantity Products";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addLowQuantityTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addLowQuantityTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Low Quantity Products Report", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nLow Quantity Product Report consists of a table given below. " +
                        "\nThe given table contains (in order): \n" +
                        "   - Name of the Product\n" +
                        "   - Price of the Product\n" +
                         "   - Category of the Product\n" +
                        "   - Quantity of the Product\n\n\n";

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------ Products REPORT -------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadAllProductsReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "Products Report";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addProductsTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addProductsTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Products Report", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nProducts Report consists of a table given below. " +
                        "\nThe given table contains (in order): \n" +
                        "   - Name of the Product\n" +
                        "   - Price of the Product\n" +
                         "   - Category of the Product\n" +
                        "   - Quantity of the Product\n\n\n";

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------ Users Details REPORT --------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadUsersReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "UsersReport";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addUsersTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addUsersTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Users Details", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nUser Details Report consists of all the user details available in the system. It consists of the following table given below. " +
                                    "\nThe given table contains (in order): \n" +
                                    "   - Name\n" +
                                    "   - Username\n" +
                                    "   - Role\n" +
                                    "   - Account Status\n\n\n";

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }
        //------------------------------------------------------------------------------------------------------
        //-------------------------------------- Customers REPORT ----------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadCustomersReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "CustomersReport";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addCustomersTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addCustomersTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Customers Details Report", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nCustomer Details Report consists of all the customer details available in the system. It consists of the following table given below. " +
                                    "\nThe given table contains (in order): \n" +
                                    "   - Customer Name\n" +
                                    "   - Email\n" +
                                    "   - Loyalty Points\n\n";

            // You can customize the rest of the paragraph based on your requirements

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------ RevenueByDate REPORT ----------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadRevenueByDateReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "RevenueByDateReport";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addRevenueByDateTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addRevenueByDateTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Revenue by Day Report", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nRevenue by Day Report consist of all the revenues generated on mentioned date. It consists of following table given below. " +
                                    "\nThe given table contains (in order): \n" +
                                    "   - Date of month\n" +
                                    "   - Revenue Generated in that date\n\n";                                    
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------ RevenueByMonth REPORT ----------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadRevenueByMonthReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "RevenueByMonthReport";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addRevenueByMonthTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addRevenueByMonthTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Revenue by Month Report", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nRevenue by Month Report consist of all the revenues generated on mentioned month. It consists of following table given below. " +
                                   "\nThe given table contains (in order): \n" +
                                   "   - Month of the Year\n" +
                                   "   - Revenue Generated in that date\n\n";
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------ RevenueByCategory REPORT --------------------------------------------
        //------------------------------------------------------------------------------------------------------

        private void DownloadRevenueByCategoryReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4);
            SaveFileDialog openDialog = new SaveFileDialog();
            openDialog.Filter = "Portable Document File |*.pdf;";
            openDialog.RestoreDirectory = true;
            openDialog.FileName = "RevenueByCategoryReport";
            String filename;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openDialog.FileName;
            }
            else
            {
                return;
            }

            addRevenueByCategoryTableInDocument(document, filename);

            // Close the PDF document
            document.Close();
        }

        private void addRevenueByCategoryTableInDocument(Document document, string filename)
        {
            DataTable dt = GetDataGridAsDataTable(DataGV);
            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            // Open the PDF document
            document.Open();

            // Adding the heading
            Chunk heading = new Chunk("Revenue By Category Report", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            iTextSharp.text.Paragraph headingParagraph = new iTextSharp.text.Paragraph(heading);
            headingParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(headingParagraph);

            string paragraphText = "\nRevenue by Category Report consist of all the revenues generated with that category's product. It consists of following table given below. " +
                                   "\nThe given table contains (in order): \n" +
                                   "   - Category of Product\n" +
                                   "   - Revenue Generated with that category of products\n\n"; 
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(paragraphText);
            paragraph.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(paragraph);

            addTableToDocument(dt, document);
        }        
    }
}
