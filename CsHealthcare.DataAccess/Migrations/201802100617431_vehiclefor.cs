namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehiclefor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentAmbulances", "VehicleFor", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentAmbulances", "VehicleFor");
        }
    }
}
