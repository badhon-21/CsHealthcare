namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class therapyduecollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpdTherapyDueCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollectedDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviousDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PatientCode = c.String(),
                        PatientId = c.String(),
                        VoucherNo = c.String(),
                        CollectionDate = c.DateTime(nullable: false),
                        PreviousGivenAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TherapyId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedIpAddress = c.String(),
                        ModifiedIpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpdTherapyDueCollections");
        }
    }
}
