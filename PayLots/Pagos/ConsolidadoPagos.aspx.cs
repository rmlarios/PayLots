using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using DevExpress.Web;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;
using System.IO;


namespace PayLots.Pagos
{
    public partial class ConsolidadoPagos : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        List<String> orderList = new List<string>(new string[] { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "obtubre", "noviembre", "diciembre" });
        protected void ASPxPivotGrid1_CustomFieldSort(object sender, DevExpress.Web.ASPxPivotGrid.PivotGridCustomFieldSortEventArgs e)
        {
            try
            {
                if (e.Field.FieldName == "MesPagado")
                {
                    string val1 = Convert.ToString(e.Value1);
                    string val2 = Convert.ToString(e.Value2);
                    DateTime f1 = Convert.ToDateTime(val1);
                    DateTime f2 = Convert.ToDateTime(val2);
                    e.Result = f1.CompareTo(f2);

                    e.Handled = true;
                }

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

        }


        protected void Btn_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
               
                //string Ruta = HttpContext.Current.Server.MapPath(@"~\App_Data\Respaldos\Consolidado.pdf");
                //Exporter.ExportToPdf(Ruta);
                //if(System.IO.File.Exists(Ruta))
                //{
                //    MemoryStream m = new MemoryStream();
                //    byte[] reportContent = System.IO.File.ReadAllBytes(Ruta);
                //    Response.ContentType = "application/pdf";
                //    Response.Clear();
                //    Response.ContentType = "application/pdf";
                //    Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}", "attachment", "Consolidado.pdf"));
                //    Response.BinaryWrite(reportContent);
                //    Response.End();
                //}

                /*XlsxExportOptions options = new XlsxExportOptions() ;// new XlsxExportOptionsEx(
                options.ExportMode = XlsxExportMode.SingleFile;
                
                Exporter.ExportXlsxToResponse("ConsolidadoPagos",options ,true);
               
                /*MemoryStream stream = new MemoryStream();
                Exporter.ExportToXlsx(stream);
                byte[] b = stream.ToArray();
                Response.ContentType = "application/pdf";
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}", "attachment", "ConsolidadoPagos.xlsx"));
                Response.BinaryWrite(b);
                Response.End();*/
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void ASPxPivotGrid1_CustomCellStyle(object sender, DevExpress.Web.ASPxPivotGrid.PivotCustomCellStyleEventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void lblConcat_DataBinding(object sender, EventArgs e)
        {
            try
            {
                ASPxLabel label = (ASPxLabel)sender;
                label.Text = ((PivotGridFieldValueTemplateContainer)label.Parent).Text;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Btn_ExportarXLSX_Click(object sender, EventArgs e)
        {
            try
            {
                Exporter.ExportXlsxToResponse("Consolidado", true);
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void Btn_ExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Exporter.OptionsPrint.PageSettings.Landscape = true;
                //Exporter.OptionsPrint.PrintRowAreaOnEveryPage = true;
                Exporter.OptionsPrint.PageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
                Exporter.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal;
                
                Exporter.ExportPdfToResponse("Consolidado", true);
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}