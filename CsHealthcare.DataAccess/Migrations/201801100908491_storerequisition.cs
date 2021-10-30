namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storerequisition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreRequisitionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreRequsitionId = c.String(maxLength: 128),
                        StoreItemId = c.Int(nullable: false),
                        StoreItemName = c.String(maxLength: 100),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreRequisitions", t => t.StoreRequsitionId)
                .Index(t => t.StoreRequsitionId);
            
            CreateTable(
                "dbo.StoreRequisitions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DepartmentId = c.String(maxLength: 128),
                        RequisitionBy = c.String(maxLength: 100),
                        RequisitionNo = c.String(maxLength: 100),
                        RequisitionDate = c.DateTime(nullable: false),
                        ApprovedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreRequisitionDetails", "StoreRequsitionId", "dbo.StoreRequisitions");
            DropForeignKey("dbo.StoreRequisitions", "DepartmentId", "dbo.DEPARTMENTs");
            DropIndex("dbo.StoreRequisitions", new[] { "DepartmentId" });
            DropIndex("dbo.StoreRequisitionDetails", new[] { "StoreRequsitionId" });
            DropTable("dbo.StoreRequisitions");
            DropTable("dbo.StoreRequisitionDetails");
        }
    }
}
