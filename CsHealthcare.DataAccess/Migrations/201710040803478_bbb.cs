namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanConfigs", "IsbasedOnSalary", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanConfigs", "IsbasedOnSalary");
        }
    }
}
