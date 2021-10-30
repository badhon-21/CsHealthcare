namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teststatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "TestStatus", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "TestStatus");
        }
    }
}
