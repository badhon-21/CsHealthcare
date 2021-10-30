namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentdrugstock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugDepartmentWiseStockInDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugId = c.Int(),
                        DrugName = c.String(),
                        Quantity = c.Int(),
                        CostPrice = c.Decimal(precision: 18, scale: 2),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        SubTotalPrice = c.Decimal(precision: 18, scale: 2),
                        SalePrice = c.Decimal(precision: 18, scale: 2),
                        RemainingQuantity = c.Int(),
                        DrugDepartmentWiseStockInId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrugDepartmentWiseStockIns", t => t.DrugDepartmentWiseStockInId)
                .Index(t => t.DrugDepartmentWiseStockInId);
            
            AlterColumn("dbo.DrugDepartmentWiseStockIns", "TotalQty", c => c.Int());
            DropColumn("dbo.DrugDepartmentWiseStockIns", "DrugId");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "DrugName");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "RemainingQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugDepartmentWiseStockIns", "RemainingQuantity", c => c.Int());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "DrugName", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "DrugId", c => c.Int());
            DropForeignKey("dbo.DrugDepartmentWiseStockInDetails", "DrugDepartmentWiseStockInId", "dbo.DrugDepartmentWiseStockIns");
            DropIndex("dbo.DrugDepartmentWiseStockInDetails", new[] { "DrugDepartmentWiseStockInId" });
            AlterColumn("dbo.DrugDepartmentWiseStockIns", "TotalQty", c => c.Decimal(precision: 18, scale: 2));
            DropTable("dbo.DrugDepartmentWiseStockInDetails");
        }
    }
}
