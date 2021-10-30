namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departdrug : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugDepartmentWiseStockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(maxLength: 50),
                        DepartmentId = c.String(),
                        DepartmentName = c.String(),
                        DrugId = c.Int(),
                        DrugName = c.String(),
                        TransferQty = c.Int(),
                        TotalQty = c.Decimal(precision: 18, scale: 2),
                        RemainingQuantity = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DrugDepartmentWiseStockIns");
        }
    }
}
