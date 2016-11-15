namespace MIS320_Team7Project_Fall2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryTwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "RewardId", "Admin.Reward");
            DropForeignKey("dbo.Employees", "RewardId", "Admin.Reward");
            DropIndex("dbo.Customers", new[] { "RewardId" });
            DropIndex("dbo.Employees", new[] { "RewardId" });
            DropColumn("dbo.Customers", "RewardId");
            DropColumn("dbo.Employees", "RewardId");
            DropTable("Admin.Reward");
        }
        
        public override void Down()
        {
            CreateTable(
                "Admin.Reward",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardId);
            
            AddColumn("dbo.Employees", "RewardId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "RewardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "RewardId");
            CreateIndex("dbo.Customers", "RewardId");
            AddForeignKey("dbo.Employees", "RewardId", "Admin.Reward", "RewardId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "RewardId", "Admin.Reward", "RewardId", cascadeDelete: true);
        }
    }
}
