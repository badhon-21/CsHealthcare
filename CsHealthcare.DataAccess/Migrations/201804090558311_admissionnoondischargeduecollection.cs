namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admissionnoondischargeduecollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischargeDueCollections", "AdmissionNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischargeDueCollections", "AdmissionNo");
        }
    }
}
