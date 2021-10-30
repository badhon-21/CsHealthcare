namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugsaleremarks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugSales", "Remarks", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DrugSales", "Remarks");
        }
    }
}
