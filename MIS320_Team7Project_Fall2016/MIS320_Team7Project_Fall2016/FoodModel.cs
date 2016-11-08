#region

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

#endregion

namespace MIS320_Team7Project_Fall2016
{
    public class FoodModel : DbContext
    {
        // Your context has been configured to use a 'FoodModel' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'MIS320_Team7Project_Fall2016.FoodModel' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'FoodModel'
        // connection string in the application configuration file.
        public FoodModel()
            : base("name=FoodModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<MealItem> MealItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder model)
        {
            model.Entity<Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            model.Entity<MealItem>()
                .HasMany(e => e.RequiredItems);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Item
    {
        //Methods

        [DisplayName("Cost")]
        public decimal Cost { get; set; }

        //Properties
        [DisplayName("Item ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Qty On Hand")]
        public byte QtyOnHand { get; set; }
    }

    public class MealItem
    {
        //Methods
        public MealItem()
        {
            RequiredItems = new HashSet<Item>();
        }

        [DisplayName("Cost")]
        public decimal Cost { get; set; }

        //Properties
        [DisplayName("Meal ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Required Items")]
        public virtual ICollection<Item> RequiredItems { get; set; }
    }

    //public interface IRequiredItems :ICollection<Item>
    //{
    //}
}