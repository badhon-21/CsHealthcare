namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelog01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationTheatres", "RecStatus", c => c.String());
            AddColumn("dbo.OperationTheatres", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.OperationTheatres", "ModifiedBy", c => c.String());
            AddColumn("dbo.OperationTheatres", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.OperationTheatres", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.CabinToCabinTransfers", "RecStatus", c => c.String());
            AddColumn("dbo.CabinToCabinTransfers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.CabinToCabinTransfers", "ModifiedBy", c => c.String());
            AddColumn("dbo.CabinToCabinTransfers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.CabinToCabinTransfers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.CabinTransferBacks", "RecStatus", c => c.String());
            AddColumn("dbo.CabinTransferBacks", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.CabinTransferBacks", "ModifiedBy", c => c.String());
            AddColumn("dbo.CabinTransferBacks", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.CabinTransferBacks", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.OptPatientBills", "RecStatus", c => c.String());
            AddColumn("dbo.OptPatientBills", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.OptPatientBills", "CreatedBy", c => c.String());
            AddColumn("dbo.OptPatientBills", "ModifiedBy", c => c.String());
            AddColumn("dbo.OptPatientBills", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.OptPatientBills", "ModifiedIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OptPatientBills", "ModifiedIpAddress");
            DropColumn("dbo.OptPatientBills", "CreatedIpAddress");
            DropColumn("dbo.OptPatientBills", "ModifiedBy");
            DropColumn("dbo.OptPatientBills", "CreatedBy");
            DropColumn("dbo.OptPatientBills", "ModifiedDate");
            DropColumn("dbo.OptPatientBills", "RecStatus");
            DropColumn("dbo.CabinTransferBacks", "ModifiedIpAddress");
            DropColumn("dbo.CabinTransferBacks", "CreatedIpAddress");
            DropColumn("dbo.CabinTransferBacks", "ModifiedBy");
            DropColumn("dbo.CabinTransferBacks", "ModifiedDate");
            DropColumn("dbo.CabinTransferBacks", "RecStatus");
            DropColumn("dbo.CabinToCabinTransfers", "ModifiedIpAddress");
            DropColumn("dbo.CabinToCabinTransfers", "CreatedIpAddress");
            DropColumn("dbo.CabinToCabinTransfers", "ModifiedBy");
            DropColumn("dbo.CabinToCabinTransfers", "ModifiedDate");
            DropColumn("dbo.CabinToCabinTransfers", "RecStatus");
            DropColumn("dbo.OperationTheatres", "ModifiedIpAddress");
            DropColumn("dbo.OperationTheatres", "CreatedIpAddress");
            DropColumn("dbo.OperationTheatres", "ModifiedBy");
            DropColumn("dbo.OperationTheatres", "ModifiedDate");
            DropColumn("dbo.OperationTheatres", "RecStatus");
        }
    }
}
