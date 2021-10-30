namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vcnconcust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorAppointmentPayments", "Voucher", c => c.String());
            AddColumn("dbo.DialysisPayments", "Voucher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DialysisPayments", "Voucher");
            DropColumn("dbo.DoctorAppointmentPayments", "Voucher");
        }
    }
}
