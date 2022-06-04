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
        public static Entities.FoodPaletteBaseEntities Context { get; set; } = new Entities.FoodPaletteBaseEntities();
        public static Entities.User AuthUser { get; set; }
    }
}
