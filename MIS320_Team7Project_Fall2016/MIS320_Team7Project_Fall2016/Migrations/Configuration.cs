namespace MIS320_Team7Project_Fall2016.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MIS320_Team7Project_Fall2016.FoodModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MIS320_Team7Project_Fall2016.FoodModel context)
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
                new Item(),
                new Item(),
                new Item()
                );

            //Populates MealItems Table
            context.MealItems.AddOrUpdate(x => x.Name,
                new Meal(),
                new Meal(),
                new Meal()
            );
        }
    }
}