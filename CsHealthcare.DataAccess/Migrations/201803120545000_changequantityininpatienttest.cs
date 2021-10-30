namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changequantityininpatienttest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InPatientTestdetails", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InPatientTestdetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
