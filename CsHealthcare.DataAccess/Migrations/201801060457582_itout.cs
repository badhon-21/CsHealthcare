namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemStockOutDetails", "StoreItemId", c => c.Int());
            CreateIndex("dbo.ItemStockOutDetails", "StoreItemId");
            AddForeignKey("dbo.ItemStockOutDetails", "StoreItemId", "dbo.StoreItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemStockOutDetails", "StoreItemId", "dbo.StoreItems");
            DropIndex("dbo.ItemStockOutDetails", new[] { "StoreItemId" });
            DropColumn("dbo.ItemStockOutDetails", "StoreItemId");
        }
    }
}
