namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurposeOnOTs", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PurposeOnOTs", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurposeOnOTs", "SubTotal");
            DropColumn("dbo.PurposeOnOTs", "Quantity");
        }
    }
}
