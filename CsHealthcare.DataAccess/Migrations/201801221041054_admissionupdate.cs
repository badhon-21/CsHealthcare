namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admissionupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientAdmissionDetails", "PatientAdmissionId", "dbo.PatientAdmissions");
            AddForeignKey("dbo.PatientAdmissionDetails", "PatientAdmissionId", "dbo.PatientAdmissions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientAdmissionDetails", "PatientAdmissionId", "dbo.PatientAdmissions");
            AddForeignKey("dbo.PatientAdmissionDetails", "PatientAdmissionId", "dbo.PatientAdmissions", "Id");
        }
    }
}
