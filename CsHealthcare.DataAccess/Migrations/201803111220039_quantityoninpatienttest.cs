namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantityoninpatienttest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientTestdetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientTestdetails", "Quantity");
        }
    }
}
