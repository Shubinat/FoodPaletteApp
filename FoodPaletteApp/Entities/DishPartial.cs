using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPaletteApp.Entities
{
    public partial class Dish
    {
        public string ProductsList
        {
            get
            {
                return string.Join("\n", ProductDish.ToList().Select(x => x.Product.Name + ": " + x.Amount + $" ({x.Product.Unit.Name})"));
            }
        }

        public double Proteins => ProductDish.ToList().Sum(x => x.Amount * x.Product.Proteins);
        public double Fats => ProductDish.ToList().Sum(x => x.Amount * x.Product.Fats);
        public double Carbohydrates => ProductDish.ToList().Sum(x => x.Amount * x.Product.Carbohydrates);
        public double Calories => ProductDish.ToList().Sum(x => x.Amount * x.Product.Calories);
    }
}
