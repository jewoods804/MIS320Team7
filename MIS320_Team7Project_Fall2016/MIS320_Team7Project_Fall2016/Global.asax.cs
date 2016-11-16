using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MIS320_Team7Project_Fall2016.Migrations;
using MIS320_Team7Project_Fall2016.Models;

namespace MIS320_Team7Project_Fall2016
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<FoodContext>());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Seed();
            // FoodInitializationHandler.Initialize();
            //using (var db = new FoodContext())
            //{

            //}
        }

        private static void Seed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<FoodContext>());
            using (var context = new FoodContext())
            {
                try
                {
                    //context.Users.AddOrUpdate(x => x.Name,
                    //    new Customer
                    //    {
                    //        Email = "test1@gmail.com",
                    //        Name = "Test Testie1",
                    //        Password = "password",
                    //        MemberSince = DateTime.Now
                    //    },
                    //    new Customer
                    //    {
                    //        Email = "test2@gmail.com",
                    //        Name = "Test Testie2",
                    //        Password = "password",
                    //        MemberSince = DateTime.Now
                    //    },
                    //    new Customer
                    //    {
                    //        Email = "test3@gmail.com",
                    //        Name = "Test Testie3",
                    //        Password = "password",
                    //        MemberSince = DateTime.Now
                    //    },
                    //    new Customer
                    //    {
                    //        Email = "test4@gmail.com",
                    //        Name = "Test Testie4",
                    //        Password = "password",
                    //        MemberSince = DateTime.Now
                    //    }
                    //    );
                    //context.SaveChanges();

                    //context.Users.AddOrUpdate(x => x.Name,
                    //    new Employee
                    //    {
                    //        Name = "John Cena",
                    //        Title = "Supreme Leader",
                    //        Email = "jcena@gmail.com",
                    //        Password = "password",
                    //        PayRate = 10m,
                    //        MemberSince = new DateTime(1901, 1, 27)
                    //    },
                    //    new Employee
                    //    {
                    //        Name = "Admin",
                    //        Title = "Admin",
                    //        Email = "google@gmail.com",
                    //        Password = "password",
                    //        PayRate = 5m,
                    //        MemberSince = new DateTime(1955, 1, 27)
                    //    },
                    //    new Employee
                    //    {
                    //        Name = "Joe Smoe",
                    //        Title = "Cashier",
                    //        Email = "tester@gmail.com",
                    //        Password = "password",
                    //        PayRate = 10m,
                    //        MemberSince = new DateTime(1999, 1, 27)
                    //    }
                    //    );
                    //context.SaveChanges();


                    //Populates Items Table
                    context.Items.AddOrUpdate(x => x.ItemId,
                        new Item { Cost = 1.00m, Name = "Egg", QtyOnHand = 10 },
                        new Item { Cost = 0.25m, Name = "Bacon Slice", QtyOnHand = 50 },
                        new Item { Cost = 0.05m, Name = "Sausage Link", QtyOnHand = 50 },
                        new Item { Cost = 0.05m, Name = "Fruit", QtyOnHand = 50 }
                        );
                    context.SaveChanges();

                    //////Populates MealItems Table
                    //context.MealItems.AddOrUpdate(x => x.Name,
                    //    new Meal { Cost = 5.99m, Name = "Two Egg Meal" },
                    //    new Meal { Cost = 4.99m, Name = "Waffle Meal" },
                    //    new Meal { Cost = 5.99m, Name = "Hotcakes Meal" }
                    //    );
                    //context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

        }
    }
}
