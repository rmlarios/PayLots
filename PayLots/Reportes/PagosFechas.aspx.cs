using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Clases;
using System.Data;

namespace PayLots.Reportes
{
    public partial class PagosFechas : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Toast Toast = new Toast();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
                //Session["FiltroFechaGrafico"] = "'" + DateTime.Now.Date.ToShortDateString() + "'";
        }

        protected void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ReportName"] = "PagosFechas";
                if (BootstrapCalendar1.SelectedDates.Count() == 0)
                {
                    //Toast.ShowToast(this, Clases.Toast.ToastType.Error, "Seleccione la Fecha para generar el reporte");
                    Session["FiltroFechas"] = "Todos";
                    //return;
                }
                else  if (BootstrapCalendar1.SelectedDates.Count == 1)
                    Session["FiltroFechas"] ="'"+ BootstrapCalendar1.SelectedDate.ToShortDateString() + "'";
                else if (BootstrapCalendar1.SelectedDates.Count > 1)
                {
                    string FiltoFechas = "";
                    var Fechas = BootstrapCalendar1.SelectedDates.ToList();
                    for (int i = 0; i < Fechas.Count(); i++)
                    {
                        if (FiltoFechas == "")
                            FiltoFechas = "'" + Fechas[i].ToShortDateString() + "'";
                        else
                            FiltoFechas = FiltoFechas + ",'" + Fechas[i].ToShortDateString() + "'";
                    }
                    Session["FiltroFechas"] = FiltoFechas;

                }
                Response.Redirect("ReportViewer.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void BootstrapCalendar1_SelectionChanged(object sender, EventArgs e)
        {
            string FiltroFechaGrafico = "";
            if (BootstrapCalendar1.SelectedDates.Count == 1)
                FiltroFechaGrafico = "'" + BootstrapCalendar1.SelectedDate.ToString("dd/MM/yyyy") + "'";
            else if (BootstrapCalendar1.SelectedDates.Count > 1)
            {
                string FiltoFechas = "";
                var Fechas = BootstrapCalendar1.SelectedDates.ToList();
                for (int i = 0; i < Fechas.Count(); i++)
                {
                    if (FiltoFechas == "")
                        FiltoFechas = "'" + Fechas[i].ToString("dd/MM/yyyy") + "'";
                    else
                        FiltoFechas = FiltoFechas + ",'" + Fechas[i].ToString("dd/MM/yyyy") + "'";
                }
                FiltroFechaGrafico = FiltoFechas;
            }
            Session["FiltroFechaGrafico"] = FiltroFechaGrafico;
            if(FiltroFechaGrafico!="")
                SqlDataSource_Grafico.SelectCommand = "select NombreProyecto + ' ' +Fecha as NombreProyecto,sum(Pagado) as Pagado from View_GraficoPagos where Fecha in(" + FiltroFechaGrafico + ") group by NombreProyecto + ' ' +Fecha";
           // DataSet dataSet = new DataSet();
            //FG.MakeRecordSet(dataSet, "select NombreProyecto, sum(Pagado) as Pagado, Fecha from View_GraficoPagos where Fecha in (" + FiltroFechaGrafico + ") group by NombreProyecto, Fecha", "");
            //SqlDataSource_Grafico.DataBind();
            //BootstrapPieChart1.DataSourceID = "";
            //BootstrapPieChart1.DataSource = dataSet;
            BootstrapPieChart1.DataBind();
            //SqlDataSource_Grafico.FilterExpression = " Convert(varchar,FechaRecibo,103) IN (" + FiltroFechaGrafico + ")";
            //SqlDataSource_Grafico.DataBind();
        }
    }
}