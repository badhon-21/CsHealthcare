namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overconflict : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.StoreItemCategories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.StoreItems", "StoreItemCategoryId", c => c.Int(nullable: false));
            //AddColumn("dbo.StoreItems", "CategoryName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.StoreItems", "CategoryName");
            //DropColumn("dbo.StoreItems", "StoreItemCategoryId");
            //DropTable("dbo.StoreItemCategories");
        }
    }
}
