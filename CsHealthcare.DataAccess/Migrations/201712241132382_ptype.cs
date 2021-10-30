namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ptype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PharmacyRequisitionDetails", "UnitStrength", c => c.String(maxLength: 80));
            AddColumn("dbo.PharmacyRequisitionDetails", "PresenatationType", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PharmacyRequisitionDetails", "PresenatationType");
            DropColumn("dbo.PharmacyRequisitionDetails", "UnitStrength");
        }
    }
}
