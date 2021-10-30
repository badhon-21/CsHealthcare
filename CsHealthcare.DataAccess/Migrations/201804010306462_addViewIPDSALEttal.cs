namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addViewIPDSALEttal : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_IPD_DRUG_SALE_TOTAL",
            //    c => new
            //        {
            //            VID = c.Guid(nullable: false),
            //            AdmissionNo = c.String(),
            //            PatientCode = c.String(),
            //            PatientName = c.String(),
            //            DrugSale = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            DrugReturn = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            TotalSale = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.VID);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.VW_IPD_DRUG_SALE_TOTAL");
        }
    }
}
