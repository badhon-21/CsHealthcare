namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conup : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.PatientDetails", "Quantity", c => c.Int());
        }
    }
}
