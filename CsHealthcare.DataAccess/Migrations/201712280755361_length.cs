namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DRUG", "D_TRADE_NAME", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.DRUG", "D_GENERIC_NAME", c => c.String(maxLength: 500));
            AlterColumn("dbo.DRUG", "D_UNIT_STRENGTH", c => c.String(maxLength: 500));
            AlterColumn("dbo.DRUG", "D_DISPENSE_FROM", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DRUG", "D_DISPENSE_FROM", c => c.String(maxLength: 50));
            AlterColumn("dbo.DRUG", "D_UNIT_STRENGTH", c => c.String(maxLength: 80));
            AlterColumn("dbo.DRUG", "D_GENERIC_NAME", c => c.String(maxLength: 80));
            AlterColumn("dbo.DRUG", "D_TRADE_NAME", c => c.String(nullable: false, maxLength: 80));
        }
    }
}
