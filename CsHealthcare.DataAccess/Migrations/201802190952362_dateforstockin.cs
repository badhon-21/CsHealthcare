namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateforstockin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockInDetails", "MafDate", c => c.DateTime());
            AddColumn("dbo.StockInDetails", "ExpDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockInDetails", "ExpDate");
            DropColumn("dbo.StockInDetails", "MafDate");
        }
    }
}
