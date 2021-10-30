namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllergyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllergySubstances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AllergyInformationId = c.Int(nullable: false),
                        Details = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AllergyInformations", t => t.AllergyInformationId, cascadeDelete: true)
                .Index(t => t.AllergyInformationId);
            
            CreateTable(
                "dbo.PatientAllergyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        AllergyInformationId = c.Int(nullable: false),
                        AllergySubstanceId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AllergyInformations", t => t.AllergyInformationId, cascadeDelete: true)
                .ForeignKey("dbo.AllergySubstances", t => t.AllergySubstanceId)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.AllergyInformationId)
                .Index(t => t.AllergySubstanceId);
            
            CreateTable(
                "dbo.AppAppointmentSystemUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        HospitalId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.HospitalId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                        MarriageDate = c.DateTime(nullable: false),
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
                        HospitalInformation_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .ForeignKey("dbo.EmployeeDesignations", t => t.EmployeeDesignationId)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalInformation_Id)
                .Index(t => t.EmployeeDesignationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.HospitalInformation_Id);
            
            CreateTable(
                "dbo.DEPARTMENTs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Address = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeDesignations",
                c => new
                    {
                        ED_ID = c.String(nullable: false, maxLength: 50),
                        ED_DESIGNATION = c.String(maxLength: 100),
                        ED_SHORT_FORM = c.String(maxLength: 100),
                        ED_NO_POSITION = c.String(maxLength: 100),
                        ED_HOUR_PER_WEEK = c.String(maxLength: 100),
                        ED_FLSA_CODE = c.String(maxLength: 100),
                        ED_GL_ID = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ED_ID);
            
            CreateTable(
                "dbo.HospitalInformations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        ContactPersonName = c.String(maxLength: 100),
                        ContactPersonMobile = c.String(maxLength: 50),
                        Address = c.String(maxLength: 500),
                        Mobile = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Logo = c.String(maxLength: 200),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppMedicineCornerUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        HospitalId = c.String(maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeId)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.HospitalId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AppPatientManagementUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        HospitalId = c.String(maxLength: 128),
                        DoctorId = c.String(maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeId)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.HospitalId)
                .Index(t => t.DoctorId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.DoctorInformations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HospitalId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Degree = c.String(maxLength: 500),
                        License = c.String(maxLength: 50),
                        Image = c.String(maxLength: 200),
                        Speciality = c.String(maxLength: 50),
                        OfficeAddress = c.String(maxLength: 200),
                        OfficePhone = c.String(maxLength: 50),
                        ChamberAddress = c.String(maxLength: 200),
                        ChamberPhone = c.String(maxLength: 50),
                        MobileNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.DoctorAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(maxLength: 128),
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
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.PatientInformations",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.EducationId)
                .ForeignKey("dbo.Occupations", t => t.OccupationId)
                .Index(t => t.OccupationId)
                .Index(t => t.EducationId);
            
            CreateTable(
                "dbo.DrugSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(maxLength: 50),
                        TxnNo = c.String(maxLength: 50),
                        LotId = c.String(maxLength: 50),
                        PatientId = c.Int(),
                        DrugId = c.Int(),
                        SaleQty = c.Decimal(precision: 18, scale: 2),
                        SalePrice = c.Decimal(precision: 18, scale: 2),
                        SaleDiscount = c.Decimal(precision: 18, scale: 2),
                        Vat = c.Decimal(precision: 18, scale: 2),
                        SpecialDiscount = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        SaleDateTime = c.DateTime(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.DRUG",
                c => new
                    {
                        D_ID = c.Int(nullable: false, identity: true),
                        D_DM_ID = c.Int(nullable: false),
                        D_DPT_ID = c.Int(nullable: false),
                        D_TRADE_NAME = c.String(nullable: false, maxLength: 80),
                        D_GENERIC_NAME = c.String(maxLength: 80),
                        D_UNIT_STRENGTH = c.String(maxLength: 80),
                        D_DISPENSE_FROM = c.String(maxLength: 50),
                        D_REORDER_LEVEL = c.Int(),
                        D_PACK_QTY = c.Int(),
                        D_STATUS = c.String(maxLength: 1),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.D_ID)
                .ForeignKey("dbo.DRUG_MANUFACTURER", t => t.D_DM_ID)
                .ForeignKey("dbo.DURG_PRESENTATION_TYPE", t => t.D_DPT_ID)
                .Index(t => t.D_DM_ID)
                .Index(t => t.D_DPT_ID);
            
            CreateTable(
                "dbo.DRUG_MANUFACTURER",
                c => new
                    {
                        DM_ID = c.Int(nullable: false, identity: true),
                        DM_NAME = c.String(nullable: false, maxLength: 50),
                        DM_TYPE = c.String(maxLength: 20),
                        DM_CONTACT_PERSON = c.String(maxLength: 50),
                        DM_ADDRESS = c.String(maxLength: 500),
                        DM_MOBILE = c.String(maxLength: 50),
                        DM_PHONE = c.String(maxLength: 50),
                        DM_FAX = c.String(maxLength: 50),
                        DM_EMAIL = c.String(maxLength: 50),
                        DM_WEB = c.String(maxLength: 50),
                        DM_STATUS = c.String(maxLength: 1),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DM_ID);
            
            CreateTable(
                "dbo.DURG_PRESENTATION_TYPE",
                c => new
                    {
                        DPT_ID = c.Int(nullable: false, identity: true),
                        DPT_DESCRIPTION = c.String(nullable: false, maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DPT_ID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DegreeName = c.String(nullable: false, maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        TestNameId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Test_Name", t => t.TestNameId, cascadeDelete: true)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.TestNameId);
            
            CreateTable(
                "dbo.Test_Name",
                c => new
                    {
                        T_ID = c.Int(nullable: false, identity: true),
                        T_TC_ID = c.Int(),
                        T_NAME = c.String(maxLength: 250),
                        T_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.T_ID)
                .ForeignKey("dbo.TEST_CATEGORY", t => t.T_TC_ID)
                .Index(t => t.T_TC_ID);
            
            CreateTable(
                "dbo.TEST_CATEGORY",
                c => new
                    {
                        TC_ID = c.Int(nullable: false, identity: true),
                        TC_TITLE = c.String(maxLength: 250),
                        TC_DESCRIPTION = c.String(maxLength: 500),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.TC_ID);
            
            CreateTable(
                "dbo.PatientEnrolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNo = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(maxLength: 30),
                        Type = c.String(maxLength: 20),
                        Status = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.DoctorAppointmentPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientEnrollId = c.Int(),
                        VisitNo = c.Int(),
                        MsAmountPurposeId = c.Int(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Reason = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MsAmountPurposes", t => t.MsAmountPurposeId)
                .ForeignKey("dbo.PatientEnrolls", t => t.PatientEnrollId)
                .Index(t => t.PatientEnrollId)
                .Index(t => t.MsAmountPurposeId);
            
            CreateTable(
                "dbo.MsAmountPurposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(maxLength: 128),
                        Description = c.String(maxLength: 250),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Type = c.String(maxLength: 10),
                        IpAddress = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.PatientHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        HistoryTakenDate = c.DateTime(nullable: false),
                        HistoryTakenTime = c.DateTime(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.PatientChiefComplaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        ChiefComplaintId = c.Int(nullable: false),
                        ChiefComplaintDetailsId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChiefComplaints", t => t.ChiefComplaintId, cascadeDelete: true)
                .ForeignKey("dbo.ChiefComplaintDurations", t => t.ChiefComplaintDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.ChiefComplaintId)
                .Index(t => t.ChiefComplaintDetailsId);
            
            CreateTable(
                "dbo.ChiefComplaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChiefComplaintDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientFamilyDiseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        DiseaseId = c.Int(nullable: false),
                        FamilyTreeId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyTrees", t => t.FamilyTreeId, cascadeDelete: true)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.DiseaseId)
                .Index(t => t.FamilyTreeId);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        MD_ID = c.Int(nullable: false, identity: true),
                        MD_NAME = c.String(nullable: false, maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.MD_ID);
            
            CreateTable(
                "dbo.PatientPastIllnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        DiseaseId = c.Int(nullable: false),
                        DiseaseConditionId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.DiseaseConditions", t => t.DiseaseConditionId, cascadeDelete: true)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.DiseaseId)
                .Index(t => t.DiseaseConditionId);
            
            CreateTable(
                "dbo.DiseaseConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 150),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyTrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientGeneralExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        BloodPressure = c.String(maxLength: 20),
                        PulseRatePerMinutes = c.String(maxLength: 20),
                        PulseRythm = c.String(maxLength: 20),
                        PulseType = c.String(maxLength: 20),
                        Temperature = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId);
            
            CreateTable(
                "dbo.PatientPastHistoryOfMadications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        DurgPresentationTypeId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.DURG_PRESENTATION_TYPE", t => t.DurgPresentationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.DurgPresentationTypeId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.PatientPersonalHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        MaritalStatus = c.String(nullable: false, maxLength: 20),
                        SocialEconomicStatusId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.SocialEconomicStatus", t => t.SocialEconomicStatusId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.SocialEconomicStatusId);
            
            CreateTable(
                "dbo.PatientPersonalHistoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientPersonalHistoryId = c.Int(nullable: false),
                        PatientPersonalAttributeId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientPersonalAttributes", t => t.PatientPersonalHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.PatientPersonalHistories", t => t.PatientPersonalAttributeId, cascadeDelete: true)
                .Index(t => t.PatientPersonalHistoryId)
                .Index(t => t.PatientPersonalAttributeId);
            
            CreateTable(
                "dbo.PatientPersonalAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialEconomicStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientPrescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientHistoryId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        BriefSummary = c.String(),
                        OrthopedicFindings = c.String(),
                        Diagonosis = c.String(),
                        NextReviewDate = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.PatientHistories", t => t.PatientHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientHistoryId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.OperationNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrescriptionId = c.Int(nullable: false),
                        DoctorId = c.String(maxLength: 128),
                        PlaceOfOperation = c.String(maxLength: 100),
                        DateOfOperation = c.DateTime(nullable: false),
                        PreOpDiagnosis = c.String(maxLength: 150),
                        PerOpDiagnosis = c.String(maxLength: 150),
                        NameOfOperation = c.String(maxLength: 100),
                        Anaesthesia = c.String(maxLength: 50),
                        Anesthesiologist = c.String(maxLength: 100),
                        TimeOfSurgery = c.String(maxLength: 50),
                        TimeOfAnesthesia = c.String(maxLength: 50),
                        Surgeon = c.String(maxLength: 100),
                        Asistant = c.String(maxLength: 100),
                        PositionOfPatient = c.String(maxLength: 100),
                        Description = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
                .ForeignKey("dbo.PatientPrescriptions", t => t.PrescriptionId, cascadeDelete: true)
                .Index(t => t.PrescriptionId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.PatientInvestigations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientPrescriptionId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        Findings = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientPrescriptions", t => t.PatientPrescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Test_Name", t => t.TestId, cascadeDelete: true)
                .Index(t => t.PatientPrescriptionId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.PatientSpecialNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientPrescriptionId = c.Int(nullable: false),
                        SpecialNoteId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientPrescriptions", t => t.PatientPrescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.SpecialNotes", t => t.SpecialNoteId, cascadeDelete: true)
                .Index(t => t.PatientPrescriptionId)
                .Index(t => t.SpecialNoteId);
            
            CreateTable(
                "dbo.SpecialNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientTreatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientPrescriptionId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        DrugDoseId = c.Int(nullable: false),
                        DrugDurationId = c.Int(nullable: false),
                        DoctorNoteId = c.Int(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorNotes", t => t.DoctorNoteId, cascadeDelete: true)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.DrugDoses", t => t.DrugDoseId, cascadeDelete: true)
                .ForeignKey("dbo.DrugDurations", t => t.DrugDurationId, cascadeDelete: true)
                .ForeignKey("dbo.PatientPrescriptions", t => t.PatientPrescriptionId, cascadeDelete: true)
                .Index(t => t.PatientPrescriptionId)
                .Index(t => t.DrugId)
                .Index(t => t.DrugDoseId)
                .Index(t => t.DrugDurationId)
                .Index(t => t.DoctorNoteId);
            
            CreateTable(
                "dbo.DoctorNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(maxLength: 200),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrugDoses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DD_D_ID = c.Int(nullable: false),
                        DD_DPT_ID = c.Int(),
                        Description = c.String(maxLength: 250),
                        RecStatus = c.String(maxLength: 1),
                        SetDateTime = c.DateTime(),
                        SetUpUser = c.String(maxLength: 50),
                        DRUG_D_ID = c.Int(),
                        DURG_PRESENTATION_TYPE_DPT_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DRUG_D_ID)
                .ForeignKey("dbo.DURG_PRESENTATION_TYPE", t => t.DURG_PRESENTATION_TYPE_DPT_ID)
                .Index(t => t.DRUG_D_ID)
                .Index(t => t.DURG_PRESENTATION_TYPE_DPT_ID);
            
            CreateTable(
                "dbo.DrugDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportScanCopies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PrescriptionId = c.Int(nullable: false),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        DeliveryDate = c.String(maxLength: 20),
                        Url = c.String(maxLength: 500),
                        ThumbnailUrl = c.String(maxLength: 500),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientPrescriptions", t => t.PrescriptionId, cascadeDelete: true)
                .Index(t => t.PrescriptionId);
            
            CreateTable(
                "dbo.PatientOldInvestigations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        Findings = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Test_Name", t => t.TestId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.VisitDiscounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 1),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.DoctorBusinessHolidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        SpecificDate = c.Boolean(nullable: false),
                        DayOfTheWeek = c.Boolean(nullable: false),
                        DayOfTheMonth = c.Boolean(nullable: false),
                        DayOfTheYear = c.Boolean(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.DoctorBusinessHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        WeekDay = c.String(nullable: false, maxLength: 20),
                        FromTime = c.DateTime(nullable: false),
                        ToTime = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorInformations", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        HospitalId = c.String(maxLength: 128),
                        Pharmacy = c.String(maxLength: 1),
                        Appointment = c.String(maxLength: 1),
                        PatientManagement = c.String(maxLength: 1),
                        Pathology = c.String(maxLength: 1),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.HospitalInformations", t => t.HospitalId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.APP_CONFIGURATION",
                c => new
                    {
                        AC_ID = c.Int(nullable: false),
                        AC_ITEM = c.String(nullable: false, maxLength: 200),
                        AC_VALUE = c.String(maxLength: 400),
                        AC_CAPTION = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.AC_ID, t.AC_ITEM });
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BA_Id = c.Int(nullable: false, identity: true),
                        BA_CODE = c.String(nullable: false, maxLength: 50),
                        BA_ACCOUNT_NAME = c.String(nullable: false, maxLength: 100),
                        BA_ACCOUNT_TYPE = c.String(maxLength: 20),
                        BA_ACCOUNT_GL_CODE = c.String(maxLength: 50),
                        BA_BANK_NAME = c.String(maxLength: 150),
                        BA_BANK_ADDRESS = c.String(maxLength: 500),
                        BA_STATUS = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.BA_Id);
            
            CreateTable(
                "dbo.BankTransactions",
                c => new
                    {
                        BTR_ID = c.Int(nullable: false, identity: true),
                        BTR_BA_ID = c.Int(nullable: false),
                        BTR_BA_CODE = c.String(maxLength: 100),
                        BTR_BA_ACCOUNT_NAME = c.String(maxLength: 100),
                        BTR_TXN_NO = c.String(maxLength: 50),
                        BTR_PAY_TYPE = c.String(maxLength: 2),
                        BTR_AMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BTR_TRANS_DATE = c.DateTime(nullable: false),
                        BTR_NARATION = c.String(maxLength: 250),
                        BTR_REC_STATUS = c.String(maxLength: 1),
                        BTR_REC_USER = c.String(maxLength: 50),
                        BTR_REC_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BTR_ID);
            
            CreateTable(
                "dbo.DailyExpenses",
                c => new
                    {
                        DeId = c.Int(nullable: false, identity: true),
                        VoucherNo = c.String(nullable: false, maxLength: 50),
                        TxnNo = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaId = c.String(),
                        Purpose = c.String(),
                        RecievedBy = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DeId);
            
            CreateTable(
                "dbo.DrugDailyStockHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugStockInId = c.Int(),
                        DrugId = c.Int(),
                        DisbusQty = c.Decimal(precision: 18, scale: 2),
                        RemQty = c.Decimal(precision: 18, scale: 2),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId)
                .ForeignKey("dbo.DrugStockIns", t => t.DrugStockInId)
                .Index(t => t.DrugStockInId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.DrugStockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TxnNo = c.String(maxLength: 50),
                        LotId = c.String(nullable: false, maxLength: 50),
                        DRUG_MANUFACTURERId = c.Int(nullable: false),
                        InvNo = c.String(nullable: false, maxLength: 50),
                        DpoId = c.String(maxLength: 50),
                        InvAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvDate = c.DateTime(nullable: false),
                        RecordDate = c.DateTime(),
                        PaymentStatus = c.String(nullable: false, maxLength: 20),
                        RecStatus = c.String(maxLength: 1),
                        SetUpUser = c.String(maxLength: 50),
                        SetUpDate = c.DateTime(),
                        DRUG_MANUFACTURER_DM_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG_MANUFACTURER", t => t.DRUG_MANUFACTURER_DM_ID)
                .Index(t => t.DRUG_MANUFACTURER_DM_ID);
            
            CreateTable(
                "dbo.DrugStockDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugStockInId = c.Int(nullable: false),
                        DRUGId = c.Int(),
                        MafDate = c.DateTime(),
                        ExpDate = c.DateTime(),
                        CostPrice = c.Decimal(precision: 18, scale: 2),
                        CostTotalPrice = c.Decimal(precision: 18, scale: 2),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        StockQuantity = c.Int(),
                        AvailableQuantity = c.Int(),
                        DisturbedQuantity = c.Int(),
                        RemainingQuantity = c.Int(),
                        DiscountPercent = c.Int(),
                        DRUG_D_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DRUG_D_ID)
                .ForeignKey("dbo.DrugStockIns", t => t.DrugStockInId)
                .Index(t => t.DrugStockInId)
                .Index(t => t.DRUG_D_ID);
            
            CreateTable(
                "dbo.DrugDoseCharts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugId = c.Int(nullable: false),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        Dose = c.String(),
                        Duration = c.String(),
                        Advice = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.DrugGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrugInvoicePayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LotId = c.String(maxLength: 50),
                        TxnId = c.String(maxLength: 50),
                        TxmDate = c.DateTime(),
                        PaymentAmount = c.Decimal(precision: 18, scale: 2),
                        RemAmount = c.Decimal(precision: 18, scale: 2),
                        PayType = c.String(maxLength: 10),
                        ChequeNo = c.String(maxLength: 50),
                        ChequeDate = c.DateTime(),
                        BankAccount = c.String(maxLength: 50),
                        ReceiveBy = c.String(maxLength: 80),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrugSaleReturns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(nullable: false, maxLength: 50),
                        LotNo = c.String(nullable: false, maxLength: 50),
                        DrugId = c.Int(nullable: false),
                        ReturnPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnSubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnDate = c.DateTime(nullable: false),
                        TxnNo = c.String(nullable: false, maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.DrugsSelectedGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DrugId = c.Int(nullable: false),
                        DrugGroupId = c.String(maxLength: 128),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.DrugGroups", t => t.DrugGroupId)
                .Index(t => t.DrugId)
                .Index(t => t.DrugGroupId);
            
            CreateTable(
                "dbo.GL_ACCOUNT",
                c => new
                    {
                        GL_ID = c.String(nullable: false, maxLength: 128),
                        GL_CODE = c.String(maxLength: 50),
                        GL_NAME = c.String(maxLength: 100),
                        GL_MAP_CODE = c.String(maxLength: 50),
                        GL_PARENT_ID = c.String(maxLength: 50),
                        GL_LEVEL = c.String(maxLength: 50),
                        GL_CATEGORY = c.String(maxLength: 50),
                        GL_HEAD_TYPE = c.String(maxLength: 1),
                        GL_SWITCHABLE_PARENT_ID = c.String(maxLength: 50),
                        GL_CURRENCY = c.String(maxLength: 3),
                        GL_TRANSACTION_SCOPE = c.String(maxLength: 2),
                        GL_TRANSACTION_STATUS = c.String(maxLength: 1),
                        GL_DIRECT_POSTING = c.String(maxLength: 1),
                        GL_VERIFY_USER = c.String(maxLength: 50),
                        GL_VERIFY_DATE_TIME = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GL_ID);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        NoDay = c.Int(nullable: false),
                        StartDaY = c.DateTime(nullable: false),
                        EndDaY = c.DateTime(nullable: false),
                        Notes = c.String(maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveOfAbsenceDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LeaveTypeId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        LeaveOfAbsenceMasterId = c.String(maxLength: 128),
                        TotalHours = c.Int(nullable: false),
                        LeaveYear = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveOfAbsenceMasters", t => t.LeaveOfAbsenceMasterId)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.LeaveOfAbsenceMasterId);
            
            CreateTable(
                "dbo.LeaveOfAbsenceMasters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LeaveReason = c.String(maxLength: 50),
                        EmployeeInfoId = c.String(maxLength: 128),
                        RequestedDate = c.DateTime(),
                        Note = c.String(),
                        CoveringUserId = c.String(),
                        VarifyUserId = c.String(),
                        Status = c.String(maxLength: 1),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeInfoId)
                .Index(t => t.EmployeeInfoId);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(maxLength: 50),
                        Abbreviation = c.String(maxLength: 50),
                        Color = c.String(maxLength: 50),
                        HolidayConcurrent = c.String(maxLength: 1),
                        Bank = c.String(maxLength: 1),
                        IsPaid = c.String(maxLength: 1),
                        IsAdvance = c.String(maxLength: 1),
                        RecStatus = c.String(maxLength: 1),
                        SetupUser = c.String(maxLength: 50),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeavePlanRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveTypeId = c.Int(nullable: false),
                        LeavePlanId = c.String(nullable: false, maxLength: 128),
                        StartMonth = c.Int(nullable: false),
                        EndMonth = c.Int(nullable: false),
                        TimeDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeavePlans", t => t.LeavePlanId, cascadeDelete: true)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.LeavePlanId);
            
            CreateTable(
                "dbo.LeavePlans",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 250),
                        IsYearSeniority = c.String(maxLength: 1),
                        RecStatus = c.String(maxLength: 1),
                        SetupUser = c.String(maxLength: 50),
                        SetupDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.loanConfigPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanConfigId = c.Int(nullable: false),
                        StartAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NnumberOfInstalment = c.Int(nullable: false),
                        IterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoanConfigs", t => t.LoanConfigId)
                .Index(t => t.LoanConfigId);
            
            CreateTable(
                "dbo.LoanConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        LoanTitle = c.String(maxLength: 100),
                        Note = c.String(maxLength: 100),
                        IsbasedOnSalary = c.Boolean(nullable: false),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Occurrences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EiCode = c.String(maxLength: 20),
                        OccurrenceTypeId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        ExpireDate = c.DateTime(),
                        Note = c.String(maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OccurrenceTypes", t => t.OccurrenceTypeId)
                .Index(t => t.OccurrenceTypeId);
            
            CreateTable(
                "dbo.OccurrenceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Note = c.String(maxLength: 100),
                        Abbreviation = c.String(maxLength: 50),
                        Status = c.String(maxLength: 1),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SupplierPayments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        SI_CODE = c.String(nullable: false, maxLength: 20),
                        InvoiceNo = c.String(maxLength: 50),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpenDate = c.DateTime(),
                        CheckNumber = c.String(maxLength: 50),
                        CheckDate = c.DateTime(),
                        TransNo = c.String(maxLength: 30),
                        TransDate = c.DateTime(),
                        TransType = c.String(maxLength: 2),
                        ReceivedBy = c.String(maxLength: 100),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SI_CODE, cascadeDelete: true)
                .Index(t => t.SI_CODE);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SI_CODE = c.String(nullable: false, maxLength: 20),
                        SI_NAME = c.String(nullable: false, maxLength: 50),
                        SI_MAILING_ADDR = c.String(maxLength: 250),
                        SI_PERMANENT_ADDR = c.String(maxLength: 250),
                        SI_PHONE = c.String(maxLength: 50),
                        SI_FAX = c.String(maxLength: 50),
                        SI_EMAIL = c.String(nullable: false, maxLength: 50),
                        SI_WEBSITE = c.String(maxLength: 50),
                        SI_CONTACT_PERSON = c.String(maxLength: 50),
                        SI_CURRENCY = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.SI_CODE);
            
            CreateTable(
                "dbo.TaxConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartRange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndRange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        TransDefinationdCode = c.Int(nullable: false),
                        AmountLocal = c.Decimal(precision: 18, scale: 2),
                        AmountForex = c.Decimal(precision: 18, scale: 2),
                        RefType = c.String(maxLength: 1),
                        Date = c.DateTime(),
                        Narration = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransDefinations", t => t.TransDefinationdCode, cascadeDelete: true)
                .Index(t => t.TransDefinationdCode);
            
            CreateTable(
                "dbo.TransDefinations",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Defination = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionRecords", "TransDefinationdCode", "dbo.TransDefinations");
            DropForeignKey("dbo.SupplierPayments", "SI_CODE", "dbo.Suppliers");
            DropForeignKey("dbo.Occurrences", "OccurrenceTypeId", "dbo.OccurrenceTypes");
            DropForeignKey("dbo.loanConfigPlans", "LoanConfigId", "dbo.LoanConfigs");
            DropForeignKey("dbo.LeaveOfAbsenceDetails", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeavePlanRates", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeavePlanRates", "LeavePlanId", "dbo.LeavePlans");
            DropForeignKey("dbo.LeaveOfAbsenceDetails", "LeaveOfAbsenceMasterId", "dbo.LeaveOfAbsenceMasters");
            DropForeignKey("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.DrugsSelectedGroups", "DrugGroupId", "dbo.DrugGroups");
            DropForeignKey("dbo.DrugsSelectedGroups", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.DrugSaleReturns", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.DrugDoseCharts", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.DrugDailyStockHistories", "DrugStockInId", "dbo.DrugStockIns");
            DropForeignKey("dbo.DrugStockDetails", "DrugStockInId", "dbo.DrugStockIns");
            DropForeignKey("dbo.DrugStockDetails", "DRUG_D_ID", "dbo.DRUG");
            DropForeignKey("dbo.DrugStockIns", "DRUG_MANUFACTURER_DM_ID", "dbo.DRUG_MANUFACTURER");
            DropForeignKey("dbo.DrugDailyStockHistories", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.EmployeeInfoes", "HospitalInformation_Id", "dbo.HospitalInformations");
            DropForeignKey("dbo.AppUsers", "HospitalId", "dbo.HospitalInformations");
            DropForeignKey("dbo.AppUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppPatientManagementUsers", "HospitalId", "dbo.HospitalInformations");
            DropForeignKey("dbo.AppPatientManagementUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.PatientHistories", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.DoctorInformations", "HospitalId", "dbo.HospitalInformations");
            DropForeignKey("dbo.DoctorBusinessHours", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.DoctorBusinessHolidays", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.VisitDiscounts", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.VisitDiscounts", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.PatientOldInvestigations", "TestId", "dbo.Test_Name");
            DropForeignKey("dbo.PatientOldInvestigations", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.PatientHistories", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.ReportScanCopies", "PrescriptionId", "dbo.PatientPrescriptions");
            DropForeignKey("dbo.PatientTreatments", "PatientPrescriptionId", "dbo.PatientPrescriptions");
            DropForeignKey("dbo.PatientTreatments", "DrugDurationId", "dbo.DrugDurations");
            DropForeignKey("dbo.PatientTreatments", "DrugDoseId", "dbo.DrugDoses");
            DropForeignKey("dbo.DrugDoses", "DURG_PRESENTATION_TYPE_DPT_ID", "dbo.DURG_PRESENTATION_TYPE");
            DropForeignKey("dbo.DrugDoses", "DRUG_D_ID", "dbo.DRUG");
            DropForeignKey("dbo.PatientTreatments", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.PatientTreatments", "DoctorNoteId", "dbo.DoctorNotes");
            DropForeignKey("dbo.PatientSpecialNotes", "SpecialNoteId", "dbo.SpecialNotes");
            DropForeignKey("dbo.PatientSpecialNotes", "PatientPrescriptionId", "dbo.PatientPrescriptions");
            DropForeignKey("dbo.PatientInvestigations", "TestId", "dbo.Test_Name");
            DropForeignKey("dbo.PatientInvestigations", "PatientPrescriptionId", "dbo.PatientPrescriptions");
            DropForeignKey("dbo.PatientPrescriptions", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.PatientPrescriptions", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.OperationNotes", "PrescriptionId", "dbo.PatientPrescriptions");
            DropForeignKey("dbo.OperationNotes", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.PatientPrescriptions", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.PatientPersonalHistories", "SocialEconomicStatusId", "dbo.SocialEconomicStatus");
            DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalHistories");
            DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalAttributes");
            DropForeignKey("dbo.PatientPersonalHistories", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientPastHistoryOfMadications", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientPastHistoryOfMadications", "DurgPresentationTypeId", "dbo.DURG_PRESENTATION_TYPE");
            DropForeignKey("dbo.PatientPastHistoryOfMadications", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.PatientGeneralExams", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientFamilyDiseases", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientFamilyDiseases", "FamilyTreeId", "dbo.FamilyTrees");
            DropForeignKey("dbo.PatientPastIllnesses", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientPastIllnesses", "DiseaseConditionId", "dbo.DiseaseConditions");
            DropForeignKey("dbo.PatientPastIllnesses", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.PatientFamilyDiseases", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.PatientChiefComplaints", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientChiefComplaints", "ChiefComplaintDetailsId", "dbo.ChiefComplaintDurations");
            DropForeignKey("dbo.PatientChiefComplaints", "ChiefComplaintId", "dbo.ChiefComplaints");
            DropForeignKey("dbo.PatientAllergyInformations", "PatientHistoryId", "dbo.PatientHistories");
            DropForeignKey("dbo.PatientEnrolls", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.PatientEnrolls", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.DoctorAppointmentPayments", "PatientEnrollId", "dbo.PatientEnrolls");
            DropForeignKey("dbo.MsAmountPurposes", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.DoctorAppointmentPayments", "MsAmountPurposeId", "dbo.MsAmountPurposes");
            DropForeignKey("dbo.PatientDetails", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.PatientDetails", "TestNameId", "dbo.Test_Name");
            DropForeignKey("dbo.Test_Name", "T_TC_ID", "dbo.TEST_CATEGORY");
            DropForeignKey("dbo.PatientInformations", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.DrugSales", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.DrugSales", "DrugId", "dbo.DRUG");
            DropForeignKey("dbo.DRUG", "D_DPT_ID", "dbo.DURG_PRESENTATION_TYPE");
            DropForeignKey("dbo.DRUG", "D_DM_ID", "dbo.DRUG_MANUFACTURER");
            DropForeignKey("dbo.DoctorAppointments", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.DoctorAppointments", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.AppPatientManagementUsers", "DoctorId", "dbo.DoctorInformations");
            DropForeignKey("dbo.AppPatientManagementUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppMedicineCornerUsers", "HospitalId", "dbo.HospitalInformations");
            DropForeignKey("dbo.AppMedicineCornerUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.AppMedicineCornerUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppAppointmentSystemUsers", "HospitalId", "dbo.HospitalInformations");
            DropForeignKey("dbo.AppAppointmentSystemUsers", "EmployeeId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeDesignationId", "dbo.EmployeeDesignations");
            DropForeignKey("dbo.EmployeeInfoes", "DepartmentId", "dbo.DEPARTMENTs");
            DropForeignKey("dbo.AppAppointmentSystemUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PatientAllergyInformations", "AllergySubstanceId", "dbo.AllergySubstances");
            DropForeignKey("dbo.PatientAllergyInformations", "AllergyInformationId", "dbo.AllergyInformations");
            DropForeignKey("dbo.AllergySubstances", "AllergyInformationId", "dbo.AllergyInformations");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.TransactionRecords", new[] { "TransDefinationdCode" });
            DropIndex("dbo.SupplierPayments", new[] { "SI_CODE" });
            DropIndex("dbo.Occurrences", new[] { "OccurrenceTypeId" });
            DropIndex("dbo.loanConfigPlans", new[] { "LoanConfigId" });
            DropIndex("dbo.LeavePlanRates", new[] { "LeavePlanId" });
            DropIndex("dbo.LeavePlanRates", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveOfAbsenceMasters", new[] { "EmployeeInfoId" });
            DropIndex("dbo.LeaveOfAbsenceDetails", new[] { "LeaveOfAbsenceMasterId" });
            DropIndex("dbo.LeaveOfAbsenceDetails", new[] { "LeaveTypeId" });
            DropIndex("dbo.DrugsSelectedGroups", new[] { "DrugGroupId" });
            DropIndex("dbo.DrugsSelectedGroups", new[] { "DrugId" });
            DropIndex("dbo.DrugSaleReturns", new[] { "DrugId" });
            DropIndex("dbo.DrugDoseCharts", new[] { "DrugId" });
            DropIndex("dbo.DrugStockDetails", new[] { "DRUG_D_ID" });
            DropIndex("dbo.DrugStockDetails", new[] { "DrugStockInId" });
            DropIndex("dbo.DrugStockIns", new[] { "DRUG_MANUFACTURER_DM_ID" });
            DropIndex("dbo.DrugDailyStockHistories", new[] { "DrugId" });
            DropIndex("dbo.DrugDailyStockHistories", new[] { "DrugStockInId" });
            DropIndex("dbo.AppUsers", new[] { "HospitalId" });
            DropIndex("dbo.AppUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.DoctorBusinessHours", new[] { "DoctorId" });
            DropIndex("dbo.DoctorBusinessHolidays", new[] { "DoctorId" });
            DropIndex("dbo.VisitDiscounts", new[] { "DoctorId" });
            DropIndex("dbo.VisitDiscounts", new[] { "PatientId" });
            DropIndex("dbo.PatientOldInvestigations", new[] { "TestId" });
            DropIndex("dbo.PatientOldInvestigations", new[] { "PatientId" });
            DropIndex("dbo.ReportScanCopies", new[] { "PrescriptionId" });
            DropIndex("dbo.DrugDoses", new[] { "DURG_PRESENTATION_TYPE_DPT_ID" });
            DropIndex("dbo.DrugDoses", new[] { "DRUG_D_ID" });
            DropIndex("dbo.PatientTreatments", new[] { "DoctorNoteId" });
            DropIndex("dbo.PatientTreatments", new[] { "DrugDurationId" });
            DropIndex("dbo.PatientTreatments", new[] { "DrugDoseId" });
            DropIndex("dbo.PatientTreatments", new[] { "DrugId" });
            DropIndex("dbo.PatientTreatments", new[] { "PatientPrescriptionId" });
            DropIndex("dbo.PatientSpecialNotes", new[] { "SpecialNoteId" });
            DropIndex("dbo.PatientSpecialNotes", new[] { "PatientPrescriptionId" });
            DropIndex("dbo.PatientInvestigations", new[] { "TestId" });
            DropIndex("dbo.PatientInvestigations", new[] { "PatientPrescriptionId" });
            DropIndex("dbo.OperationNotes", new[] { "DoctorId" });
            DropIndex("dbo.OperationNotes", new[] { "PrescriptionId" });
            DropIndex("dbo.PatientPrescriptions", new[] { "DoctorId" });
            DropIndex("dbo.PatientPrescriptions", new[] { "PatientId" });
            DropIndex("dbo.PatientPrescriptions", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientPersonalHistoryDetails", new[] { "PatientPersonalAttributeId" });
            DropIndex("dbo.PatientPersonalHistoryDetails", new[] { "PatientPersonalHistoryId" });
            DropIndex("dbo.PatientPersonalHistories", new[] { "SocialEconomicStatusId" });
            DropIndex("dbo.PatientPersonalHistories", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientPastHistoryOfMadications", new[] { "DrugId" });
            DropIndex("dbo.PatientPastHistoryOfMadications", new[] { "DurgPresentationTypeId" });
            DropIndex("dbo.PatientPastHistoryOfMadications", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientGeneralExams", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientPastIllnesses", new[] { "DiseaseConditionId" });
            DropIndex("dbo.PatientPastIllnesses", new[] { "DiseaseId" });
            DropIndex("dbo.PatientPastIllnesses", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientFamilyDiseases", new[] { "FamilyTreeId" });
            DropIndex("dbo.PatientFamilyDiseases", new[] { "DiseaseId" });
            DropIndex("dbo.PatientFamilyDiseases", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientChiefComplaints", new[] { "ChiefComplaintDetailsId" });
            DropIndex("dbo.PatientChiefComplaints", new[] { "ChiefComplaintId" });
            DropIndex("dbo.PatientChiefComplaints", new[] { "PatientHistoryId" });
            DropIndex("dbo.PatientHistories", new[] { "DoctorId" });
            DropIndex("dbo.PatientHistories", new[] { "PatientId" });
            DropIndex("dbo.MsAmountPurposes", new[] { "DoctorId" });
            DropIndex("dbo.DoctorAppointmentPayments", new[] { "MsAmountPurposeId" });
            DropIndex("dbo.DoctorAppointmentPayments", new[] { "PatientEnrollId" });
            DropIndex("dbo.PatientEnrolls", new[] { "DoctorId" });
            DropIndex("dbo.PatientEnrolls", new[] { "PatientId" });
            DropIndex("dbo.Test_Name", new[] { "T_TC_ID" });
            DropIndex("dbo.PatientDetails", new[] { "TestNameId" });
            DropIndex("dbo.PatientDetails", new[] { "PatientId" });
            DropIndex("dbo.DRUG", new[] { "D_DPT_ID" });
            DropIndex("dbo.DRUG", new[] { "D_DM_ID" });
            DropIndex("dbo.DrugSales", new[] { "DrugId" });
            DropIndex("dbo.DrugSales", new[] { "PatientId" });
            DropIndex("dbo.PatientInformations", new[] { "EducationId" });
            DropIndex("dbo.PatientInformations", new[] { "OccupationId" });
            DropIndex("dbo.DoctorAppointments", new[] { "PatientId" });
            DropIndex("dbo.DoctorAppointments", new[] { "DoctorId" });
            DropIndex("dbo.DoctorInformations", new[] { "HospitalId" });
            DropIndex("dbo.AppPatientManagementUsers", new[] { "EmployeeId" });
            DropIndex("dbo.AppPatientManagementUsers", new[] { "DoctorId" });
            DropIndex("dbo.AppPatientManagementUsers", new[] { "HospitalId" });
            DropIndex("dbo.AppPatientManagementUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.AppMedicineCornerUsers", new[] { "EmployeeId" });
            DropIndex("dbo.AppMedicineCornerUsers", new[] { "HospitalId" });
            DropIndex("dbo.AppMedicineCornerUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "HospitalInformation_Id" });
            DropIndex("dbo.EmployeeInfoes", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeDesignationId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AppAppointmentSystemUsers", new[] { "EmployeeId" });
            DropIndex("dbo.AppAppointmentSystemUsers", new[] { "HospitalId" });
            DropIndex("dbo.AppAppointmentSystemUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.PatientAllergyInformations", new[] { "AllergySubstanceId" });
            DropIndex("dbo.PatientAllergyInformations", new[] { "AllergyInformationId" });
            DropIndex("dbo.PatientAllergyInformations", new[] { "PatientHistoryId" });
            DropIndex("dbo.AllergySubstances", new[] { "AllergyInformationId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TransDefinations");
            DropTable("dbo.TransactionRecords");
            DropTable("dbo.TaxConfigurations");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierPayments");
            DropTable("dbo.OccurrenceTypes");
            DropTable("dbo.Occurrences");
            DropTable("dbo.LoanConfigs");
            DropTable("dbo.loanConfigPlans");
            DropTable("dbo.LeavePlans");
            DropTable("dbo.LeavePlanRates");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.LeaveOfAbsenceMasters");
            DropTable("dbo.LeaveOfAbsenceDetails");
            DropTable("dbo.Holidays");
            DropTable("dbo.GL_ACCOUNT");
            DropTable("dbo.DrugsSelectedGroups");
            DropTable("dbo.DrugSaleReturns");
            DropTable("dbo.DrugInvoicePayments");
            DropTable("dbo.DrugGroups");
            DropTable("dbo.DrugDoseCharts");
            DropTable("dbo.DrugStockDetails");
            DropTable("dbo.DrugStockIns");
            DropTable("dbo.DrugDailyStockHistories");
            DropTable("dbo.DailyExpenses");
            DropTable("dbo.BankTransactions");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.APP_CONFIGURATION");
            DropTable("dbo.AppUsers");
            DropTable("dbo.DoctorBusinessHours");
            DropTable("dbo.DoctorBusinessHolidays");
            DropTable("dbo.VisitDiscounts");
            DropTable("dbo.PatientOldInvestigations");
            DropTable("dbo.ReportScanCopies");
            DropTable("dbo.DrugDurations");
            DropTable("dbo.DrugDoses");
            DropTable("dbo.DoctorNotes");
            DropTable("dbo.PatientTreatments");
            DropTable("dbo.SpecialNotes");
            DropTable("dbo.PatientSpecialNotes");
            DropTable("dbo.PatientInvestigations");
            DropTable("dbo.OperationNotes");
            DropTable("dbo.PatientPrescriptions");
            DropTable("dbo.SocialEconomicStatus");
            DropTable("dbo.PatientPersonalAttributes");
            DropTable("dbo.PatientPersonalHistoryDetails");
            DropTable("dbo.PatientPersonalHistories");
            DropTable("dbo.PatientPastHistoryOfMadications");
            DropTable("dbo.PatientGeneralExams");
            DropTable("dbo.FamilyTrees");
            DropTable("dbo.DiseaseConditions");
            DropTable("dbo.PatientPastIllnesses");
            DropTable("dbo.Diseases");
            DropTable("dbo.PatientFamilyDiseases");
            DropTable("dbo.ChiefComplaintDurations");
            DropTable("dbo.ChiefComplaints");
            DropTable("dbo.PatientChiefComplaints");
            DropTable("dbo.PatientHistories");
            DropTable("dbo.MsAmountPurposes");
            DropTable("dbo.DoctorAppointmentPayments");
            DropTable("dbo.PatientEnrolls");
            DropTable("dbo.TEST_CATEGORY");
            DropTable("dbo.Test_Name");
            DropTable("dbo.PatientDetails");
            DropTable("dbo.Occupations");
            DropTable("dbo.Educations");
            DropTable("dbo.DURG_PRESENTATION_TYPE");
            DropTable("dbo.DRUG_MANUFACTURER");
            DropTable("dbo.DRUG");
            DropTable("dbo.DrugSales");
            DropTable("dbo.PatientInformations");
            DropTable("dbo.DoctorAppointments");
            DropTable("dbo.DoctorInformations");
            DropTable("dbo.AppPatientManagementUsers");
            DropTable("dbo.AppMedicineCornerUsers");
            DropTable("dbo.HospitalInformations");
            DropTable("dbo.EmployeeDesignations");
            DropTable("dbo.DEPARTMENTs");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AppAppointmentSystemUsers");
            DropTable("dbo.PatientAllergyInformations");
            DropTable("dbo.AllergySubstances");
            DropTable("dbo.AllergyInformations");
        }
    }
}
