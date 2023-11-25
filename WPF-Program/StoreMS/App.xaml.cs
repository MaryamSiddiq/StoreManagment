using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreMS
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Subscribe to the UnhandledException event
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Your other startup logic here
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;

            if (exception != null)
            {
                // Log the exception using your LogException method
                Exceptions.LogException(exception, "App.xaml.cs", "UnhandledException");

                // Optionally: Display a user-friendly error message or perform other actions
                MessageBox.Show("An unexpected error occurred. Please contact support.");
            }
        }
    }
}
