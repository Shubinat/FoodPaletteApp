﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FoodPaletteBaseEntities : DbContext
    {
        public FoodPaletteBaseEntities()
            : base("name=FoodPaletteBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<DishType> DishType { get; set; }
        public virtual DbSet<MealPerDay> MealPerDay { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDish> ProductDish { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
