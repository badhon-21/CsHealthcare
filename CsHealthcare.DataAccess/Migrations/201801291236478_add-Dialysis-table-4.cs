namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDialysistable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientDialysis", "LastDialysisTakenDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDialysis", "LastDialysisTakenDate");
        }
    }
}
