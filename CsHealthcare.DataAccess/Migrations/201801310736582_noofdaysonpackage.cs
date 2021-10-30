namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noofdaysonpackage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packages", "NoOfDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packages", "NoOfDays");
        }
    }
}
