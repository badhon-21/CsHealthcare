namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inpatientdoctor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDoctorInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(),
                        DoctorId = c.String(maxLength: 128),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientDoctorInvoices", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.InPatientDoctorInvoices", "DoctorId", "dbo.DoctorInformations");
            DropIndex("dbo.InPatientDoctorInvoices", new[] { "DoctorId" });
            DropIndex("dbo.InPatientDoctorInvoices", new[] { "PatientId" });
            DropTable("dbo.InPatientDoctorInvoices");
        }
    }
}
