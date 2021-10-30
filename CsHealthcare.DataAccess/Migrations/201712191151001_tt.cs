namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.MicrobiologyTests", "TestDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.TestRequests", "PaymentStatus", c => c.String());
            //AddColumn("dbo.TestRequests", "VoucherNumber", c => c.String());
            //AlterColumn("dbo.TestRequests", "Status", c => c.String());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.TestRequests", "Status", c => c.String(maxLength: 10));
            //DropColumn("dbo.TestRequests", "VoucherNumber");
            //DropColumn("dbo.TestRequests", "PaymentStatus");
            //DropColumn("dbo.MicrobiologyTests", "TestDate");
        }
    }
}
