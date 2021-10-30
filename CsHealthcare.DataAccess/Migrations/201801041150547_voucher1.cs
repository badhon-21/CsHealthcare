namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDrugs", "VoucherNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDrugs", "VoucherNo");
        }
    }
}
