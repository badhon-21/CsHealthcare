namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientlaser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientLasers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(),
                        CabinId = c.Int(),
                        WardId = c.Int(),
                        BedId = c.Int(),
                        AdvanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdvanceType = c.String(),
                        ChequeNumber = c.String(),
                        BankName = c.String(),
                        Remarks = c.String(),
                        ReceivedDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientLasers", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientLasers", new[] { "PatientId" });
            DropTable("dbo.PatientLasers");
        }
    }
}
