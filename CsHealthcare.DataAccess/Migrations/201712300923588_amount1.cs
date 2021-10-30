namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amount1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "CabinAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PatientAdmissions", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "TotalAmount");
            DropColumn("dbo.PatientAdmissions", "CabinAmount");
        }
    }
}
