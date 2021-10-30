namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatdailybill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDailyBills", "VoucherNo", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "NoOfDays", c => c.Int(nullable: false));
            AddColumn("dbo.InPatientDailyBills", "TransactionType", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "TransactionNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDailyBills", "TransactionNumber");
            DropColumn("dbo.InPatientDailyBills", "TransactionType");
            DropColumn("dbo.InPatientDailyBills", "NoOfDays");
            DropColumn("dbo.InPatientDailyBills", "VoucherNo");
        }
    }
}
