using System.Collections.Generic;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace StoreMS.Pages.Admin
{
    public partial class Dashboard : Page
    {
        public SeriesCollection TodaySalesSeries { get; set; }
        public SeriesCollection SalesByCategorySeries { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            DataContext = this;

            // Set up sample data (replace with your actual data)
            TodaySalesSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Today's Sales",
                    Values = new ChartValues<double> { 10, 15, 7, 12, 8 }
                }
            };

            SalesByCategorySeries = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Category A",
                    Values = new ChartValues<double> { 10 },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Category B",
                    Values = new ChartValues<double> { 15 },
                    DataLabels = true
                },
                // Add more categories as needed
            };
        }
    }
}
