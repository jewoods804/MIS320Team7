#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Runtime.InteropServices;

#endregion

namespace MIS320_Team7Project_Fall2016.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FoodContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(FoodContext context)
        {
            //  This method will be called after migrating to the latest version.

            //var items = new List<Item>()
            //{
            //    new Item { Cost = 1.00m, Name = "Egg", QtyOnHand = 10 },
            //    new Item { Cost = 0.25m, Name = "Bacon Slice", QtyOnHand = 50 },
            //    new Item { Cost = 0.05m, Name = "Sausage Link", QtyOnHand = 50 },
            //     new Item { Cost = 0.05m, Name = "Fruit", QtyOnHand = 50 }
            //};
            //foreach (var item in items)
            //{

            //}


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




            //    try
            //    {

            //        context.Users.AddOrUpdate(x => x.Name,
            //            new Customer
            //            {
            //                Email = "test1@gmail.com",
            //                Name = "Test Testie1",
            //                Password = "password",
            //                MemberSince = DateTime.Now
            //            },
            //            new Customer
            //            {
            //                Email = "test2@gmail.com",
            //                Name = "Test Testie2",
            //                Password = "password",
            //                MemberSince = DateTime.Now
            //            },
            //            new Customer
            //            {
            //                Email = "test3@gmail.com",
            //                Name = "Test Testie3",
            //                Password = "password",
            //                MemberSince = DateTime.Now
            //            },
            //            new Customer
            //            {
            //                Email = "test4@gmail.com",
            //                Name = "Test Testie4",
            //                Password = "password",
            //                MemberSince = DateTime.Now
            //            }
            //            );
            //        context.SaveChanges();

            //        context.Users.AddOrUpdate(x => x.Name,
            //            new Employee
            //            {
            //                Name = "John Cena",
            //                Title = "Supreme Leader",
            //                Email = "jcena@gmail.com",
            //                Password = "password",
            //                PayRate = 10m,
            //                MemberSince = new DateTime(1901, 1, 27)
            //            },
            //            new Employee
            //            {
            //                Name = "Admin",
            //                Title = "Admin",
            //                Email = "google@gmail.com",
            //                Password = "password",
            //                PayRate = 5m,
            //                MemberSince = new DateTime(1955, 1, 27)
            //            },
            //            new Employee
            //            {
            //                Name = "Joe Smoe",
            //                Title = "Cashier",
            //                Email = "tester@gmail.com",
            //                Password = "password",
            //                PayRate = 10m,
            //                MemberSince = new DateTime(1999, 1, 27)
            //            }
            //            );
            //        context.SaveChanges();


            //        //Populates Items Table
            context.Items.AddOrUpdate(x => x.ItemId,
                new Item { Cost = 1.00m, Name = "Egg", QtyOnHand = 10 },
                new Item { Cost = 0.25m, Name = "Bacon Slice", QtyOnHand = 50 },
                new Item { Cost = 0.05m, Name = "Sausage Link", QtyOnHand = 50 },
                new Item { Cost = 0.05m, Name = "Fruit", QtyOnHand = 50 }
                );
            context.SaveChanges();

            //        ////Populates MealItems Table
            //        context.MealItems.AddOrUpdate(x => x.Name,
            //            new Meal { Cost = 5.99m, Name = "Two Egg Meal" },
            //            new Meal { Cost = 4.99m, Name = "Waffle Meal" },
            //            new Meal { Cost = 5.99m, Name = "Hotcakes Meal" }
            //            );
            //        context.SaveChanges();

            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.WriteLine(ex.Message);
            //    }
        }
    }

    //public static class FoodInitializationHandler
    //{
    //    public static void Initialize()
    //    {
    //        Database.SetInitializer(new CreateInitializer());
    //        using (var db = new FoodContext())
    //        {
    //            {
    //                db.Database.Initialize(true);
    //            }
    //        }
    //    }
    //}

    //public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<FoodContext>
    //{
    //    protected override void Seed(FoodContext context)
    //    {
    //        //      context.Seed(context);
    //        base.Seed(context);
    //    }
    //}

    //public class CreateInitializer : DropCreateDatabaseAlways<FoodContext>
    //{
    //    protected override void Seed(FoodContext context)
    //    {
    //        //       context.Seed(context);
    //        base.Seed(context);
    //    }
    //}
}