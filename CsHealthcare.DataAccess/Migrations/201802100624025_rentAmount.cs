namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentAmbulances", "Amount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentAmbulances", "Amount");
        }
    }
}
