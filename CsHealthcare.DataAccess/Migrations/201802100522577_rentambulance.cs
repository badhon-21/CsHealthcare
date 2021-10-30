namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentambulance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentAmbulances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        VehicleName = c.String(maxLength: 100),
                        Driver = c.String(maxLength: 100),
                        Mobile = c.String(maxLength: 20),
                        FromRoute = c.String(maxLength: 100),
                        ToRoute = c.String(maxLength: 100),
                        Kelometer = c.Decimal(precision: 18, scale: 2),
                        PartyContactName = c.String(maxLength: 100),
                        PartyAddress = c.String(maxLength: 200),
                        PartyMobileNumber = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentAmbulances", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.RentAmbulances", new[] { "VehicleId" });
            DropTable("dbo.RentAmbulances");
        }
    }
}
