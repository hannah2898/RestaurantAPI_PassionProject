namespace RestaurantAPI_PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "OrderID");
            AddForeignKey("dbo.Menus", "OrderID", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "OrderID", "dbo.Orders");
            DropIndex("dbo.Menus", new[] { "OrderID" });
            DropColumn("dbo.Menus", "OrderID");
        }
    }
}
