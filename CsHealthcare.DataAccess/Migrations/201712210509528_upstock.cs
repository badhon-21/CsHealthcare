namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upstock : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockIns", "StoreItemId", "dbo.StoreItems");
            DropIndex("dbo.StockIns", new[] { "StoreItemId" });
            DropColumn("dbo.StockIns", "StoreItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockIns", "StoreItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.StockIns", "StoreItemId");
            AddForeignKey("dbo.StockIns", "StoreItemId", "dbo.StoreItems", "Id", cascadeDelete: true);
        }
    }
}
