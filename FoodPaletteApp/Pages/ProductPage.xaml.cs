using FoodPaletteApp.Entities;
using mshtml;
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
            List<MealPerDay> mealPerDays = App.Context.MealPerDay.ToList();
            ListCollectionView view = new ListCollectionView(mealPerDays.OrderByDescending(x => x.DateTime).ToList());
            
            view.GroupDescriptions.Add(new PropertyGroupDescription("DateText"));
            DGridDishesPerDay.ItemsSource = view;


        }
        private void UpdateList()
        {
            List<MealPerDay> mealPerDays = App.Context.MealPerDay.ToList();
            if (!string.IsNullOrWhiteSpace(TBoxSearch.Text))
                mealPerDays = mealPerDays.Where(x => x.Dish.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (DPickerDate.SelectedDate != null)
                mealPerDays = mealPerDays.Where(x => x.DateTime.Date == DPickerDate.SelectedDate.Value.Date).ToList();

            mealPerDays = mealPerDays.OrderByDescending(x => x.DateTime).ToList();

            ListCollectionView view = new ListCollectionView(mealPerDays);
            view.GroupDescriptions.Add(new PropertyGroupDescription("DateText"));
            DGridDishesPerDay.ItemsSource = view;


            CreateTable(mealPerDays);
        }

        private void CreateTable(List<MealPerDay> mealPerDays)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<html>");
            stringBuilder.Append("<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'><head></head>");
            stringBuilder.Append("<body>");
            stringBuilder.Append($"<p align=\"center\"><b>Отчет по блюдам</b></p>");

            stringBuilder.Append("<table border=\"1\" align=\"center\">");

            stringBuilder.Append("<tr>");


            stringBuilder.Append("<th>");
            stringBuilder.Append("Время");
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append("Блюдо");
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append("Белки");
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append("Жиры");
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append("Углеводы");
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append("Калории");
            stringBuilder.Append("</th>");

            stringBuilder.Append("</tr>");
            var mealPerDaysByDate = mealPerDays.GroupBy(x => x.DateText).ToList();
            foreach (var mealPerDaysList in mealPerDaysByDate)
            {
                stringBuilder.Append("<tr>");


                stringBuilder.Append($"<th colspan=\"6\">");
                stringBuilder.Append(mealPerDaysList.Key);
                stringBuilder.Append("</th>");

                stringBuilder.Append("</tr>");
                foreach (var item in mealPerDaysList)
                {
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<th>");
                    stringBuilder.Append(item.TimeText);
                    stringBuilder.Append("</th>");

                    stringBuilder.Append("<th>");
                    stringBuilder.Append(item.Dish.Name);
                    stringBuilder.Append("</th>");

                    stringBuilder.Append("<th>");
                    stringBuilder.Append(item.Dish.Proteins);
                    stringBuilder.Append("</th>");

                    stringBuilder.Append("<th>");
                    stringBuilder.Append(item.Dish.Fats);
                    stringBuilder.Append("</th>");

                    stringBuilder.Append("<th>");
                    stringBuilder.Append(item.Dish.Carbohydrates);
                    stringBuilder.Append("</th>");

                    stringBuilder.Append("<th>");
                    stringBuilder.Append(item.Dish.Calories);
                    stringBuilder.Append("</th>");
                    stringBuilder.Append("</tr>");
                }
            }
            stringBuilder.Append("<tr>");
            stringBuilder.Append("<th colspan=\"2\">");
            stringBuilder.Append("ИТОГО");
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append(mealPerDays.Sum(x=> x.Dish.Proteins));
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append(mealPerDays.Sum(x => x.Dish.Fats));
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append(mealPerDays.Sum(x => x.Dish.Carbohydrates));
            stringBuilder.Append("</th>");

            stringBuilder.Append("<th>");
            stringBuilder.Append(mealPerDays.Sum(x => x.Dish.Calories));
            stringBuilder.Append("</th>");

            stringBuilder.Append("</tr>");

            stringBuilder.Append("</table>");
            stringBuilder.Append("<br>");
            stringBuilder.Append("</body>");
            stringBuilder.Append("</html>");
            WBrowserReport.NavigateToString(stringBuilder.ToString());
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
        private void CBoxProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new Windows.SelectDishWindow();
            if (window.ShowDialog() == true)
            {
                MealPerDay mealPerDay = new MealPerDay() { DateTime = DateTime.Now, User = App.AuthUser, Dish = window.SelectedDish};
                App.Context.MealPerDay.Add(mealPerDay);
                App.Context.SaveChanges();
                UpdateList();
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            var mealPerDay = DGridDishesPerDay.SelectedItem as MealPerDay;
            App.Context.MealPerDay.Remove(mealPerDay);
            App.Context.SaveChanges();
            UpdateList();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var doc = WBrowserReport.Document as IHTMLDocument2;
            doc.execCommand("Print");
        }

        private void DGridDishesPerDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGridDishesPerDay.SelectedItem != null;
            BtnRemove.IsEnabled = value;
        }

        private void DPickerDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }
    }
}
