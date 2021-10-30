namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        TestNameId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        PatientInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Test_Name", t => t.TestNameId, cascadeDelete: true)
                .ForeignKey("dbo.PatientInformations", t => t.PatientInformation_Id)
                .Index(t => t.PatientId)
                .Index(t => t.TestNameId)
                .Index(t => t.PatientInformation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDetails", "PatientInformation_Id", "dbo.PatientInformations");
            DropForeignKey("dbo.PatientDetails", "TestNameId", "dbo.Test_Name");
            DropForeignKey("dbo.PatientDetails", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientDetails", new[] { "PatientInformation_Id" });
            DropIndex("dbo.PatientDetails", new[] { "TestNameId" });
            DropIndex("dbo.PatientDetails", new[] { "PatientId" });
            DropTable("dbo.PatientDetails");
        }
    }
}
