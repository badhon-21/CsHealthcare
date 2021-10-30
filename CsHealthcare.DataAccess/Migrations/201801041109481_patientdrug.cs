namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientdrug : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDrugDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugId = c.Int(),
                        InPatientDrugId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        SubTotal = c.Decimal(precision: 18, scale: 2),
                        SaleDiscount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId)
                .ForeignKey("dbo.InPatientDrugs", t => t.InPatientDrugId)
                .Index(t => t.DrugId)
                .Index(t => t.InPatientDrugId);
            
            CreateTable(
                "dbo.InPatientDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(),
                        PatientCode = c.String(),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        SaleDiscount = c.Decimal(precision: 18, scale: 2),
                        Vat = c.Decimal(precision: 18, scale: 2),
                        SpecialDiscount = c.Decimal(precision: 18, scale: 2),
                        TotalPrice = c.Decimal(precision: 18, scale: 2),
                        SaleDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientDrugs", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.InPatientDrugDetails", "InPatientDrugId", "dbo.InPatientDrugs");
            DropForeignKey("dbo.InPatientDrugDetails", "DrugId", "dbo.DRUG");
            DropIndex("dbo.InPatientDrugs", new[] { "PatientId" });
            DropIndex("dbo.InPatientDrugDetails", new[] { "InPatientDrugId" });
            DropIndex("dbo.InPatientDrugDetails", new[] { "DrugId" });
            DropTable("dbo.InPatientDrugs");
            DropTable("dbo.InPatientDrugDetails");
        }
    }
}
