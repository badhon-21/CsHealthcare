namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleup : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Vehicles",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            VehicleId = c.String(),
            //            Title = c.String(maxLength: 100),
            //            Description = c.String(maxLength: 100),
            //            PurchaseDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.Vehicles");
        }
    }
}
