namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflictmigrationfile1 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.InPatientTests", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.InPatientTests", "Remark");
        }
    }
}
