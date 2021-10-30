namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientadmissionupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "EmergencyContactName", c => c.String());
            AddColumn("dbo.PatientAdmissions", "EmergencyContactPersonRelation", c => c.String());
            AddColumn("dbo.PatientAdmissions", "EmergencyContactMobile", c => c.String());
            AddColumn("dbo.PatientAdmissions", "EmergencyContactPersonAddress", c => c.String());
            AddColumn("dbo.PatientAdmissions", "RrreferenceDoctor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "RrreferenceDoctor");
            DropColumn("dbo.PatientAdmissions", "EmergencyContactPersonAddress");
            DropColumn("dbo.PatientAdmissions", "EmergencyContactMobile");
            DropColumn("dbo.PatientAdmissions", "EmergencyContactPersonRelation");
            DropColumn("dbo.PatientAdmissions", "EmergencyContactName");
        }
    }
}
