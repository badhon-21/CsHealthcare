namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientinfor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientAdmissions", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientAdmissions", new[] { "PatientId" });
            DropColumn("dbo.PatientAdmissions", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientAdmissions", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientAdmissions", "PatientId");
            AddForeignKey("dbo.PatientAdmissions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
