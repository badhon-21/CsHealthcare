namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addappointmentdialysis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientAppointmentDialysis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(maxLength: 50),
                        Time = c.String(maxLength: 20),
                        PatientType = c.String(maxLength: 10),
                        AppointmentType = c.String(maxLength: 50),
                        MobileNo = c.String(maxLength: 50),
                        Status = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientAppointmentDialysis", "PatientId", "dbo.PatientInformations");
            DropIndex("dbo.PatientAppointmentDialysis", new[] { "PatientId" });
            DropTable("dbo.PatientAppointmentDialysis");
        }
    }
}
