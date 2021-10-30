namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storecategoryitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreItems", "StoreItemCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.StoreItems", "CategoryName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreItems", "CategoryName");
            DropColumn("dbo.StoreItems", "StoreItemCategoryId");
        }
    }
}
