namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantityupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientDetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
