namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class days : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "CabinRentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientAdmissions", "NoOfDays", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "NoOfDays");
            DropColumn("dbo.PatientAdmissions", "CabinRentDate");
        }
    }
}
