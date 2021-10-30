namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentstatusondischarge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "PaymentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "PaymentStatus");
        }
    }
}
