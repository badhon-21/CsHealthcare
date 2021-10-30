namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockOutItems", "DepartmentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.StockOutItems", "DepartmentId");
            AddForeignKey("dbo.StockOutItems", "DepartmentId", "dbo.DEPARTMENTs", "Id");
            DropColumn("dbo.StockOutItems", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockOutItems", "Department", c => c.String(maxLength: 30));
            DropForeignKey("dbo.StockOutItems", "DepartmentId", "dbo.DEPARTMENTs");
            DropIndex("dbo.StockOutItems", new[] { "DepartmentId" });
            DropColumn("dbo.StockOutItems", "DepartmentId");
        }
    }
}
