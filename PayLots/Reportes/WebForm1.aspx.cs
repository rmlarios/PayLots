using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace PayLots.Reportes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

            Rpt_TicketPago report = new Rpt_TicketPago();
            string path = HttpContext.Current.Server.MapPath(@"~\Reportes\Rpt_TicketPago.repx");
            //report.LoadLayout(path);
            report.Parameters["IdPago"].Value = "1934";
            report.PrintingSystem.ExportOptions.Pdf.ShowPrintDialogOnOpen = true;
            //report.PrinterName = "HP Color LaserJet Pro MFP M477 PCL-6";
            //report.CreateDocument();
            //report.PrintingSystem.ShowMarginsWarning = false;
            


            //report.CreateDocument();
            //ASPxWebDocumentViewer1.OpenReport(report);
            using (MemoryStream ms = new MemoryStream())
            {
                report.CreateDocument();
                PdfExportOptions options = new PdfExportOptions();
                options.ShowPrintDialogOnOpen = true;
                report.ExportToPdf(ms,options);
               // WriteDocumentToResponse(ms.ToArray(), "pdf", false, "Report.pdf");
                //return;
                ms.Seek(0, SeekOrigin.Begin);
                byte[] reportContent = ms.ToArray();
                Response.ContentType = "application/pdf";
                Response.Clear();
                Response.OutputStream.Write(reportContent, 0, reportContent.Length);
                Response.End();
            }
        }

        private void WriteDocumentToResponse(Byte[] documentData, string format, Boolean isInline, string fileName)
        {
            string contentType_Renamed;
            string disposition = isInline ? "inline" : "attachment";
            contentType_Renamed = String.Format("application/{0}", format);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}", disposition, fileName));
            Response.BinaryWrite(documentData);
            Response.End();
    }
    }
}