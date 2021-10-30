namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ambu11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentAmbulances", "Voucher", c => c.String());
            AddColumn("dbo.RentAmbulances", "RecStatus", c => c.String());
            AddColumn("dbo.RentAmbulances", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentAmbulances", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.RentAmbulances", "CreatedBy", c => c.String());
            AddColumn("dbo.RentAmbulances", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentAmbulances", "ModifiedBy");
            DropColumn("dbo.RentAmbulances", "CreatedBy");
            DropColumn("dbo.RentAmbulances", "ModifiedDate");
            DropColumn("dbo.RentAmbulances", "CreatedDate");
            DropColumn("dbo.RentAmbulances", "RecStatus");
            DropColumn("dbo.RentAmbulances", "Voucher");
        }
    }
}
