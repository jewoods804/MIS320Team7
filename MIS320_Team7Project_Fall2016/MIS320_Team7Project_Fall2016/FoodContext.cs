#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Data.Entity;

#endregion

namespace MIS320_Team7Project_Fall2016
{


    public class FoodContext : DbContext
    {
        // Your context has been configured to use a 'FoodModel' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'MIS320_Team7Project_Fall2016.FoodModel' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'FoodModel'
        // connection string in the application configuration file.
        public FoodContext()
            : base("name=FoodContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodContext, Migrations.Configuration>("FoodModel"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Meal> MealItems { get; set; }
     //   public virtual DbSet<Employee> Employees { get; set; }
   //     public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetails> SalesDetails { get; set; }
   //     public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<RecipieDetails> RecipieDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Customer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Customers");
            });

            model.Entity<Employee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Employees");
            });


            model.Entity<Sale>()
                .HasKey(p => p.SaleId);

            model.Entity<SaleDetails>()
                .HasKey(p => p.SaleId)
                .HasKey(p => p.MealId);

            model.Entity<RecipieDetails>()
                .HasKey(p => p.ItemId)
                .HasKey(p => p.MealId);

            model.Entity<User>()
                .Property(p => p.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            model.Entity<Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            model.Entity<Meal>()
                .HasMany(e => e.ReqItems);

            //model.Entity<Employee>()
            //    .Property(e => e.Name);

            //model.Entity<Customer>()
            //    .Property(e => e.Name);

           
         
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    ////}
    //[Table("Reward", Schema = "Admin")]
    //public class Reward
    //{
    //    [Key]
    //    [Required]
    //    [DisplayName("Reward ID")]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int RewardId { get; set; }
    //    public int Score { get; set; }
    //}

    [Table("Item", Schema = "Inventory")]
    public class Item
    {
        //Methods
        public Item()
        {
            // Cost = 1.1m;
        }

        public Item(decimal cost, string name, byte[] photo, byte qtyOnHand)
        {
            Cost = cost;
            Name = name;
            //Photo = photo;
            QtyOnHand = qtyOnHand;
        }

        //Properties
        [DisplayName("Cost")]
        [Required]
        public decimal Cost { get; set; }

        [Key]
        [Required]
        [DisplayName("Item ID")]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        //  [Timestamp]
        //    public byte?[] LastModified { get; set; }

        [Required]
        [ConcurrencyCheck]
        [DisplayName("Name")]
        [MaxLength(25), MinLength(4)]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public byte?[] Photo { get; set; }

        [Required]
        [DisplayName("Qty On Hand")]
        public int QtyOnHand { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }


    [Table("Meal", Schema = "Inventory")]
    public class Meal
    {
        //Methods
        public Meal()
        {

        }

        public Meal(decimal cost, string name)
        {
            Cost = cost;
            Name = name;

        }

        //Properties
        [DisplayName("Cost")]
        [Required]
        public decimal Cost { get; set; }

        [Key]
        [Required]
        [Column(Order = 1)]
        [DisplayName("Meal ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealId { get; set; }

        [DisplayName("Name")]
        [ConcurrencyCheck]
        [Required]
        [MaxLength(25), MinLength(4)]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public byte?[] Photo { get; set; }

        [DisplayName("Required Items")]
        public virtual List<Item> ReqItems { get; set; }
    }

    [Table("Supplier", Schema = "Inventory")]
    public class Supplier
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        [DisplayName("Supplier ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
    }
    [Table("RecipieDetails", Schema = "Inventory")]
    public class RecipieDetails
    {
        [ForeignKey("Meal")]
        [Column(Order = 1)]
        public int MealId { get; set; }

        [ForeignKey("Item")]
        [Column(Order = 2)]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Meal Meal { get; set; }

        public int Qty { get; set; }
    }
    [Table("Sale", Schema = "Admin")]
    public class Sale
    {
        
        [Key]
        [Required]
        [Column(Order = 1)]
        [DisplayName("Sale ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }


        public DateTime TransactionDate { get; set; }
        [Key]
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Key]
        [ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual User User { get; set; }
        public virtual Store Store { get; set; }
    }
    [Table("SaleDetails", Schema = "Admin")]
    public class SaleDetails
    {
        [Key]
        [ForeignKey("Sale")]
        [Column(Order = 1)]
        public int SaleId { get; set; }
        [Key]
        [ForeignKey("Meal")]
        [Column(Order = 2)]
        public int MealId { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Meal Meal { get; set; }
        public int Qty { get; set; }
    }

    [Table("Store", Schema = "Admin")]
    public class Store
    {
        [Key]
        [Required]
        [DisplayName("Store ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    }

    //[Table("Users", Schema = "Admin")]
    public abstract class User
    {
        //Properties
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Member Since")]
        //   [Timestamp]
        public DateTime? MemberSince { get; set; }

        [DisplayName("Name")]
        [ConcurrencyCheck]
        [Required]
        [MaxLength(25), MinLength(4)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[ForeignKey("Reward")]
        //public int RewardId { get; set; }

       
        [DisplayName("User ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        //public virtual Reward Reward { get; set; }

        //Methods
        public virtual long GetTenure()
        {
            return DateTime.Now.ToBinary();
        }
    }

    [Table("Customer", Schema = "Admin")]
    public class Customer : User
    {
        //Properties
        //  public int LoyaltyId { get; set; }

        //Methods
    }

    [Table("Employee", Schema = "Admin")]
    public class Employee : User
    {
        public decimal PayRate { get; set; }
        public string Title { get; set; }

        //Methods
        public override long GetTenure()
        {
            return base.GetTenure();
        }
    }
}