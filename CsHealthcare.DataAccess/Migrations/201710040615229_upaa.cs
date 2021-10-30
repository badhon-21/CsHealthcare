namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upaa : DbMigration
    {
        public override void Up()
        {
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.DrugGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.String(maxLength: 20),
                        Recstatus = c.String(maxLength: 1),
                        SetupUser = c.String(maxLength: 50),
                        SetupDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .ForeignKey("dbo.EmployeeDesignations", t => t.EmployeeDesignationId)
                .Index(t => t.EmployeeDesignationId)
                .Index(t => t.DepartmentId);
            
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
                        IsbasedOnSalary = c.String(maxLength: 1),
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
                "dbo.PatientDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        TestNameId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .ForeignKey("dbo.Test_Name", t => t.TestNameId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.TestNameId);
            
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
            DropForeignKey("dbo.SupplierPayments", "SI_CODE", "dbo.Suppliers");
            DropForeignKey("dbo.PatientDetails", "TestNameId", "dbo.Test_Name");
            DropForeignKey("dbo.Test_Name", "T_TC_ID", "dbo.TEST_CATEGORY");
            DropForeignKey("dbo.PatientDetails", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Occurrences", "OccurrenceTypeId", "dbo.OccurrenceTypes");
            DropForeignKey("dbo.loanConfigPlans", "LoanConfigId", "dbo.LoanConfigs");
            DropForeignKey("dbo.LeaveOfAbsenceDetails", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeavePlanRates", "LeaveTypeId", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeavePlanRates", "LeavePlanId", "dbo.LeavePlans");
            DropForeignKey("dbo.LeaveOfAbsenceDetails", "LeaveOfAbsenceMasterId", "dbo.LeaveOfAbsenceMasters");
            DropForeignKey("dbo.LeaveOfAbsenceMasters", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.EmployeeInfoes", "EmployeeDesignationId", "dbo.EmployeeDesignations");
            DropForeignKey("dbo.EmployeeInfoes", "DepartmentId", "dbo.DEPARTMENTs");
            DropForeignKey("dbo.DrugStockDetails", "DrugStockInId", "dbo.DrugStockIns");
            DropForeignKey("dbo.DrugStockIns", "DRUG_MANUFACTURER_DM_ID", "dbo.DRUG_MANUFACTURER");
            DropForeignKey("dbo.DrugStockDetails", "DRUG_D_ID", "dbo.DRUG");
            DropForeignKey("dbo.DrugDoses", "DURG_PRESENTATION_TYPE_DPT_ID", "dbo.DURG_PRESENTATION_TYPE");
            DropForeignKey("dbo.DrugDoses", "DRUG_D_ID", "dbo.DRUG");
            DropForeignKey("dbo.DRUG", "D_DPT_ID", "dbo.DURG_PRESENTATION_TYPE");
            DropForeignKey("dbo.DRUG", "D_DM_ID", "dbo.DRUG_MANUFACTURER");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.SupplierPayments", new[] { "SI_CODE" });
            DropIndex("dbo.Test_Name", new[] { "T_TC_ID" });
            DropIndex("dbo.PatientDetails", new[] { "TestNameId" });
            DropIndex("dbo.PatientDetails", new[] { "PatientId" });
            DropIndex("dbo.Occurrences", new[] { "OccurrenceTypeId" });
            DropIndex("dbo.loanConfigPlans", new[] { "LoanConfigId" });
            DropIndex("dbo.LeavePlanRates", new[] { "LeavePlanId" });
            DropIndex("dbo.LeavePlanRates", new[] { "LeaveTypeId" });
            DropIndex("dbo.LeaveOfAbsenceMasters", new[] { "EmployeeInfoId" });
            DropIndex("dbo.LeaveOfAbsenceDetails", new[] { "LeaveOfAbsenceMasterId" });
            DropIndex("dbo.LeaveOfAbsenceDetails", new[] { "LeaveTypeId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeDesignationId" });
            DropIndex("dbo.DrugStockIns", new[] { "DRUG_MANUFACTURER_DM_ID" });
            DropIndex("dbo.DrugStockDetails", new[] { "DRUG_D_ID" });
            DropIndex("dbo.DrugStockDetails", new[] { "DrugStockInId" });
            DropIndex("dbo.DRUG", new[] { "D_DPT_ID" });
            DropIndex("dbo.DRUG", new[] { "D_DM_ID" });
            DropIndex("dbo.DrugDoses", new[] { "DURG_PRESENTATION_TYPE_DPT_ID" });
            DropIndex("dbo.DrugDoses", new[] { "DRUG_D_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TaxConfigurations");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierPayments");
            DropTable("dbo.TEST_CATEGORY");
            DropTable("dbo.Test_Name");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientDetails");
            DropTable("dbo.OccurrenceTypes");
            DropTable("dbo.Occurrences");
            DropTable("dbo.LoanConfigs");
            DropTable("dbo.loanConfigPlans");
            DropTable("dbo.LeavePlans");
            DropTable("dbo.LeavePlanRates");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.LeaveOfAbsenceMasters");
            DropTable("dbo.LeaveOfAbsenceDetails");
            DropTable("dbo.GL_ACCOUNT");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.EmployeeDesignations");
            DropTable("dbo.DrugStockIns");
            DropTable("dbo.DrugStockDetails");
            DropTable("dbo.DrugGroups");
            DropTable("dbo.DURG_PRESENTATION_TYPE");
            DropTable("dbo.DRUG_MANUFACTURER");
            DropTable("dbo.DRUG");
            DropTable("dbo.DrugDoses");
            DropTable("dbo.DEPARTMENTs");
            DropTable("dbo.DailyExpenses");
            DropTable("dbo.BankTransactions");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.APP_CONFIGURATION");
        }
    }
}
