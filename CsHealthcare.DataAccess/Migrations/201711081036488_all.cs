namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeInfoes", "DepartmentId", "dbo.DEPARTMENTs");
            DropForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.AppPatientManagementUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.AppMedicineCornerUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.EmployeeInfoes", "HospitalInformation_Id", "dbo.HospitalInformations");
            DropForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeDesignationId", "dbo.EmployeeDesignations");
            DropForeignKey("dbo.AppAppointmentSystemUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropIndex("dbo.AppAppointmentSystemUsers", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EducationId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeDesignationId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "HospitalInformation_Id" });
            DropIndex("dbo.PatientInformations", new[] { "EducationId" });
            DropIndex("dbo.AppPatientManagementUsers", new[] { "EmployeeId" });
            DropIndex("dbo.AppMedicineCornerUsers", new[] { "EmployeeId" });
            DropIndex("dbo.LeaveOfAbsenceMasters", new[] { "EmployeeInfoId" });
            AlterColumn("dbo.AppAppointmentSystemUsers", "EmployeeId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AppPatientManagementUsers", "EmployeeId", c => c.String(maxLength: 50));
            AlterColumn("dbo.AppMedicineCornerUsers", "EmployeeId", c => c.String(maxLength: 50));
            AlterColumn("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", c => c.String());
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.Educations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.Id);
            
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
                        EducationId = c.Int(),
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
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AppMedicineCornerUsers", "EmployeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AppPatientManagementUsers", "EmployeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AppAppointmentSystemUsers", "EmployeeId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId");
            CreateIndex("dbo.AppMedicineCornerUsers", "EmployeeId");
            CreateIndex("dbo.AppPatientManagementUsers", "EmployeeId");
            CreateIndex("dbo.PatientInformations", "EducationId");
            CreateIndex("dbo.EmployeeInfoes", "HospitalInformation_Id");
            CreateIndex("dbo.EmployeeInfoes", "DepartmentId");
            CreateIndex("dbo.EmployeeInfoes", "EmployeeDesignationId");
            CreateIndex("dbo.EmployeeInfoes", "EducationId");
            CreateIndex("dbo.AppAppointmentSystemUsers", "EmployeeId");
            AddForeignKey("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", "dbo.EmployeeInfoes", "Id");
            AddForeignKey("dbo.AppAppointmentSystemUsers", "EmployeeId", "dbo.EmployeeInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeInfoes", "EmployeeDesignationId", "dbo.EmployeeDesignations", "ED_ID");
            AddForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations", "Id");
            AddForeignKey("dbo.EmployeeInfoes", "HospitalInformation_Id", "dbo.HospitalInformations", "Id");
            AddForeignKey("dbo.AppMedicineCornerUsers", "EmployeeId", "dbo.EmployeeInfoes", "Id");
            AddForeignKey("dbo.AppPatientManagementUsers", "EmployeeId", "dbo.EmployeeInfoes", "Id");
            AddForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations", "Id");
            AddForeignKey("dbo.EmployeeInfoes", "DepartmentId", "dbo.DEPARTMENTs", "Id");
        }
    }
}
