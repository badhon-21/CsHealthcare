namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Status", c => c.String(maxLength: 50));
            AddColumn("dbo.Patients", "TransactionType", c => c.String(maxLength: 100));
            AddColumn("dbo.Patients", "TransactionNumber", c => c.String(maxLength: 100));
            AddColumn("dbo.Patients", "GivenAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Patients", "ChangeAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ChangeAmount");
            DropColumn("dbo.Patients", "GivenAmount");
            DropColumn("dbo.Patients", "TransactionNumber");
            DropColumn("dbo.Patients", "TransactionType");
            DropColumn("dbo.Patients", "Status");
        }
    }
}
