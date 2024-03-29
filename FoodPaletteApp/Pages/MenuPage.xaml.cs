﻿using System;
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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnDishes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DishListPage());
        }

        private void BtnMyProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());

        }

        private void BtnStat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CaloriesStatPage());

        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage());

        }

        private void BtnProductsList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }
    }
}
