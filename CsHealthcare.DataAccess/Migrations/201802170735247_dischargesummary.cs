namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dischargesummary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDischargeSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(nullable: false, maxLength: 100),
                        PatientName = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        DischargeDate = c.DateTime(nullable: false),
                        AttendingPhysician = c.String(),
                        RefferingPhysician = c.String(),
                        ConsultingPhysician = c.String(),
                        ConditionOnDischarge = c.String(),
                        DischargeBy = c.String(),
                        FinalDiadiagnosis = c.String(),
                        OperationDate = c.DateTime(nullable: false),
                        OperationTime = c.DateTime(nullable: false),
                        NameOfOperation = c.String(),
                        NameOfAnesthesia = c.String(),
                        IndicationOfOperation = c.String(),
                        ClinicalFindings = c.String(),
                        BabyNote = c.String(),
                        TreatmentDuringHospital = c.String(),
                        Instruction = c.String(),
                        ConsultationDictician = c.String(),
                        ConsultineuningRx = c.String(),
                        FollowUp = c.String(),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InPatientDischargeSummaries");
        }
    }
}
