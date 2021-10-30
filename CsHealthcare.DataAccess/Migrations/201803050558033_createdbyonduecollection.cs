namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdbyonduecollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientDueCollections", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDueCollections", "CreatedBy");
        }
    }
}
