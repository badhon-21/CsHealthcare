namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientTests", "TestDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.InPatientTests", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientTests", "CreatedDate");
            DropColumn("dbo.InPatientTests", "TestDate");
        }
    }
}
