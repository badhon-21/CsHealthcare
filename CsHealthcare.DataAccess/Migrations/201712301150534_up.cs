namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CBCTests", "PatientCode", c => c.String(maxLength: 100));
            AddColumn("dbo.CBCTests", "ReferanceName", c => c.String(maxLength: 50));
            AddColumn("dbo.RETests", "PatientCode", c => c.String(maxLength: 100));
            AddColumn("dbo.RETests", "ReferanceName", c => c.String(maxLength: 50));
            AddColumn("dbo.SRETests", "PatientCode", c => c.String(maxLength: 100));
            AddColumn("dbo.SRETests", "ReferanceName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SRETests", "ReferanceName");
            DropColumn("dbo.SRETests", "PatientCode");
            DropColumn("dbo.RETests", "ReferanceName");
            DropColumn("dbo.RETests", "PatientCode");
            DropColumn("dbo.CBCTests", "ReferanceName");
            DropColumn("dbo.CBCTests", "PatientCode");
        }
    }
}
