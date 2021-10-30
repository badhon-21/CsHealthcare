namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LoanConfigs", "IsbasedOnSalary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanConfigs", "IsbasedOnSalary", c => c.String(maxLength: 1));
        }
    }
}
