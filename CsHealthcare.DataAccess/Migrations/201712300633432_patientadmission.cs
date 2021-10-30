namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientadmission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientAdmissionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientAdmissionId = c.Int(nullable: false),
                        PurposeId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientAdmissions", t => t.PatientAdmissionId)
                .ForeignKey("dbo.Purposes", t => t.PurposeId, cascadeDelete: true)
                .Index(t => t.PatientAdmissionId)
                .Index(t => t.PurposeId);
            
            CreateTable(
                "dbo.PatientAdmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(),
                        CabinId = c.Int(nullable: false),
                        GivenAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeuAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cabins", t => t.CabinId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.CabinId);
            
            CreateTable(
                "dbo.Purposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurposeDescription = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientAdmissionDetails", "PurposeId", "dbo.Purposes");
            DropForeignKey("dbo.PatientAdmissionDetails", "PatientAdmissionId", "dbo.PatientAdmissions");
            DropForeignKey("dbo.PatientAdmissions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientAdmissions", "CabinId", "dbo.Cabins");
            DropIndex("dbo.PatientAdmissions", new[] { "CabinId" });
            DropIndex("dbo.PatientAdmissions", new[] { "PatientId" });
            DropIndex("dbo.PatientAdmissionDetails", new[] { "PurposeId" });
            DropIndex("dbo.PatientAdmissionDetails", new[] { "PatientAdmissionId" });
            DropTable("dbo.Purposes");
            DropTable("dbo.PatientAdmissions");
            DropTable("dbo.PatientAdmissionDetails");
        }
    }
}
