namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucherno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "VoucherNo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "VoucherNo");
        }
    }
}
