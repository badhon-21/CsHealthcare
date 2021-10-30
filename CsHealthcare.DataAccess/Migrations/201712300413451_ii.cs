namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ii : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.PatientInformations", "PatientCode", c => c.String(nullable: false, maxLength: 100));
            //AddColumn("dbo.Patients", "PatientCode", c => c.String(nullable: false, maxLength: 100));
            //AlterColumn("dbo.DRUG", "D_TRADE_NAME", c => c.String(nullable: false, maxLength: 500));
            //AlterColumn("dbo.DRUG", "D_GENERIC_NAME", c => c.String(maxLength: 500));
            //AlterColumn("dbo.DRUG", "D_UNIT_STRENGTH", c => c.String(maxLength: 500));
            //AlterColumn("dbo.DRUG", "D_DISPENSE_FROM", c => c.String(maxLength: 500));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "DrugName", c => c.String(maxLength: 500));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "GenericName", c => c.String(maxLength: 500));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "UnitStrength", c => c.String(maxLength: 500));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "PresenatationType", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.PharmacyRequisitionDetails", "PresenatationType", c => c.String(maxLength: 80));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "UnitStrength", c => c.String(maxLength: 80));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "GenericName", c => c.String(maxLength: 50));
            //AlterColumn("dbo.PharmacyRequisitionDetails", "DrugName", c => c.String(maxLength: 50));
            //AlterColumn("dbo.DRUG", "D_DISPENSE_FROM", c => c.String(maxLength: 50));
            //AlterColumn("dbo.DRUG", "D_UNIT_STRENGTH", c => c.String(maxLength: 80));
            //AlterColumn("dbo.DRUG", "D_GENERIC_NAME", c => c.String(maxLength: 80));
            //AlterColumn("dbo.DRUG", "D_TRADE_NAME", c => c.String(nullable: false, maxLength: 80));
            //DropColumn("dbo.Patients", "PatientCode");
            //DropColumn("dbo.PatientInformations", "PatientCode");
        }
    }
}
