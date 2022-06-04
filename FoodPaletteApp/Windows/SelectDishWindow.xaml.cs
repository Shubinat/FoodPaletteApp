using FoodPaletteApp.Entities;
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

namespace FoodPaletteApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectDishWindow.xaml
    /// </summary>
    public partial class SelectDishWindow : Window
    {
        public Dish SelectedDish => CBoxDish.SelectedItem as Dish;
        public SelectDishWindow()
        {
            InitializeComponent();
            CBoxDish.ItemsSource = App.Context.Dish.ToList();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = SelectedDish != null;
        }
    }
}
