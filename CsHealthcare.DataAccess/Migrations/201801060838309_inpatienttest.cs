namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inpatienttest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientTestdetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InPatientTestId = c.Int(nullable: false),
                        TestNameId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InPatientTests", t => t.InPatientTestId)
                .ForeignKey("dbo.Test_Name", t => t.TestNameId, cascadeDelete: true)
                .Index(t => t.InPatientTestId)
                .Index(t => t.TestNameId);
            
            CreateTable(
                "dbo.InPatientTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(nullable: false, maxLength: 100),
                        PatientId = c.Int(nullable: false),
                        DeuAmount = c.Decimal(precision: 18, scale: 2),
                        VoucherNo = c.String(maxLength: 100),
                        ItemQuantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientTestdetails", "TestNameId", "dbo.Test_Name");
            DropForeignKey("dbo.InPatientTests", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.InPatientTestdetails", "InPatientTestId", "dbo.InPatientTests");
            DropIndex("dbo.InPatientTests", new[] { "PatientId" });
            DropIndex("dbo.InPatientTestdetails", new[] { "TestNameId" });
            DropIndex("dbo.InPatientTestdetails", new[] { "InPatientTestId" });
            DropTable("dbo.InPatientTests");
            DropTable("dbo.InPatientTestdetails");
        }
    }
}
