namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentwisedrugstockout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugDepartmentWiseStockOutDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugDepartmentWiseStockOutId = c.Int(nullable: false),
                        DRUGId = c.Int(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        SubTotalPrice = c.Decimal(precision: 18, scale: 2),
                        SalePrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DRUGId)
                .ForeignKey("dbo.DrugDepartmentWiseStockOuts", t => t.DrugDepartmentWiseStockOutId)
                .Index(t => t.DrugDepartmentWiseStockOutId)
                .Index(t => t.DRUGId);
            
            CreateTable(
                "dbo.DrugDepartmentWiseStockOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(maxLength: 50),
                        LotNo = c.String(maxLength: 50),
                        DepartmentId = c.String(maxLength: 128),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            //AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrugDepartmentWiseStockOutDetails", "DrugDepartmentWiseStockOutId", "dbo.DrugDepartmentWiseStockOuts");
            DropForeignKey("dbo.DrugDepartmentWiseStockOuts", "DepartmentId", "dbo.DEPARTMENTs");
            DropForeignKey("dbo.DrugDepartmentWiseStockOutDetails", "DRUGId", "dbo.DRUG");
            DropIndex("dbo.DrugDepartmentWiseStockOuts", new[] { "DepartmentId" });
            DropIndex("dbo.DrugDepartmentWiseStockOutDetails", new[] { "DRUGId" });
            DropIndex("dbo.DrugDepartmentWiseStockOutDetails", new[] { "DrugDepartmentWiseStockOutId" });
            //AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int());
            DropTable("dbo.DrugDepartmentWiseStockOuts");
            DropTable("dbo.DrugDepartmentWiseStockOutDetails");
        }
    }
}
