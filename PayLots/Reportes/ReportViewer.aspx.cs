using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Configuraciones;
using PayLots.Clases;
using DevExpress.XtraReports.UI;
using System.Drawing;
using System.IO;
using DevExpress.Web;

namespace PayLots.Reportes
{
    public partial class ReportViewer : System.Web.UI.Page
    {

        DataSet Datos = new DataSet();
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ReportName"] == null || Session["ReportName"] == "")
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            if (HttpContext.Current.User.Identity.Name == "")
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            string ReportName = Session["ReportName"].ToString();
            string IdentityUser = "";
            string MsjSQL = "";
            switch (ReportName)
            {
                case "PlanPago":
                    if (Request.Params["RP"] == null || Request.Params["RP"] == "")
                    {
                        return;
                    }
                    int IdAsignacion = Convert.ToInt32(Request.Params["RP"].ToString());
                    Rpt_PlanPago RptPlanPago = new Rpt_PlanPago();
                    //FG.MakeRecordSet(Datos, "SELECT IdAsignacion, Proyecto, NumeroLote, AreaLote, Total, Prima, Beneficiario, NumeroCuota, FechaCuota, MesPagado, SaldoInicial, MontoMinimo, Saldo, Interes,  TotalPagar, MontoPagado, FechaPago, Estado, Mora FROM dbo.FN_Asignacion_PlandePago(" + IdAsignacion + ") AS FN_Asignacion_PlandePago_1", "");
                    FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                    IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                    FG.MakeRecordSet(Datos, "EXEC SP_PlanPagoGenerar " + IdAsignacion + ", '" + IdentityUser + "'" , "");
                    MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")
                    {
                        if (Datos.Tables[0].Rows.Count != 0)
                        {
                            RptPlanPago.DataSource = Datos;
                            RptPlanPago.DataMember = "View_Reporte_PlanPago";
                            CargarDatosEmpresa(RptPlanPago);
                            RptPlanPago.CreateDocument();
                            WebDocumentViewer.OpenReport(RptPlanPago);
                        }
                    }
                    break;
                case "EstadoCuenta":
					ASPxNavBar navMain = (this.Master.FindControl("LeftPanel").FindControl("nbMain") as ASPxNavBar);
				    if (navMain != null)
				    {
					    navMain.Groups.FindByName("Reportes").Expanded = true;
                        navMain.SelectedItem = navMain.Items.FindByName("EstadoCuenta");
				    }
                    
                    Rpt_EstadoCuenta RptEstadoCuenta = new Rpt_EstadoCuenta();
                    if (Session["IdAsignacionEstadoCuenta"] != null && Session["IdAsignacionEstadoCuenta"] != "")
                        RptEstadoCuenta.Parameters["IdAsignacion"].Value = Convert.ToInt32(Session["IdAsignacionEstadoCuenta"]);
                    CargarDatosEmpresa(RptEstadoCuenta);
                    RptEstadoCuenta.CreateDocument();
                    WebDocumentViewer.OpenReport(RptEstadoCuenta);
                    break;
                case "TicketPago":
                    if(Session["IdPagoTicket"]==null || Session["IdTicketPago"]=="")
                    {
                        return;
                    }
                    Rpt_TicketPago RptTicketPago = new Rpt_TicketPago();
                    int IdPago = Convert.ToInt32(Session["IdPagoTicket"]);
                    FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                    IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                    FG.MakeRecordSet(Datos, "EXEC [SP_TicketPagoGenerar] " + IdPago + ",'" + IdentityUser +"'", "");
                    MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")
                    {
                        if (Datos.Tables[0].Rows.Count != 0)
                        {
                            RptTicketPago.DataSource = Datos;
                            RptTicketPago.DataMember = "View_Reporte_TicketPago";
                            RptTicketPago.CreateDocument();
                            WebDocumentViewer.OpenReport(RptTicketPago);
                        }
                    }
                                        
                    break;
                case "PagosFechas":
                    Rpt_PagosFechas RptPagosFechas = new Rpt_PagosFechas();
                    string FiltroFechas = Session["FiltroFechas"].ToString();
                    FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                    IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                    if(FiltroFechas!="Todos")
                        FG.MakeRecordSet(Datos, "SELECT * FROM View_Pagos_Asignaciones WHERE convert(date,FechaRecibo) IN(" + FiltroFechas + ")", "");
                    else
                        FG.MakeRecordSet(Datos, "SELECT * FROM View_Pagos_Asignaciones", "");
                    MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL == "")
                    {
                        if (Datos.Tables[0].Rows.Count != 0)
                        {
                            RptPagosFechas.DataSource = Datos;
                            RptPagosFechas.DataMember = "View_Pagos_Asignaciones";
                            CargarDatosEmpresa(RptPagosFechas);
                            RptPagosFechas.CreateDocument();
                            WebDocumentViewer.OpenReport(RptPagosFechas);
                        }
                    }
                    break;
                case "Proforma":
                    Rpt_Proforma RptProforma = new Rpt_Proforma();
                    int IdProforma = Convert.ToInt32(Session["IdProforma"]);
                    RptProforma.Parameters["IdProforma"].Value = IdProforma;
                    CargarDatosEmpresa(RptProforma);
                    string Ruta = HttpContext.Current.Server.MapPath(@"~\Content\Imagenes\");
                    ((XRPictureBox)RptProforma.FindControl("xrPicture_Fecha", true)).ImageUrl = Ruta + "proforma2.png";

                    RptProforma.CreateDocument();
                    WebDocumentViewer.OpenReport(RptProforma);
                    break;


            }




        }

        public void CargarDatosEmpresa(XtraReport Reporte)
        {
            /*Cargamos los datos de la empresa*/
            clsDatosEmpresa DatosEmpresa = new clsDatosEmpresa();
            DatosEmpresa = Neg.CargarDatosEmpresa();
            Reporte.FindControl("lblNombreEmpresa", true).Text = DatosEmpresa.NombreEmpresa;
            Reporte.FindControl("lblDireccion", true).Text = DatosEmpresa.Direccion;
            Reporte.FindControl("lblTelefono", true).Text = DatosEmpresa.Telefono;
            if (DatosEmpresa.Logo != null)
             ((XRPictureBox)Reporte.FindControl("picLogo", true)).Image = Image.FromStream(new MemoryStream(DatosEmpresa.Logo));
            /**********************************/
        }
    }
}