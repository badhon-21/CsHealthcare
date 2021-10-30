namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "VoucherNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "VoucherNo");
        }
    }
}
