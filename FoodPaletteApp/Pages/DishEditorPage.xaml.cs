using FoodPaletteApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для DishEditorPage.xaml
    /// </summary>
    public partial class DishEditorPage : Page
    {
        private Dish _dish;
        private byte[] _picture;
        private List<ProductDish> _productsList => _dish?.ProductDish.ToList();
        public DishEditorPage(Dish dish = null)
        {
            InitializeComponent();
            _dish = dish;
            CBoxDishType.ItemsSource = App.Context.DishType.ToList();
            LViewProducts.ItemsSource = new List<ProductDish>();    
            if (_dish != null)
            {
                TBoxName.Text = _dish.Name;
                TBoxDescription.Text = _dish.Description;
                CBoxDishType.SelectedItem = _dish.DishType;
                _picture = _dish.Picture;
                ImgPicture.DataContext = _picture;
                LViewProducts.ItemsSource = _dish?.ProductDish.ToList();
            }
            else
            {
                TabItemProducts.IsEnabled = false;
            }
        }

        private void BtnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы изображений |*.jpg;*.png";
            if (fileDialog.ShowDialog() == true)
            {
                _picture = File.ReadAllBytes(fileDialog.FileName);
                ImgPicture.DataContext = _picture;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_dish == null)
                _dish = new Dish();
            _dish.Name = TBoxName.Text;
            _dish.Description = TBoxDescription.Text;
            _dish.DishType = CBoxDishType.SelectedItem as DishType;
            _dish.Picture = _picture;
            if (_dish.ID == 0)
                _dish = App.Context.Dish.Add(_dish);
            App.Context.SaveChanges();
            TabItemProducts.IsEnabled = true;
        }

        private void BtnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = LViewProducts.SelectedItem as ProductDish;
            App.Context.ProductDish.Remove(product);
            App.Context.SaveChanges();
            LViewProducts.ItemsSource = _productsList.ToList();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = LViewProducts.SelectedItem as ProductDish;
            var window = new Windows.AddEditProductDishWindow(product);
            if (window.ShowDialog() == true)
            {
                LViewProducts.ItemsSource = _productsList.ToList();
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var window = new Windows.AddEditProductDishWindow(new ProductDish() { Dish = _dish });
            if (window.ShowDialog() ==true)
            {
                LViewProducts.ItemsSource = _productsList.ToList();
            }
        }

        private void LViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = LViewProducts.SelectedItem != null;
            BtnEditProduct.IsEnabled = value;
            BtnRemoveProduct.IsEnabled = value;
        }
    }
}
