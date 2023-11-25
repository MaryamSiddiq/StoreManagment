﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using StoreMS;

namespace StoreMS.Pages.Admin
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        List<TransactionData> transactions = new List<TransactionData>();
        public Transactions()
        {
            InitializeComponent();
            loadTransactionData();
        }

        private void loadTransactionData()
        {
            DataGrid.ItemsSource = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT o.ProductsList, ISNULL(c.Email, 'N/A') AS Email, o.TotalAmount, ISNULL(g.Balance, 0) AS GiftCardDiscount, ISNULL(t.LoyaltyPrice, 0) AS LoyaltyDiscount, t.Amount AS PaidAmount, t.CreatedAt AS TransactionDate FROM [Transaction] t Left JOIN Customer c ON c.ID = t.CustomerID Left JOIN GiftCard g ON g.ID = t.GiftCardID JOIN [Order] o ON o.ID = t.OrderID ORDER BY t.CreatedAt DESC;", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string ProductsList = row["ProductsList"].ToString();
                            string CustomerEmail = row["Email"].ToString();
                            decimal TotalAmount = Convert.ToDecimal(row["TotalAmount"]);
                            decimal GiftCardDiscount = Convert.ToDecimal(row["GiftCardDiscount"]);
                            int LoyaltyDiscount = Convert.ToInt32(row["LoyaltyDiscount"]);
                            decimal PaidAmount = Convert.ToDecimal(row["PaidAmount"]);
                            DateTime DateTime = Convert.ToDateTime(row["TransactionDate"]);
                            TransactionData td = new TransactionData(ProductsList, CustomerEmail, TotalAmount, GiftCardDiscount, LoyaltyDiscount, PaidAmount, DateTime);
                            transactions.Add(td);
                        }
                    }
                }

                connection.Close();
            }

            DataGrid.ItemsSource = transactions;
            DataGrid.Items.Refresh();
        }        
    }
}
