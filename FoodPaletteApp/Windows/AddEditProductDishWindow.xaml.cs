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
    /// Логика взаимодействия для AddEditProductDishWindow.xaml
    /// </summary>
    public partial class AddEditProductDishWindow : Window
    {
        private ProductDish _productDish;
        public AddEditProductDishWindow(ProductDish productDish)
        {
            InitializeComponent();
            CBoxProduct.ItemsSource = App.Context.Product.ToList();
            _productDish = productDish;
            TBoxAmount.Text = productDish.Amount.ToString();
            CBoxProduct.SelectedItem = productDish.Product;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(_productDish.Product == null)
            {
                _productDish.Product = CBoxProduct.SelectedItem as Product;
                _productDish.Amount = double.Parse(TBoxAmount.Text);
                App.Context.ProductDish.Add(_productDish);
            }
            else
            {
                _productDish.Product = CBoxProduct.SelectedItem as Product;
                _productDish.Amount = double.Parse(TBoxAmount.Text);
            }
            App.Context.SaveChanges();
            DialogResult = true;
        }
    }
}
