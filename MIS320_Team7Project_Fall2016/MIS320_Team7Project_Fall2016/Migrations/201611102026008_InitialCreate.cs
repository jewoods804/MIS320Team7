namespace MIS320_Team7Project_Fall2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inventory.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastModified = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(nullable: false, maxLength: 25),
                        Photo = c.Binary(),
                        QtyOnHand = c.Byte(nullable: false),
                        Meal_MealId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("Inventory.Meal", t => t.Meal_MealId)
                .Index(t => t.Meal_MealId);
            
            CreateTable(
                "Inventory.Meal",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(nullable: false, maxLength: 25),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.Item", "Meal_MealId", "Inventory.Meal");
            DropIndex("Inventory.Item", new[] { "Meal_MealId" });
            DropTable("Inventory.Meal");
            DropTable("Inventory.Item");
        }
    }
}
