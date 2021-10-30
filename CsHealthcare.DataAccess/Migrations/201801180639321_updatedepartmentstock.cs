namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedepartmentstock : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DrugStockIns", "DepartmentId", "dbo.DEPARTMENTs");
            DropIndex("dbo.DrugStockIns", new[] { "DepartmentId" });
            DropColumn("dbo.DrugStockIns", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugStockIns", "DepartmentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.DrugStockIns", "DepartmentId");
            AddForeignKey("dbo.DrugStockIns", "DepartmentId", "dbo.DEPARTMENTs", "Id");
        }
    }
}
