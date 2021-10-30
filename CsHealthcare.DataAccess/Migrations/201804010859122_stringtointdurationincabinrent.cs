namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringtointdurationincabinrent : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.InPatientDischarges", "TransferredCabinName", c => c.String());
            //AddColumn("dbo.InPatientDischarges", "TransferredCabinBill", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CabinRents", "Duration", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CabinRents", "Duration", c => c.String(maxLength: 50));
            //DropColumn("dbo.InPatientDischarges", "TransferredCabinBill");
            //DropColumn("dbo.InPatientDischarges", "TransferredCabinName");
        }
    }
}
