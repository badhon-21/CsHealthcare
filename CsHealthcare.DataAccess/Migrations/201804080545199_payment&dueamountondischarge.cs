namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentdueamountondischarge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "PaymentAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.InPatientDischarges", "DueAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "DueAmount");
            DropColumn("dbo.InPatientDischarges", "PaymentAmount");
        }
    }
}
