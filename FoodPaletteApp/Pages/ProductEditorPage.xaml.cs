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
    /// Логика взаимодействия для ProductEditorPage.xaml
    /// </summary>
    public partial class ProductEditorPage : Page
    {
        private Product _product;
        private byte[] _photo;
        public ProductEditorPage(Product product)
        {
            InitializeComponent();
            _product = product;
            CBoxType.ItemsSource = App.Context.ProductType.ToList();
            if (product != null)
            {
                _photo = _product.Picture;
                ImgProduct.DataContext = _photo;
                TBoxName.Text = _product.Name;
                TBoxCalories.Text = _product.Calories.ToString();
                TBoxProteins.Text = _product.Proteins.ToString();
                TBoxFats.Text = _product.Fats.ToString();
                TBoxCarbohydrates.Text = _product.Carbohydrates.ToString();
                CBoxType.SelectedItem = _product.ProductType;
                CBoxUnit.SelectedItem = _product.Unit;
            }
        }

        private void BtnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файлы изображений|*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                _photo = File.ReadAllBytes(dialog.FileName);
                ImgProduct.DataContext = _photo;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var err = "";
            if (string.IsNullOrWhiteSpace(CBoxType.Text)) err += "Выберите тип продукта\n";
            if (string.IsNullOrWhiteSpace(TBoxName.Text)) err += "Введите имя продукта\n";
            if (string.IsNullOrWhiteSpace(TBoxCalories.Text)) err += "Введите калории\n";
            if (string.IsNullOrWhiteSpace(TBoxProteins.Text)) err += "Введите белки\n";
            if (string.IsNullOrWhiteSpace(TBoxFats.Text)) err += "Введите жиры\n";
            if (string.IsNullOrWhiteSpace(TBoxCarbohydrates.Text)) err += "Введите углеводы\n";
            if (string.IsNullOrWhiteSpace(CBoxUnit.Text)) err += "Введите ед.измерения\n";

            if (err == "")
            {
                if (_product == null)
                    _product = new Product();

                _product.ProductType = CBoxType.SelectedItem as ProductType;
                _product.Unit = CBoxType.SelectedItem as Unit;
                _product.Name = TBoxName.Text;
                _product.Calories = Convert.ToInt32(TBoxCalories.Text);
                _product.Proteins = Convert.ToInt32(TBoxProteins.Text);
                _product.Carbohydrates = Convert.ToInt32(TBoxCarbohydrates.Text);
                _product.Fats = Convert.ToInt32(TBoxFats.Text);
                _product.Picture = _photo;

                if (_product.ID == 0)
                    App.Context.Product.Add(_product);

                App.Context.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show(err, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
