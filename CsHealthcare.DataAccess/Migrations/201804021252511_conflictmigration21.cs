namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflictmigration21 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.OptPatientBills", "Department", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.OptPatientBills", "Department");
        }
    }
}
