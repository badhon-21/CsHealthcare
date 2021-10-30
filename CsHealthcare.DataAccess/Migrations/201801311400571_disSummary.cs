namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disSummary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDischargeSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(nullable: false, maxLength: 100),
                        PatientId = c.Int(nullable: false),
                        AdmissionId = c.Int(nullable: false),
                        Diadiagnostic = c.String(maxLength: 100),
                        Prescription = c.String(),
                        Summary = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientDischargeSummaries", "PatientId", "dbo.Patients");
            DropIndex("dbo.InPatientDischargeSummaries", new[] { "PatientId" });
            DropTable("dbo.InPatientDischargeSummaries");
        }
    }
}
