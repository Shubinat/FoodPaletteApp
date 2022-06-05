using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FoodPaletteApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Возникла непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static Entities.FoodPaletteBaseEntities Context { get; set; } = new Entities.FoodPaletteBaseEntities();
        public static Entities.User AuthUser { get; set; }
    }
}
