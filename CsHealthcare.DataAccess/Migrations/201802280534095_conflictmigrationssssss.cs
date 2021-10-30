namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflictmigrationssssss : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.DialysisPayments", "GrossAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.DialysisPayments", "FinalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //DropColumn("dbo.DialysisPayments", "Amount");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.DialysisPayments", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //DropColumn("dbo.DialysisPayments", "FinalAmount");
            //DropColumn("dbo.DialysisPayments", "GrossAmount");
        }
    }
}
