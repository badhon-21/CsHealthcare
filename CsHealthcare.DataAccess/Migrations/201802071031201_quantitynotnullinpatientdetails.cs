namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantitynotnullinpatientdetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int(nullable: false));
        }
    }
}
