namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "InPatientDoctorBills", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InPatientDischarges", "InPatientTotalTestBills", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "InPatientTotalTestBills");
            DropColumn("dbo.InPatientDischarges", "InPatientDoctorBills");
        }
    }
}
