namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transferupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientTransferBacks", "BedType", c => c.String());
            AddColumn("dbo.InPatientTransferBacks", "BedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InPatientTransferBacks", "BedName", c => c.String());
            AddColumn("dbo.InPatientTransfers", "BedType", c => c.String());
            AddColumn("dbo.InPatientTransfers", "BedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InPatientTransfers", "BedName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientTransfers", "BedName");
            DropColumn("dbo.InPatientTransfers", "BedPrice");
            DropColumn("dbo.InPatientTransfers", "BedType");
            DropColumn("dbo.InPatientTransferBacks", "BedName");
            DropColumn("dbo.InPatientTransferBacks", "BedPrice");
            DropColumn("dbo.InPatientTransferBacks", "BedType");
        }
    }
}
