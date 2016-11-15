namespace MIS320_Team7Project_Fall2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoodDbMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Employees");
            CreateTable(
                "Inventory.Supplier",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Contact = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "Inventory.RecipieDetails",
                c => new
                    {
                        MealId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("Inventory.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("Inventory.Meal", t => t.MealId)
                .Index(t => t.MealId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "Admin.Reward",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardId);
            
            CreateTable(
                "Admin.Sale",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("Admin.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "Admin.Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "Admin.SaleDetails",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("Inventory.Meal", t => t.MealId)
                .ForeignKey("Admin.Sale", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.MealId);
            
            AddColumn("dbo.Customers", "RewardId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "RewardId", c => c.Int(nullable: false));
            AddColumn("Inventory.Item", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("Inventory.Item", "Name", c => c.String(nullable: false, maxLength: 25, unicode: false));
            AlterColumn("Inventory.Meal", "Name", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.Customers", "UserId");
            AddPrimaryKey("dbo.Employees", "UserId");
            CreateIndex("Inventory.Item", "SupplierId");
            CreateIndex("dbo.Customers", "RewardId");
            CreateIndex("dbo.Employees", "RewardId");
            AddForeignKey("Inventory.Item", "SupplierId", "Inventory.Supplier", "SupplierId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "RewardId", "Admin.Reward", "RewardId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "RewardId", "Admin.Reward", "RewardId", cascadeDelete: true);
            DropColumn("dbo.Customers", "LoyaltyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "LoyaltyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "RewardId", "Admin.Reward");
            DropForeignKey("dbo.Customers", "RewardId", "Admin.Reward");
            DropForeignKey("Admin.SaleDetails", "SaleId", "Admin.Sale");
            DropForeignKey("Admin.SaleDetails", "MealId", "Inventory.Meal");
            DropForeignKey("Admin.Sale", "StoreId", "Admin.Store");
            DropForeignKey("Inventory.RecipieDetails", "MealId", "Inventory.Meal");
            DropForeignKey("Inventory.RecipieDetails", "ItemId", "Inventory.Item");
            DropForeignKey("Inventory.Item", "SupplierId", "Inventory.Supplier");
            DropIndex("dbo.Employees", new[] { "RewardId" });
            DropIndex("dbo.Customers", new[] { "RewardId" });
            DropIndex("Admin.SaleDetails", new[] { "MealId" });
            DropIndex("Admin.SaleDetails", new[] { "SaleId" });
            DropIndex("Admin.Sale", new[] { "StoreId" });
            DropIndex("Inventory.RecipieDetails", new[] { "ItemId" });
            DropIndex("Inventory.RecipieDetails", new[] { "MealId" });
            DropIndex("Inventory.Item", new[] { "SupplierId" });
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("Inventory.Meal", "Name", c => c.String(maxLength: 25));
            AlterColumn("Inventory.Item", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "UserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "UserId", c => c.Int(nullable: false, identity: true));
            DropColumn("Inventory.Item", "SupplierId");
            DropColumn("dbo.Employees", "RewardId");
            DropColumn("dbo.Customers", "RewardId");
            DropTable("Admin.SaleDetails");
            DropTable("Admin.Store");
            DropTable("Admin.Sale");
            DropTable("Admin.Reward");
            DropTable("Inventory.RecipieDetails");
            DropTable("Inventory.Supplier");
            AddPrimaryKey("dbo.Employees", "UserId");
            AddPrimaryKey("dbo.Customers", "UserId");
        }
    }
}
