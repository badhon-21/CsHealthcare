namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remarkonpatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Remark");
        }
    }
}
