namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddd : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalHistories");
            //DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalAttributes");
            //RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalAttributeId", newName: "__mig_tmp__0");
            //RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalHistoryId", newName: "PatientPersonalAttributeId");
            //RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "PatientPersonalHistoryId");
            //RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalAttributeId", newName: "__mig_tmp__0");
            //RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalHistoryId", newName: "IX_PatientPersonalAttributeId");
            //RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "IX_PatientPersonalHistoryId");
            //AddColumn("dbo.CBCTests", "PatientCode", c => c.String(maxLength: 100));
            //AddColumn("dbo.CBCTests", "ReferanceName", c => c.String(maxLength: 50));
            //AddColumn("dbo.RETests", "PatientCode", c => c.String(maxLength: 100));
            //AddColumn("dbo.RETests", "ReferanceName", c => c.String(maxLength: 50));
            //AddColumn("dbo.SRETests", "PatientCode", c => c.String(maxLength: 100));
            //AddColumn("dbo.SRETests", "ReferanceName", c => c.String(maxLength: 50));
            //AlterColumn("dbo.PatientInformations", "PatientCode", c => c.String(maxLength: 100));
            //AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalHistories", "Id");
            //AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalAttributes", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalAttributes");
            //DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalHistories");
            //AlterColumn("dbo.PatientInformations", "PatientCode", c => c.String(nullable: false, maxLength: 100));
            //DropColumn("dbo.SRETests", "ReferanceName");
            //DropColumn("dbo.SRETests", "PatientCode");
            //DropColumn("dbo.RETests", "ReferanceName");
            //DropColumn("dbo.RETests", "PatientCode");
            //DropColumn("dbo.CBCTests", "ReferanceName");
            //DropColumn("dbo.CBCTests", "PatientCode");
            //RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalHistoryId", newName: "__mig_tmp__0");
            //RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalAttributeId", newName: "IX_PatientPersonalHistoryId");
            //RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "IX_PatientPersonalAttributeId");
            //RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalHistoryId", newName: "__mig_tmp__0");
            //RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalAttributeId", newName: "PatientPersonalHistoryId");
            //RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "PatientPersonalAttributeId");
            //AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalAttributes", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalHistories", "Id", cascadeDelete: true);
        }
    }
}
