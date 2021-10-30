namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class st : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "Status");
        }
    }
}
