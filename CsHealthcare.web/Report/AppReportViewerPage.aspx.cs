using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CsHealthcare.DataAccess.Modelfactory;
using CsHealthcare.Services;

namespace CsHealthcare.Report
{
    public partial class AppReportViewerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                RenderReport();
            }
        }

        private void RenderReport()
        {

            AppServices appServices = new AppServices();
            var val = appServices.PatientPrescriptionRepository.GetData(gd=>gd.Id==2);

            Modelfactory modelFactory = new Modelfactory();

            var val1 = val.FirstOrDefault().PatientTreatments;
            var specialNote = val.FirstOrDefault().PatientSpecialNotes.ToList().Select(modelFactory.Create).ToList();
            appReportViewer.Reset();
            appReportViewer.LocalReport.ReportPath = "Report/prescription.rdlc";
            appReportViewer.LocalReport.DataSources.Clear();
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsSpecialNote", specialNote));

            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsPrescription", val));
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("treatment", val1));
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