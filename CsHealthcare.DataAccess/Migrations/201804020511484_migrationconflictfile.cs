namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationconflictfile : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Patients", "Remark", c => c.String());
            //AlterColumn("dbo.CabinRents", "Duration", c => c.Int());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.CabinRents", "Duration", c => c.String(maxLength: 50));
            //DropColumn("dbo.Patients", "Remark");
        }
    }
}
