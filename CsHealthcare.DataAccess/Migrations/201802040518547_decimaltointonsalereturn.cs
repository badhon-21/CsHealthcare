namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimaltointonsalereturn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InPatientDrugSaleReturnDetails", "ReturnQty", c => c.Int(nullable: false));
            AlterColumn("dbo.InPatientDrugSaleReturns", "ReturnQty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InPatientDrugSaleReturns", "ReturnQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InPatientDrugSaleReturnDetails", "ReturnQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
