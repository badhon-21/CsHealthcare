namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stocout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockOutItems", "MemoNo", c => c.String(maxLength: 50));
            AddColumn("dbo.StockOutItems", "TxnNo", c => c.String(maxLength: 50));
            AddColumn("dbo.StockOutItems", "LotId", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockOutItems", "LotId");
            DropColumn("dbo.StockOutItems", "TxnNo");
            DropColumn("dbo.StockOutItems", "MemoNo");
        }
    }
}
