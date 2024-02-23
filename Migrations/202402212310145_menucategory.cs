namespace RestaurantAPI_PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menucategory : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Menus", new[] { "CategoryID" });
            CreateIndex("dbo.Menus", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Menus", new[] { "CategoryId" });
            CreateIndex("dbo.Menus", "CategoryID");
        }
    }
}
