//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodPaletteApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductDish
    {
        public int ProductID { get; set; }
        public int DishID { get; set; }
        public double Amount { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual Product Product { get; set; }
    }
}
