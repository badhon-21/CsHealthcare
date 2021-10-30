<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rvAppointment.aspx.cs" Inherits="CsHealthcare.Report.rvAppointment" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form2" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer  CssClass="rptPrint" ID="appReportViewer" runat="server" Width="2480px" Height="3508px" ShowPrintButton="true"
            AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" BackColor="white"
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
