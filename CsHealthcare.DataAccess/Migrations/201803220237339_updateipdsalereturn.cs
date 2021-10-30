namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateipdsalereturn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDrugSaleReturns", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientDrugSaleReturns", "RecStatus", c => c.String());
            AddColumn("dbo.InPatientDrugSaleReturns", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InPatientDrugSaleReturns", "CreatedBy", c => c.String());
            AddColumn("dbo.InPatientDrugSaleReturns", "ModifiedBy", c => c.String());
            AddColumn("dbo.InPatientDrugSaleReturns", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDrugSaleReturns", "ModifiedIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDrugSaleReturns", "ModifiedIpAddress");
            DropColumn("dbo.InPatientDrugSaleReturns", "CreatedIpAddress");
            DropColumn("dbo.InPatientDrugSaleReturns", "ModifiedBy");
            DropColumn("dbo.InPatientDrugSaleReturns", "CreatedBy");
            DropColumn("dbo.InPatientDrugSaleReturns", "ModifiedDate");
            DropColumn("dbo.InPatientDrugSaleReturns", "RecStatus");
            DropColumn("dbo.InPatientDrugSaleReturns", "AdmissionNo");
        }
    }
}
