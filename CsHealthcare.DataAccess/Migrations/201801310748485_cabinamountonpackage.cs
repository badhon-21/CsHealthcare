namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cabinamountonpackage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "CabinAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "CabinAmount");
        }
    }
}
