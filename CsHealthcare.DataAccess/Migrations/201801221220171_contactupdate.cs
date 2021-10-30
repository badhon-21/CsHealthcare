namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "Telephone", c => c.String());
            AddColumn("dbo.PatientAdmissions", "HomePhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "HomePhone");
            DropColumn("dbo.PatientAdmissions", "Telephone");
        }
    }
}
