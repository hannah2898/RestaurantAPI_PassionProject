namespace RestaurantAPI_PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categorymenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "OrderID", "dbo.Orders");
            DropIndex("dbo.Menus", new[] { "OrderID" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderMenus",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Menu_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Menu_ItemID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.Menu_ItemID, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Menu_ItemID);
            
            AddColumn("dbo.Menus", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "CategoryID");
            AddForeignKey("dbo.Menus", "CategoryID", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Menus", "OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "OrderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderMenus", "Menu_ItemID", "dbo.Menus");
            DropForeignKey("dbo.OrderMenus", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Menus", "CategoryID", "dbo.Categories");
            DropIndex("dbo.OrderMenus", new[] { "Menu_ItemID" });
            DropIndex("dbo.OrderMenus", new[] { "Order_OrderId" });
            DropIndex("dbo.Menus", new[] { "CategoryID" });
            DropColumn("dbo.Menus", "CategoryID");
            DropTable("dbo.OrderMenus");
            DropTable("dbo.Categories");
            CreateIndex("dbo.Menus", "OrderID");
            AddForeignKey("dbo.Menus", "OrderID", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
