namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailyCollection1 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "CollectionType", c => c.String());
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "collectedAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "AdmissionNo");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "PatientId");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "DrugId");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "DrugName");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "UnitPrice");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "Quantity");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "SubTotal");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "SaleDiscount");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "Total");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "SaleDateTime");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "SaleDateTime", c => c.DateTime(nullable: false));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "SaleDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "Quantity", c => c.Int(nullable: false));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "DrugName", c => c.String());
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "DrugId", c => c.String());
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "PatientId", c => c.String());
            //AddColumn("dbo.VW_DAILY_USER_COLLECTION", "AdmissionNo", c => c.String());
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "collectedAmount");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "TotalAmount");
            //DropColumn("dbo.VW_DAILY_USER_COLLECTION", "CollectionType");
        }
    }
}
