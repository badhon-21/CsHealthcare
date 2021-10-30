namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vouchernoinpatientlaser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientLasers", "VoucherNo", c => c.String());
            AddColumn("dbo.PatientLasers", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientLasers", "CreatedBy");
            DropColumn("dbo.PatientLasers", "VoucherNo");
        }
    }
}
