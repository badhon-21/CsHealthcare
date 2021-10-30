namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tyui : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems");
            DropIndex("dbo.DepartmentDetailsForItems", new[] { "StockOutItemId" });
            AddColumn("dbo.DepartmentDetailsForItems", "StockItemId", c => c.Int());
            DropColumn("dbo.DepartmentDetailsForItems", "StockOutItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DepartmentDetailsForItems", "StockOutItemId", c => c.Int());
            DropColumn("dbo.DepartmentDetailsForItems", "StockItemId");
            CreateIndex("dbo.DepartmentDetailsForItems", "StockOutItemId");
            AddForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems", "Id");
        }
    }
}
