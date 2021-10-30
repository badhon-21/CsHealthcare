namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class packageonadmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientAdmissions", "PackageId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientAdmissions", "PackageId");
        }
    }
}
