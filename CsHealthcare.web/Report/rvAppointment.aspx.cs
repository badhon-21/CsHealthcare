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
    public partial class rvAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string DoctorId = Request.QueryString["DoctorId"].ToString();
                //DateTime tDate = Convert.ToDateTime(Request.QueryString["tDate"].ToString());
               // RenderReport(DoctorId, tDate);

                DateTime fromDate = Convert.ToDateTime(Request.QueryString["fromDate"].ToString());
                DateTime toDate = Convert.ToDateTime(Request.QueryString["toDate"].ToString());
                RenderReport(DoctorId, fromDate, toDate);
            }
        }

        private void RenderReport(string DoctorId, DateTime fromDate, DateTime toDate)
        {
            AppServices appServices = new AppServices();

            var val = appServices.PatientEnrollRepository.GetData(gd => gd.DoctorId == DoctorId && gd.Date >= fromDate && gd.Date <= toDate)
                .Join(appServices.DoctorAppointmentPaymentRepository.Get().ToList(), pe => pe.Id, da => da.PatientEnrollId, (pe, da) => new
                {
                    pe.Date,
                    pe.PatientId,
                    pe.Time,
                    pe.Type,
                    da.VisitNo,
                    da.Amount,
                    da.Discount,
                    da.Reason,
                    da.MsAmountPurposeId
                }).ToList()
                .Join(appServices.MsAmountPurposeRepository.GetData(gd => gd.DoctorId == DoctorId).ToList(), su => su.MsAmountPurposeId, ap => ap.Id, (su, ap) => new
                {
                    su.Date,
                    su.PatientId,
                    su.Time,
                    su.Type,
                    su.VisitNo,
                    su.Amount,
                    su.Discount,
                    su.Reason,
                    su.MsAmountPurposeId,
                    ap.Description
                }).ToList()
                .Join(appServices.PatientInformationRepository.Get(), app => app.PatientId, pi => pi.Id, (app, pi) => new
                    AppointmentReportModel
                {
                    PatientId = app.PatientId,
                    Name = pi.Name,
                    Time = app.Date.ToShortDateString(),
                    VisitNo = app.VisitNo ?? 0,
                    Amount = (app.Amount + app.Discount) ?? 0,
                    Discount = app.Discount ?? 0,
                    Tax = 200,
                    NetAmount = ((app.Amount + app.Discount) - 200) ?? 0,
                    Total = app.Amount,
                    Reason = app.Reason,
                    Purpose = app.Description,
                }).ToList();

            appReportViewer.Reset();
            appReportViewer.LocalReport.ReportPath = "Report/rptAppointment.rdlc";
            appReportViewer.LocalReport.DataSources.Clear();
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsAppointment", val));

            appReportViewer.LocalReport.Refresh();

        }


    }

    public class AppointmentReportModel
    {
        public string Date { get; set; }
        public string Time { get; set; }

        public int PatientId { get; set; }

        public string Name { get; set; }

        public int VisitNo { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }

        public string Purpose { get; set; }

        public string Reason { get; set; }


    }
}