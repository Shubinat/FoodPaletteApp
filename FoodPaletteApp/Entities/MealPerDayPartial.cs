using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPaletteApp.Entities
{
    public partial class MealPerDay
    {
        public string DateText => DateTime.ToShortDateString();
        public string TimeText => DateTime.ToShortTimeString();
    }
}
