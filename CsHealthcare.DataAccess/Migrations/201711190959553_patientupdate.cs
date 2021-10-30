namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        FatherName = c.String(maxLength: 100),
                        MotherName = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        BloodGroup = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        Sex = c.String(maxLength: 20),
                        OccupationId = c.Int(),
                        EducationId = c.Int(),
                        MobileNumber = c.String(maxLength: 20),
                        Picture = c.String(maxLength: 200),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("dbo.PatientDetails", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDetails", "PatientId", "dbo.Patients");
            DropTable("dbo.Patients");
        }
    }
}
