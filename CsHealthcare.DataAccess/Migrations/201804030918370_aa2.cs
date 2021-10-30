namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa2 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "PatientId", c => c.Int(nullable: false));
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "DrugId", c => c.Int(nullable: false));
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.VW_IPD_DRUG_SALE_RETURN", "PatientId", c => c.Int(nullable: false));
            //AlterColumn("dbo.VW_IPD_DRUG_SALE_RETURN", "DrugId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.VW_IPD_DRUG_SALE_RETURN", "DrugId", c => c.String());
            //AlterColumn("dbo.VW_IPD_DRUG_SALE_RETURN", "PatientId", c => c.String());
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "Quantity", c => c.Int(nullable: false));
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "DrugId", c => c.String());
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "PatientId", c => c.String());
        }
    }
}
