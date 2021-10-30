namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assistantdoctor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssistantDoctors",
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
            DropForeignKey("dbo.AssistantDoctors", "OperationTheatreId", "dbo.OperationTheatres");
            DropForeignKey("dbo.AssistantDoctors", "DoctorId", "dbo.DoctorInformations");
            DropIndex("dbo.AssistantDoctors", new[] { "OperationTheatreId" });
            DropIndex("dbo.AssistantDoctors", new[] { "DoctorId" });
            DropTable("dbo.AssistantDoctors");
        }
    }
}
