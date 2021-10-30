namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opdduecollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpdPatientDuebillCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollectedDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviousDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PatientCode = c.String(),
                        VoucherNo = c.String(),
                        CreatedBy = c.String(),
                        CollectionDate = c.DateTime(nullable: false),
                        PreviousGivenAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurposeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpdPatientDuebillCollections");
        }
    }
}
