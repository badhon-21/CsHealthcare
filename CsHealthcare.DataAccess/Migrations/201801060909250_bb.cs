namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemStockOutDetails", "StoreItemId", "dbo.StoreItems");
            DropIndex("dbo.ItemStockOutDetails", new[] { "StoreItemId" });
            AddColumn("dbo.ItemStockOutDetails", "StoreItemName", c => c.String());
            DropColumn("dbo.ItemStockOutDetails", "StockOutItemName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemStockOutDetails", "StockOutItemName", c => c.String());
            DropColumn("dbo.ItemStockOutDetails", "StoreItemName");
            CreateIndex("dbo.ItemStockOutDetails", "StoreItemId");
            AddForeignKey("dbo.ItemStockOutDetails", "StoreItemId", "dbo.StoreItems", "Id");
        }
    }
}
