namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentAmbulances", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentAmbulances", "Date");
        }
    }
}
