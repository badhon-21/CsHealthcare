namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ipdduecollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDischargeDueCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(),
                        CollectedDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviousDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherNo = c.String(),
                        CreatedBy = c.String(),
                        CollectionDate = c.DateTime(nullable: false),
                        PreviousGivenAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InPatientDischargeDueCollections");
        }
    }
}
