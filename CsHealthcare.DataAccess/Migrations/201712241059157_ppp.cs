namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PharmacyRequisitions", "RequisitionNo", c => c.String(maxLength: 100));
            AddColumn("dbo.PharmacyRequisitions", "RequisitionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PharmacyRequisitions", "RequisitionDate");
            DropColumn("dbo.PharmacyRequisitions", "RequisitionNo");
        }
    }
}
