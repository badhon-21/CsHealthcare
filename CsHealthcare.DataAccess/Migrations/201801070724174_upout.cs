namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upout : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems");
            DropIndex("dbo.DepartmentDetailsForItems", new[] { "StockOutItemId" });
            AlterColumn("dbo.DepartmentDetailsForItems", "StockOutItemId", c => c.Int());
            CreateIndex("dbo.DepartmentDetailsForItems", "StockOutItemId");
            AddForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems");
            DropIndex("dbo.DepartmentDetailsForItems", new[] { "StockOutItemId" });
            AlterColumn("dbo.DepartmentDetailsForItems", "StockOutItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.DepartmentDetailsForItems", "StockOutItemId");
            AddForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems", "Id", cascadeDelete: true);
        }
    }
}
