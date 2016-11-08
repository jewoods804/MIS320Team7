#region

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public virtual DbSet<Meal> MealItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder model)
        {
            base.OnModelCreating(model);

            //model.Entity<Item>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //model.Entity<MealItem>()
            //    .HasMany(e => e.RequiredItems);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    [Table("Item", Schema = "Inventory")]
    public class Item
    {
        //Methods
        public Item()
        {
            Cost = (decimal)1.1;
        }

        //Properties
        [DisplayName("Cost")]
        [Required]
        public decimal Cost { get; set; }

        [Key]
        [Required]
        [DisplayName("Item ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Timestamp]
        public byte[] LastModified { get; set; }

        [Required]
        [ConcurrencyCheck]
        [DisplayName("Name")]
        [MaxLength(25), MinLength(4)]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public byte[] Photo { get; set; }

        [Required]
        [DisplayName("Qty On Hand")]
        public byte QtyOnHand { get; set; }
    }

    [Table("Meal", Schema = "Inventory")]
    public class Meal
    {
        //Methods
        public Meal()
        {
            RequiredItems = new HashSet<Item>();
        }

        //Properties
        [DisplayName("Cost")]
        [Required]
        public decimal Cost { get; set; }

        [Key]
        [Required]
        [DisplayName("Meal ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealId { get; set; }

        [DisplayName("Name")]
        [ConcurrencyCheck]
        [Required]
        [MaxLength(25), MinLength(4)]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public byte[] Photo { get; set; }

        [DisplayName("Required Items")]
        [Required]
        public virtual ICollection<Item> RequiredItems { get; set; }
    }

    //[Table("Users", Schema = "Admin")]
    //public class User
    //{
    //}

    //public interface IRequiredItems :ICollection<Item>
    //{
    //}
}