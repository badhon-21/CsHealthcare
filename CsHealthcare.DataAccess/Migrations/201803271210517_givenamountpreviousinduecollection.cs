namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class givenamountpreviousinduecollection : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CabinToCabinTransfers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(),
            //            CabinId = c.Int(nullable: false),
            //            CabinName = c.String(),
            //            TransferedCabinId = c.Int(nullable: false),
            //            TransferedCabinName = c.String(),
            //            TransferDate = c.DateTime(nullable: false),
            //            CabinAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //            AdmissionNo = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.CabinTransferBacks",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(),
            //            CabinId = c.Int(nullable: false),
            //            CabinName = c.String(),
            //            TransferedCabinId = c.Int(nullable: false),
            //            TransferedCabinName = c.String(),
            //            NoOfDays = c.Int(nullable: false),
            //            TransferDate = c.DateTime(nullable: false),
            //            TransferBackDate = c.DateTime(nullable: false),
            //            CabinAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //            AdmissionNo = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PatientDueCollections", "PreviousGivenAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDueCollections", "PreviousGivenAmount");
            //DropTable("dbo.CabinTransferBacks");
            //DropTable("dbo.CabinToCabinTransfers");
        }
    }
}
