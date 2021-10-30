namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepersonalhistorytable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalHistories");
            DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalAttributes");
            RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalAttributeId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalHistoryId", newName: "PatientPersonalAttributeId");
            RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "PatientPersonalHistoryId");
            RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalAttributeId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalHistoryId", newName: "IX_PatientPersonalAttributeId");
            RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "IX_PatientPersonalHistoryId");
            AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalHistories", "Id");
            AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalAttributes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalAttributes");
            DropForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalHistories");
            RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalHistoryId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "IX_PatientPersonalAttributeId", newName: "IX_PatientPersonalHistoryId");
            RenameIndex(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "IX_PatientPersonalAttributeId");
            RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalHistoryId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "PatientPersonalAttributeId", newName: "PatientPersonalHistoryId");
            RenameColumn(table: "dbo.PatientPersonalHistoryDetails", name: "__mig_tmp__0", newName: "PatientPersonalAttributeId");
            AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalHistoryId", "dbo.PatientPersonalAttributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientPersonalHistoryDetails", "PatientPersonalAttributeId", "dbo.PatientPersonalHistories", "Id", cascadeDelete: true);
        }
    }
}
