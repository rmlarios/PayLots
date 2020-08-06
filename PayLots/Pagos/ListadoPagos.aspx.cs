using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using DevExpress.Data;
using DevExpress.Web;

namespace PayLots.Pagos
{
    public partial class ListadoPagos : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    Response.Redirect("~/Account/Login.aspx");
                }

                if(!IsPostBack)
                {
                    Session["TicketImprimir"] = "";
                }

                if (Session["TicketImprimir"] != null && Session["TicketImprimir"] != "")
                    GenerarTicket(Convert.ToInt32(Session["TicketImprimir"]));
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void GenerarTicket(int IdPago)
        {
            try
            {
                Reportes.Rpt_TicketPago RptTicketPago = new Reportes.Rpt_TicketPago();
                string path = HttpContext.Current.Server.MapPath(@"~\Reportes\Rpt_TicketPago.repx");
                RptTicketPago.LoadLayout(path);
                DataSet Datos = new DataSet();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                FG.MakeRecordSet(Datos, "EXEC [SP_TicketPagoGenerar] " + IdPago + ",'" + IdentityUser + "'", "");
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);

                if (MsjSQL == "")
                {
                    if (Datos.Tables[0].Rows.Count != 0)
                    {
                        //PopupControl_Ticket.ShowOnPageLoad = true;
                        RptTicketPago.Parameters["IdPago"].Value = IdPago;
                        RptTicketPago.CreateDocument();
                        RptTicketPago.DataSource = Datos;
                        RptTicketPago.DataMember = "SP_TicketPagoGenerar";
                        VisorTicket.Report = RptTicketPago;
                        //VisorTicket.OpenReport(RptTicketPago);
                        //Session["TicketImprimir"] = "0";
                        //PrintToolBase printTool = new PrintToolBase(RptTicketPago.PrintingSystem);
                        //printTool.Print();

                    }
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }


        decimal TotalCordobas;
        decimal TotalDolares;
        protected void GridView_Pagos_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    TotalCordobas = 0;
                    TotalDolares = 0;
                }
                else
                
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        if (((ASPxSummaryItem)e.Item).Tag == "Cordobas")
                            if (e.GetValue("Moneda").ToString() == "Córdobas")
                                TotalCordobas += Convert.ToDecimal(e.FieldValue);
                    if (((ASPxSummaryItem)e.Item).Tag == "Dolares")
                        if (e.GetValue("Moneda").ToString() == "Dólares")
                            TotalDolares += Convert.ToDecimal(e.FieldValue);


                }

                else if(e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    if (((ASPxSummaryItem)e.Item).Tag == "Cordobas")
                        e.TotalValue = TotalCordobas;
                    if (((ASPxSummaryItem)e.Item).Tag == "Dolares")
                        e.TotalValue = TotalDolares;

                    e.TotalValueReady = true;
                }

            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Pagos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                string IdPago = e.EditingKeyValue.ToString();

                Session["IdAsignacionPago"] = GridView_Pagos.GetRowValuesByKeyValue(e.EditingKeyValue, "IdAsignacion");
                Session["IdPago"] = IdPago;
                Response.Redirect("RegistrarPago.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Pagos_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                int IdPago = Convert.ToInt32(GridView_Pagos.GetRowValues(e.VisibleIndex, "IdPago"));
                Session["TicketImprimir"] = IdPago;
                //GenerarTicket(IdPago);
                PopupControl_Ticket.ShowOnPageLoad = true;
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "printReport();", true);
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}