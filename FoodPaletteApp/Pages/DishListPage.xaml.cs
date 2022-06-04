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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodPaletteApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DishListPage.xaml
    /// </summary>
    public partial class DishListPage : Page
    {
        public DishListPage()
        {
            InitializeComponent();
            List<Entities.DishType> dishTypes = App.Context.DishType.ToList();
            dishTypes.Insert(0, new Entities.DishType() { Name = "Все" });
            CBoxDishType.ItemsSource = dishTypes;
            CBoxDishType.SelectedIndex = 0;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var dish = LviewDishes.SelectedItem as Entities.Dish;
            App.Context.Dish.Remove(dish);
            App.Context.SaveChanges();
            UpdateGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dish = LviewDishes.SelectedItem as Entities.Dish;
            NavigationService.Navigate(new DishEditorPage(dish));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DishEditorPage());
        }

        private void CBoxDishType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGrid();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGrid();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            List<Entities.Dish> dishes = App.Context.Dish.ToList();

            if (!string.IsNullOrEmpty(TBoxSearch.Text))
                dishes = dishes.Where(dish => dish.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if(CBoxDishType.SelectedIndex != 0)
                dishes =  dishes.Where((dish) => dish.DishType == CBoxDishType.SelectedItem).ToList();
            
            LviewDishes.ItemsSource = dishes;
        }

        private void LviewDishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = LviewDishes.SelectedItem != null;
            BtnDelete.IsEnabled = value;
            BtnEdit.IsEnabled = value;
        }
    }
}
