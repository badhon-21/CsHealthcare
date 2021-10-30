namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(),
                        PatientName = c.String(),
                        FatherName = c.String(maxLength: 100),
                        MotherName = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        BloodGroup = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        Sex = c.String(maxLength: 20),
                        OccupationId = c.Int(),
                        EducationId = c.Int(),
                        MobileNumber = c.String(maxLength: 20),
                        RegistrationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherNo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientCards");
        }
    }
}
