namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requestup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestRequests", "PaymentStatus", c => c.String());
            AddColumn("dbo.TestRequests", "VoucherNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestRequests", "VoucherNumber");
            DropColumn("dbo.TestRequests", "PaymentStatus");
        }
    }
}
