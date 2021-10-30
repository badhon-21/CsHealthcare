namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "VoucherNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "VoucherNo");
        }
    }
}
