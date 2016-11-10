#region

using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Runtime.InteropServices;

#endregion

namespace MIS320_Team7Project_Fall2016.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FoodContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FoodContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Populates Items Table
            context.Items.AddOrUpdate(x => x.Name,
                new Item { Cost = 1.00m, Name = "Egg", QtyOnHand = 10 },
                new Item { Cost = 0.25m, Name = "Bacon Slice", QtyOnHand = 50 },
                new Item { Cost = 0.05m, Name = "Sausage Link", QtyOnHand = 50 },
                 new Item { Cost = 0.05m, Name = "Fruit", QtyOnHand = 50 }
                );

            //Populates MealItems Table
            context.MealItems.AddOrUpdate(x => x.Name,
                new Meal { Cost = 5.99m, Name = "Two Egg Meal" },
                new Meal { Cost = 4.99m, Name = "Waffle Meal" },
                new Meal { Cost = 5.99m, Name = "Hotcakes Meal" }
                );
        }
    }

    public static class FoodInitializationHandler
    {
        public static void Initialize()
        {
            Database.SetInitializer(new CreateInitializer());
            using (var db = new FoodContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }

    public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<FoodContext>
    {
        protected override void Seed(FoodContext context)
        {
      //      context.Seed(context);
            base.Seed(context);
        }
    }

    public class CreateInitializer : DropCreateDatabaseAlways<FoodContext>
    {
        protected override void Seed(FoodContext context)
        {
     //       context.Seed(context);
            base.Seed(context);
        }
    }
}