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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User user;
        public ProfilePage()
        {
            InitializeComponent();
            user = App.AuthUser;
            TBoxName.Text = user.Name;
            TBoxSurname.Text = user.Surname;
            TBoxPatronymic.Text = user.Patronymic;
            TBoxPassword.Text = user.Password;
            TBoxLogin.Text = user.Login;
            TBoxHeight.Text = user.Height.ToString();
            TBoxWeight.Text = user.Weight.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var err = "";
                if (string.IsNullOrWhiteSpace(TBoxName.Text)) err += "Заполните поле Имя\n";
                if (string.IsNullOrWhiteSpace(TBoxSurname.Text)) err += "Заполните поле Фамилия\n";
                if (string.IsNullOrWhiteSpace(TBoxPatronymic.Text)) err += "Заполните поле Отчество\n";
                if (string.IsNullOrWhiteSpace(TBoxLogin.Text)) err += "Заполните поле Логин\n";
                if (string.IsNullOrWhiteSpace(TBoxPassword.Text)) err += "Заполните поле Пароль\n";
                if (string.IsNullOrWhiteSpace(TBoxWeight.Text)) err += "Заполните поле Вес\n";
                if (string.IsNullOrWhiteSpace(TBoxHeight.Text)) err += "Заполните поле Рост\n";

                if (err == "")
                {
                    user.Name = TBoxName.Text;
                    user.Surname = TBoxSurname.Text;
                    user.Patronymic = TBoxPatronymic.Text;
                    user.Login = TBoxLogin.Text;
                    user.Password = TBoxPassword.Text;
                    user.Height = Convert.ToInt32(TBoxHeight.Text);
                    user.Weight = Convert.ToInt32(TBoxWeight.Text);
                    App.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show(err, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch
            {
                _ = MessageBox.Show("Произошла ошибка. Проверьте правильность заполнения полей.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        private void BtnCheckIMT_Click(object sender, RoutedEventArgs e)
        {
            int imt = Convert.ToInt32(TBoxHeight.Text) - 110;
            int weight = Convert.ToInt32(TBoxWeight.Text);

            if (weight+5>=imt && imt>=weight-5)
            {
                TBlockIMT.Text = "Идеальная масса тела";

            }
            else if (weight < imt)
            {
                TBlockIMT.Text = "Недостаточная масса тела";
            }
            else if (weight > imt)
            {
                TBlockIMT.Text = "Избыточная масса тела";

            }
        }
    }
}
