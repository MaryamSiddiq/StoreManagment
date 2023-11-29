using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace StoreMS.Pages.Admin
{
    public partial class Dashboard : Page
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=StoreMS;Integrated Security=True";
        public PlotModel BarChartModel { get; set; }
        public PlotModel LineChartModel { get; set; }

        public Dashboard()
        {
            InitializeComponent();

            try
            {
                // Display today's sales and revenue
                lblSales.Content = GetTodaySales() + " Products";
                lblRevenue.Content = "Rs. " + GetTodayRevenue();

                // Read category data for the bar chart
                ReadCategoryData();

                // Get transaction data for the line chart
                var salesData = GetTransactionsFromDatabase();

                // Line Chart
                LineChartModel = new PlotModel { Title = "Sales Chart" };

                // X-axis (DateTimeAxis)
                var xAxisLine = new DateTimeAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Date",
                    StringFormat = "dd-MM-yyyy",
                    IntervalType = DateTimeIntervalType.Days,
                    MajorStep = 3,
                };
                LineChartModel.Axes.Add(xAxisLine);

                // Y-axis (LinearAxis)
                var yAxisLine = new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Sales Revenue",
                    Minimum = 0,
                };
                LineChartModel.Axes.Add(yAxisLine);

                // Line Series
                var lineSeries = new LineSeries
                {
                    ItemsSource = salesData,
                    DataFieldX = "Date",
                    DataFieldY = "Revenue",
                };

                LineChartModel.Series.Add(lineSeries);

                DataContext = this;
            }
            catch (Exception ex)
            {
                // Log the exception
                Exceptions.LogException(ex, "Dashboard", "Constructor");
                // Display an error message to the user
                MessageBox.Show(ex.Message);
            }
        }

        private List<DataPoint> GetTransactionsFromDatabase()
        {
            var transactions = new List<DataPoint>();

            try
            {
                string query = "SELECT CONVERT(date, CreatedAt) AS[Date], SUM(Amount) AS Revenue FROM [Transaction] GROUP BY CONVERT(date, CreatedAt) ORDER BY [Date] DESC; ";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataPoint transaction = new DataPoint(DateTimeAxis.ToDouble(Convert.ToDateTime(reader["Date"].ToString())), Double.Parse(reader["Revenue"].ToString()));
                                //DataPoint transaction = new DataPoint(DateTimeAxis.ToDouble(Convert.ToDateTime("2022-03-03")), 100);
                                transactions.Add(transaction);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Dashboard", "GetTransactionsFromDatabase");
                // Display an error message to the user
                MessageBox.Show(ex.Message);
            }

            return transactions;
        }

        private void ReadCategoryData()
        {
            var values = new List<int>();
            var categories = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ReadCategoryData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Check for DBNull before converting to int
                                int salesPercentage = reader["SalesPercentage"] != DBNull.Value
                                    ? Convert.ToInt32(reader["SalesPercentage"])
                                    : 0;

                                string category = reader["Category"].ToString();

                                // Add data to lists
                                values.Add(salesPercentage);
                                categories.Add(category);
                            }
                        }
                    }
                    connection.Close();
                }

                // Bar Chart
                BarChartModel = new PlotModel { Title = "Revenue by Category" };

                // Y-axis (CategoryAxis)
                var yAxisBar = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    ItemsSource = categories
                };
                BarChartModel.Axes.Add(yAxisBar);

                // X-axis (LinearAxis with a maximum value of 100)
                var xAxisBar = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Maximum = 100
                };
                BarChartModel.Axes.Add(xAxisBar);

                // Bar Series
                var barSeries = new BarSeries
                {
                    ItemsSource = values.Select((value, index) => new BarItem { Value = value }),
                    LabelFormatString = "{0}"
                };

                BarChartModel.Series.Add(barSeries);

                // Assign the model to the plot view
                BarChart.Model = BarChartModel;
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Dashboard", "ReadCategoryData");
                // Display an error message to the user
                MessageBox.Show(ex.Message);
            }
        }

        private string GetTodayRevenue()
        {
            string todayRevenue = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Amount) AS TodayRevenue FROM [Transaction] WHERE CAST(CreatedAt AS DATE) = CAST(GETDATE() AS DATE);", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                todayRevenue = reader["TodayRevenue"].ToString();
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Dashboard", "GetTodayRevenue");
                // Display an error message to the user
                MessageBox.Show(ex.Message);
            }

            return todayRevenue;
        }

        private string GetTodaySales()
        {
            string todaySales = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetTodaySales", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                todaySales = reader["TodaySales"].ToString();
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex, "Dashboard", "GetTodaySales");
                // Display an error message to the user
                MessageBox.Show(ex.Message);
            }

            return todaySales;
        }
    }
}
