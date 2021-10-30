namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientDetails", "TestNameId", "dbo.Test_Name");
            DropForeignKey("dbo.PatientDetails", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.PatientDetails", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientDetails", new[] { "PatientId" });
            DropIndex("dbo.PatientDetails", new[] { "TestNameId" });
            DropTable("dbo.PatientDetails");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PatientDetails", "TestNameId");
            CreateIndex("dbo.PatientDetails", "PatientId");
            AddForeignKey("dbo.PatientDetails", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientDetails", "PatientId", "dbo.PatientInformations", "Id");
            AddForeignKey("dbo.PatientDetails", "TestNameId", "dbo.Test_Name", "T_ID", cascadeDelete: true);
        }
    }
}
