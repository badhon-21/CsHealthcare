using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;
using CsHealthcare.ViewModel.Patient;

namespace CsHealthcare.Report
{
    public class PatientInformationSummary
    {
        public int Id { get; set; }

        public int VisitNo { get; set; }

        public DateTime PrescriptionDate { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string BloodGroup { get; set; }

        public string Sex { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string Occupation { get; set; }
    }

    public partial class rvPrescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                RenderReport(Id);
            }
        }

        private void RenderReport(int Id)
        {
            Modelfactory modelFactory = new Modelfactory();
            AppServices appServices = new AppServices();
            var patientPrescription = modelFactory.Create(appServices.PatientPrescriptionRepository.GetData(gd => gd.Id == Id).FirstOrDefault());

            var patientInformation = appServices.PatientInformationRepository.GetData(gd=>gd.Id==patientPrescription.PatientId).FirstOrDefault();

            PatientInformationSummary patientInformationSummary = new PatientInformationSummary();
            patientInformationSummary.Id = patientInformation.Id;
            patientInformationSummary.VisitNo = appServices.PatientPrescriptionRepository.GetData(gd=>gd.PatientId== patientPrescription.PatientId && gd.DoctorId== patientPrescription.DoctorId).ToList().Count;
            patientInformationSummary.PrescriptionDate = patientPrescription.Date;
            patientInformationSummary.Name = patientInformation.Name;
            patientInformationSummary.DateOfBirth = patientInformation.DateOfBirth;
            patientInformationSummary.Age = Convert.ToInt16(Math.Ceiling(((DateTime.Now - patientInformation.DateOfBirth).TotalDays / 365)));
            patientInformationSummary.BloodGroup = patientInformation.BloodGroup;
            patientInformationSummary.Sex = patientInformation.Sex;
            if (patientInformation.Occupation != null)
                patientInformationSummary.Occupation = patientInformation.Occupation.Name??"";
            patientInformationSummary.Address = patientInformation.Address;
            patientInformationSummary.ContactNumber = patientInformation.MobileNumber;
            List<PatientInformationSummary> listPatientInformationSummary = new List<PatientInformationSummary>();
            listPatientInformationSummary.Add(patientInformationSummary);

            var patientHistory =
                modelFactory.Create(
                    appServices.PatientHistoryRepository.GetData(gd => gd.Id == patientPrescription.PatientHistoryId)
                        .FirstOrDefault());

            List<PatientInvestigationModel> previousInvestigationModels = new List<PatientInvestigationModel>();
            #region "Previous Investigation"

            int previousPrescriptionId = 0;
            var prescriptionList = (appServices.PatientPrescriptionRepository.GetData(gd => gd.PatientId == patientPrescription.PatientId).ToList().OrderByDescending(ob => ob.Date).ToList());
            if (prescriptionList.Count > 1)
            {
                int i = 0;
                int currentPrescriptionIndex = 0;
                foreach (var VARIABLE in prescriptionList)
                {
                    if (VARIABLE.Id == patientPrescription.Id)
                    {
                        currentPrescriptionIndex = i;
                    }
                    i++;
                }
                if (prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().Count > 0)
                    previousPrescriptionId = prescriptionList.Skip(currentPrescriptionIndex + 1).ToList().FirstOrDefault().Id;
                previousInvestigationModels = appServices.PatientInvestigationRepository.GetData(gd => gd.PatientPrescriptionId ==
                                                                             previousPrescriptionId).Select(modelFactory.Create).ToList();
            }

            #endregion


            var specialNote =patientPrescription.PatientSpecialNote.ToList();
            var treatment = patientPrescription.PatientTreatment.ToList();
            var todaysInvestigation = patientPrescription.PatientInvestigation.ToList();
            var chiefComplaint = patientHistory.PatientChiefComplaint.ToList();

            List<PatientPrescriptionModel> listPatientPrescription = new List<PatientPrescriptionModel>();
            listPatientPrescription.Add(patientPrescription);

            
            appReportViewer.Reset();
            appReportViewer.LocalReport.ReportPath = "Report/rptPrescription.rdlc";
            appReportViewer.LocalReport.DataSources.Clear();

            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPrescription", listPatientPrescription));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsGeneralExaml", patientHistory.PatientGeneralExam));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPatientInformation", listPatientInformationSummary));

            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPatientPersonalHistory", patientHistory.PatientPersonalHistory));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPersonalHistoryDetails", patientHistory.PatientPersonalHistory.First().PatientPersonalHistoryDetails));


            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsSpecialNote", specialNote));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsChiefComplaint", chiefComplaint));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsTreatment", treatment));

            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPreviousInvestigation", previousInvestigationModels));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsTodaysInvestigation", todaysInvestigation));
            appReportViewer.LocalReport.Refresh();





            //appReportViewer.Reset();
            //appReportViewer.LocalReport.EnableExternalImages = true;
            //appReportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/rptPrescription.rdlc");

            //If you wan to add parameter yo your report you can add using below code
            //appReportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("",""));

            //appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPrescription", new Object()));

        }
    }
}