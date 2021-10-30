namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Tag = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        FamilyName = c.String(maxLength: 100),
                        DateOfBirth = c.DateTime(),
                        BirthPlace = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 50),
                        Religion = c.String(maxLength: 50),
                        BloodGroup = c.String(maxLength: 20),
                        Nationality = c.String(maxLength: 100),
                        NationalId = c.String(maxLength: 100),
                        PassportNumber = c.String(),
                        TinNumber = c.String(maxLength: 100),
                        FatherName = c.String(maxLength: 100),
                        FatherOccupation = c.String(maxLength: 100),
                        MotherName = c.String(maxLength: 100),
                        MotherOccupation = c.String(maxLength: 100),
                        MaritalStatus = c.String(maxLength: 20),
                        MarriageDate = c.DateTime(),
                        SpouseName = c.String(maxLength: 100),
                        SpouseOccupation = c.String(maxLength: 100),
                        PresentAddress = c.String(maxLength: 100),
                        PermanentAddress = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Website = c.String(maxLength: 100),
                        EmployeeDesignationId = c.String(maxLength: 50),
                        DepartmentId = c.String(maxLength: 128),
                        ContractType = c.String(maxLength: 50),
                        ContractPeriod = c.String(maxLength: 100),
                        DateOfJob = c.DateTime(),
                        Photo = c.String(maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        HospitalInformation_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalInformation_Id)
                .ForeignKey("dbo.EmployeeDesignations", t => t.EmployeeDesignationId)
                .Index(t => t.EmployeeDesignationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.HospitalInformation_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeInfoId = c.String(maxLength: 128),
                        DegreeName = c.String(nullable: false, maxLength: 100),
                        Institution = c.String(maxLength: 100),
                        Grade = c.String(maxLength: 10),
                        CourseDuration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Scale = c.Int(nullable: false),
                        Year = c.String(maxLength: 4),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeInfoId)
                .Index(t => t.EmployeeInfoId);
            
            AlterColumn("dbo.AppAppointmentSystemUsers", "EmployeeId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AppMedicineCornerUsers", "EmployeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AppPatientManagementUsers", "EmployeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AppAppointmentSystemUsers", "EmployeeId");
            CreateIndex("dbo.PatientInformations", "EducationId");
            CreateIndex("dbo.AppPatientManagementUsers", "EmployeeId");
            CreateIndex("dbo.AppMedicineCornerUsers", "EmployeeId");
            CreateIndex("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId");
            AddForeignKey("dbo.AppPatientManagementUsers", "EmployeeId", "dbo.EmployeeInfoes", "Id");
            AddForeignKey("dbo.AppMedicineCornerUsers", "EmployeeId", "dbo.EmployeeInfoes", "Id");
            AddForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations", "Id");
            AddForeignKey("dbo.AppAppointmentSystemUsers", "EmployeeId", "dbo.EmployeeInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", "dbo.EmployeeInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.AppAppointmentSystemUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeDesignationId", "dbo.EmployeeDesignations");
            DropForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.EmployeeInfoes", "HospitalInformation_Id", "dbo.HospitalInformations");
            DropForeignKey("dbo.AppMedicineCornerUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.AppPatientManagementUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.Educations", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.EmployeeInfoes", "DepartmentId", "dbo.DEPARTMENTs");
            DropIndex("dbo.LeaveOfAbsenceMasters", new[] { "EmployeeInfoId" });
            DropIndex("dbo.AppMedicineCornerUsers", new[] { "EmployeeId" });
            DropIndex("dbo.AppPatientManagementUsers", new[] { "EmployeeId" });
            DropIndex("dbo.PatientInformations", new[] { "EducationId" });
            DropIndex("dbo.Educations", new[] { "EmployeeInfoId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "HospitalInformation_Id" });
            DropIndex("dbo.EmployeeInfoes", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeDesignationId" });
            DropIndex("dbo.AppAppointmentSystemUsers", new[] { "EmployeeId" });
            AlterColumn("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", c => c.String());
            AlterColumn("dbo.AppPatientManagementUsers", "EmployeeId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AppMedicineCornerUsers", "EmployeeId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AppAppointmentSystemUsers", "EmployeeId", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.Educations");
            DropTable("dbo.EmployeeInfoes");
        }
    }
}
