namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dscountondischarge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.InPatientDischarges", "DiscountReason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "DiscountReason");
            DropColumn("dbo.InPatientDischarges", "Discount");
        }
    }
}
