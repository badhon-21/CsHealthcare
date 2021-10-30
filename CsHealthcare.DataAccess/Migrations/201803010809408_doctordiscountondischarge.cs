namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctordiscountondischarge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "DoctorDiscount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.InPatientDischarges", "NameOfDoctorOnDiscount", c => c.String());
            AddColumn("dbo.InPatientDischarges", "AdmissionFee", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "AdmissionFee");
            DropColumn("dbo.InPatientDischarges", "NameOfDoctorOnDiscount");
            DropColumn("dbo.InPatientDischarges", "DoctorDiscount");
        }
    }
}
