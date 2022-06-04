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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodPaletteApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            LViewProducts.ItemsSource = App.Context.Product.ToList();
            List<Entities.ProductType> productType = App.Context.ProductType.ToList();
            productType.Insert(0, new Entities.ProductType() { Name = "Все" });
            CBoxProductType.ItemsSource = productType;
            CBoxProductType.SelectedIndex = 0;
        }
        private void UpdateList()
        {
            List<Product> products = App.Context.Product.ToList();

            if (!string.IsNullOrWhiteSpace(TBoxSearch.Text))
                products = products.Where(x => x.Name.ToLower().Contains(TBoxSearch.Text.ToLower()) ||

                x.ProductType.Name.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                x.Calories.ToString().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CBoxProductType.SelectedIndex == 0)
            {
                LViewProducts.ItemsSource = products;
            }
            else
            {
                products = products.Where(x => x.ProductType == CBoxProductType.SelectedItem as ProductType).ToList();
            }
            LViewProducts.ItemsSource = products;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var value = LViewProducts.SelectedItem != null;
            BtnDelete.IsEnabled = value;
            BtnEdit.IsEnabled = value;
        }

        private void CBoxProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
