namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LCs", "CurrencyTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.LCs", "CurrencyType", c => c.Int(nullable: false));
            AddColumn("dbo.LCs", "InvoiceCurrencyType", c => c.Int(nullable: false));
            AddColumn("dbo.LCs", "InvoiceCurrencyTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LCs", "InvoiceCurrencyTypeId");
            DropColumn("dbo.LCs", "InvoiceCurrencyType");
            DropColumn("dbo.LCs", "CurrencyType");
            DropColumn("dbo.LCs", "CurrencyTypeId");
        }
    }
}
