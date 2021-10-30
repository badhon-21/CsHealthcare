namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class operationtheatre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OperationTheatres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(),
                        OperationDate = c.DateTime(nullable: false),
                        OperationName = c.String(),
                        OperationStartTime = c.String(),
                        OperationEndTime = c.String(),
                        OperationType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurposeOnOTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurposeId = c.Int(nullable: false),
                        OperationTheatreId = c.Int(nullable: false),
                        PurposeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purposes", t => t.PurposeId, cascadeDelete: true)
                .ForeignKey("dbo.OperationTheatres", t => t.OperationTheatreId)
                .Index(t => t.PurposeId)
                .Index(t => t.OperationTheatreId);
            
            CreateTable(
                "dbo.SurgeonNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(maxLength: 128),
                        DoctorName = c.String(),
                        SurgeonAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperationTheatreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .ForeignKey("dbo.OperationTheatres", t => t.OperationTheatreId)
                .Index(t => t.DoctorId)
                .Index(t => t.OperationTheatreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurgeonNames", "OperationTheatreId", "dbo.OperationTheatres");
            DropForeignKey("dbo.SurgeonNames", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.PurposeOnOTs", "OperationTheatreId", "dbo.OperationTheatres");
            DropForeignKey("dbo.PurposeOnOTs", "PurposeId", "dbo.Purposes");
            DropIndex("dbo.SurgeonNames", new[] { "OperationTheatreId" });
            DropIndex("dbo.SurgeonNames", new[] { "DoctorId" });
            DropIndex("dbo.PurposeOnOTs", new[] { "OperationTheatreId" });
            DropIndex("dbo.PurposeOnOTs", new[] { "PurposeId" });
            DropTable("dbo.SurgeonNames");
            DropTable("dbo.PurposeOnOTs");
            DropTable("dbo.OperationTheatres");
        }
    }
}
