namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discharge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDischarges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(),
                        CabinId = c.Int(),
                        WardId = c.Int(),
                        BedId = c.Int(),
                        CabinAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientDailyBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientDrugBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        DischargeDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientDischarges", "PatientId", "dbo.Patients");
            DropIndex("dbo.InPatientDischarges", new[] { "PatientId" });
            DropTable("dbo.InPatientDischarges");
        }
    }
}
