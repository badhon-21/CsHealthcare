namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextconflict : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ICUs",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            PriceByDay = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            PriceByHour = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.InPatientTransferBacks",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(),
            //            CabinName = c.String(),
            //            ICUPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ICUName = c.String(),
            //            ICUType = c.String(),
            //            NoOfDays = c.Int(),
            //            NoOfHours = c.Int(),
            //            TransferDate = c.DateTime(nullable: false),
            //            BackDate = c.DateTime(nullable: false),
            //            Status = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.InPatientTransfers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(),
            //            CabinName = c.String(),
            //            ICUType = c.String(),
            //            ICUPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ICUName = c.String(),
            //            TransferDate = c.DateTime(nullable: false),
            //            Status = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.InPatientTransfers");
            //DropTable("dbo.InPatientTransferBacks");
            //DropTable("dbo.ICUs");
        }
    }
}
