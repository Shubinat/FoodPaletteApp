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
    }
}
