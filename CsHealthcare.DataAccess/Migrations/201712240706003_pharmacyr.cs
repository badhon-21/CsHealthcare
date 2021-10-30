namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pharmacyr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PharmacyRequisitionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PharmacyrequsitionId = c.String(maxLength: 128),
                        DrugId = c.Int(nullable: false),
                        DrugName = c.String(maxLength: 50),
                        GenericName = c.String(maxLength: 50),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PharmacyRequisitions", t => t.PharmacyrequsitionId)
                .Index(t => t.PharmacyrequsitionId);
            
            CreateTable(
                "dbo.PharmacyRequisitions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Department = c.String(maxLength: 100),
                        RequisitionBy = c.String(maxLength: 100),
                        ApprovedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PharmacyRequisitionDetails", "PharmacyrequsitionId", "dbo.PharmacyRequisitions");
            DropIndex("dbo.PharmacyRequisitionDetails", new[] { "PharmacyrequsitionId" });
            DropTable("dbo.PharmacyRequisitions");
            DropTable("dbo.PharmacyRequisitionDetails");
        }
    }
}
