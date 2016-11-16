namespace MIS230Team7GroupProjectFall2016.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FoodStoreContext : DbContext
    {
        public FoodStoreContext()
            : base("name=FoodStoreContext")
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Meal)
                .HasForeignKey(e => e.Meal_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.Meals)
                .WithRequired(e => e.Sale)
                .HasForeignKey(e => e.Sale_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.Store_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
