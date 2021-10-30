namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedraft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IpdDrafts", "AdmissionNo", c => c.String());
            AddColumn("dbo.IpdDrafts", "TransferredCabinName", c => c.String());
            AddColumn("dbo.IpdDrafts", "TransferredCabinBill", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.IpdDrafts", "Remarks", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IpdDrafts", "Remarks");
            DropColumn("dbo.IpdDrafts", "TransferredCabinBill");
            DropColumn("dbo.IpdDrafts", "TransferredCabinName");
            DropColumn("dbo.IpdDrafts", "AdmissionNo");
        }
    }
}
