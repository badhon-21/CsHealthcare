namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailslength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PharmacyRequisitionDetails", "DrugName", c => c.String(maxLength: 500));
            AlterColumn("dbo.PharmacyRequisitionDetails", "GenericName", c => c.String(maxLength: 500));
            AlterColumn("dbo.PharmacyRequisitionDetails", "UnitStrength", c => c.String(maxLength: 500));
            AlterColumn("dbo.PharmacyRequisitionDetails", "PresenatationType", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PharmacyRequisitionDetails", "PresenatationType", c => c.String(maxLength: 80));
            AlterColumn("dbo.PharmacyRequisitionDetails", "UnitStrength", c => c.String(maxLength: 80));
            AlterColumn("dbo.PharmacyRequisitionDetails", "GenericName", c => c.String(maxLength: 50));
            AlterColumn("dbo.PharmacyRequisitionDetails", "DrugName", c => c.String(maxLength: 50));
        }
    }
}
