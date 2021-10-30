namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upcanteenPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CanteenFoodInPatients", "SellsNo", c => c.String());
            AddColumn("dbo.CanteenFoodInPatients", "SellsDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CanteenFoodInPatients", "SaleDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CanteenFoodInPatients", "SaleDateTime", c => c.DateTime());
            DropColumn("dbo.CanteenFoodInPatients", "SellsDate");
            DropColumn("dbo.CanteenFoodInPatients", "SellsNo");
        }
    }
}
