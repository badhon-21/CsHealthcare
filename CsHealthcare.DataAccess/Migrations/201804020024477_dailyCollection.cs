namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailyCollection : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_DAILY_USER_COLLECTION",
            //    c => new
            //        {
            //            VID = c.Guid(nullable: false),
            //            Id = c.Int(nullable: false),
            //            VoucherNo = c.String(),
            //            AdmissionNo = c.String(),
            //            PatientId = c.String(),
            //            PatientCode = c.String(),
            //            PatientName = c.String(),
            //            DrugId = c.String(),
            //            DrugName = c.String(),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Quantity = c.Int(nullable: false),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SaleDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SaleDateTime = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.VID);
            
            //AddColumn("dbo.InPatientDischarges", "TransferredCabinName", c => c.String());
            //AddColumn("dbo.InPatientDischarges", "TransferredCabinBill", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.InPatientDischarges", "TransferredCabinBill");
            //DropColumn("dbo.InPatientDischarges", "TransferredCabinName");
            //DropTable("dbo.VW_DAILY_USER_COLLECTION");
        }
    }
}
