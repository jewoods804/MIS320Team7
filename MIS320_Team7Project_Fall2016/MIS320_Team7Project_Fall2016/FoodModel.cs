namespace MIS320_Team7Project_Fall2016
{
    using System;
    using System.Data.Entity;
    using System.Linq;

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
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}