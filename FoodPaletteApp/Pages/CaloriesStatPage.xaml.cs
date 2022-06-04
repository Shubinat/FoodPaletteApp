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
    /// Логика взаимодействия для CaloriesStatPage.xaml
    /// </summary>
    public partial class CaloriesStatPage : Page
    {
        public CaloriesStatPage()
        {
            InitializeComponent();

        }

        private void GenerateStat()
        {
            var list = App.Context.MealPerDay.ToList().OrderBy(x => x.DateTime).ToList();
            CaloriesStat.Series.Clear();
            CaloriesStat.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            if (ChBoxCalories.IsChecked == true)
            {
                var currSeries = CaloriesStat.Series.Add("Калории");
                currSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
                currSeries.Points.DataBindXY(list.Select(x => x.DateTime).ToArray(), list.Select(x => x.Dish.Calories).ToArray());
            }

            if (ChBoxCarbohydrates.IsChecked == true)
            {
                var currSeries = CaloriesStat.Series.Add("Углеводы");
                currSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
                currSeries.Points.DataBindXY(list.Select(x => x.DateTime).ToArray(), list.Select(x => x.Dish.Carbohydrates).ToArray());
            }

            if (ChBoxFats.IsChecked == true)
            {
                var currSeries = CaloriesStat.Series.Add("Жиры");
                currSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
                currSeries.Points.DataBindXY(list.Select(x => x.DateTime).ToArray(), list.Select(x => x.Dish.Fats).ToArray());
            }

            if (ChBoxProteins.IsChecked == true)
            {
                var currSeries = CaloriesStat.Series.Add("Белки");
                currSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
                currSeries.Points.DataBindXY(list.Select(x => x.DateTime).ToArray(), list.Select(x => x.Dish.Proteins).ToArray());
            }

        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(WinFormsHost, "Statistics");
            }
        }

        private void ChBoxCalories_Click(object sender, RoutedEventArgs e)
        {
            GenerateStat();
        }

        private void ChBoxProteins_Click(object sender, RoutedEventArgs e)
        {
            GenerateStat();
        }

        private void ChBoxFats_Click(object sender, RoutedEventArgs e)
        {
            GenerateStat();
        }

        private void ChBoxCarbohydrates_Click(object sender, RoutedEventArgs e)
        {
            GenerateStat();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateStat();
        }
    }
}
