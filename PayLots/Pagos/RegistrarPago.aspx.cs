using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Clases;
using PayLots.Pagos;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports;

namespace PayLots.Pagos
{
    public partial class RegistrarPago : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    Response.Redirect("~/Account/Login.aspx");
                }


                if (!IsPostBack)
                {
                    if ((Session["IdAsignacionPago"] == null && Session["IdPago"] == null) || (Session["IdAsignacionPago"] == "" && Session["IdPago"] == ""))
                    {
                        //Response.Redirect("Pagos.aspx", true);
                        //return;
                    }
                    else
                    {
                        lblIdAsignacion.Text = Session["IdAsignacionPago"].ToString();
                        lblIdPago.Text = Session["IdPago"].ToString();
                        Session["IdAsignacionPago"] = "";
                        Session["IdPago"] = "";

                    }

                    if(lblIdPago.Text=="" && lblIdAsignacion.Text=="")
                    {
                        LimpiarCampos("General");
                        HabilitarCampos(false);
                        return;
                    }

                    if (lblIdPago.Text == "0")
                        LimpiarCampos("Detalle");
                    else
                        CargarDatosPago(lblIdPago.Text);

                    if (lblIdAsignacion.Text == "0")
                        LimpiarCampos("General");
                    else
                        CargarDatosAsignacion(lblIdAsignacion.Text);
                    Session["TicketImprimir"] = "";
                    //CargarDatosAsignacion(lblIdAsignacion.Text);

                }

                ASPxNavBar navMain = (this.Master.FindControl("LeftPanel").FindControl("nbMain") as ASPxNavBar);
                if (navMain != null)
                {
                    navMain.Groups.FindByName("Pagos").Expanded = true;
                    navMain.SelectedItem = navMain.Items.FindByName("RegistrarPago");
                }

                if(Session["TicketImprimir"]!=null && Session["TicketImprimir"]!="")
                    GenerarTicket(Convert.ToInt32(Session["TicketImprimir"]));
                if (ComboBox_Moneda.Text == "Córdobas")
                    SpinEditTasaCambio.ClientEnabled = true;
                else
                    SpinEditTasaCambio.ClientEnabled = false;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        #region::::::::::::::::::::::::FUNCIONES::::::::::::::::::::::::::
        public void HabilitarCampos(Boolean opcion)
        {
            try
            {
                ComboBox_Lotes.Enabled = opcion;
                TextBoxBeneficiario.Enabled = opcion;

                TextBox_ValorLote.Enabled = opcion;
                TextBox_Prima.Enabled = opcion;
                TextBox_Abonado.Enabled = opcion;
                TextBox_Saldo.Enabled = opcion;


                ComboBox_MesPagar.Enabled = opcion;
                ComboBox_Lotes.Enabled = opcion;
                ComboBox_MesPagar.Enabled = opcion;
                TextBox_MontoCuota.Enabled = opcion;
                TextBox_MoraMes.Enabled = opcion;
                TextBox_Interés.Enabled = opcion;

                TextBox_Recibo.Enabled = opcion;
                DateEdit_FechaRecibo.Enabled = opcion;
                SpinEditMontoPagado.Enabled = opcion;
                TextBox_Observaciones.Enabled = opcion;
                ComboBox_Moneda.Enabled = opcion;
                SpinEditTasaCambio.ClientEnabled = false;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        public void LimpiarCampos(string opcion)
        {
            try
            {
                if (opcion == "Detalle")
                {
                    ComboBox_MesPagar.Text = "";
                    ComboBox_MesPagar.Enabled = true;
                    TextBox_MontoCuota.Text = "";
                    TextBox_MoraMes.Text = "";
                    TextBox_Interés.Text = "";
                    TextBox_TOTAL.Text = "";

                    TextBox_Recibo.Text = "";
                    DateEdit_FechaRecibo.Date = DateTime.Now;
                    SpinEditMontoPagado.Text = "";
                    TextBox_Observaciones.Text = "";
                    ComboBox_Moneda.Text = "Dólares";
                    SpinEditTasaCambio.ClientEnabled = false;
                    SpinEditTasaCambio.Text = "";
                }

                if (opcion == "General")
                {
                    ComboBox_Lotes.Text = "";
                    TextBoxBeneficiario.Text = "";

                    TextBox_ValorLote.Text = "";
                    TextBox_Prima.Text = "";
                    TextBox_Abonado.Text = "";
                    TextBox_Saldo.Text = "";


                    ComboBox_MesPagar.Text = "";
                    ComboBox_Lotes.Enabled = true;
                    ComboBox_MesPagar.Enabled = true;
                    TextBox_MontoCuota.Text = "";
                    TextBox_MoraMes.Text = "";
                    TextBox_Interés.Text = "";
                    TextBox_TOTAL.Text = "";

                    TextBox_Recibo.Text = "";
                    DateEdit_FechaRecibo.Date = DateTime.Now;
                    SpinEditMontoPagado.Text = "";
                    ComboBox_Moneda.Text = "Dólares";
                    SpinEditTasaCambio.ClientEnabled = false;
                    SpinEditTasaCambio.Text = "";
                    TextBox_Observaciones.Text = "";
                }

                //if(opcion=="Pago")
                //{
                //    ComboBox_MesPagar.Text = "";
                //    TextBox_MontoCuota.Text = "";
                //    TextBox_MoraMes.Text = "";
                //    TextBox_Interés.Text = "";

                //    //TextBox_Recibo.Text = "";
                //    //DateEdit_FechaRecibo.Text = "";
                //    SpinEditMontoPagado.Text = "";
                //}
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
            
                       
        }
        public  void CargarDatosAsignacion(string IdAsignacion)
        {
            try
            {
                DataSet Datos = new DataSet();
                string SQL = "SELECT [IdAsignacion],[NombreLote],[NombreCompleto],[IdLote],[MontoTotal],[Prima],[Abonado],[Saldo] FROM [View_Pagos_Asignaciones] WHERE IdAsignacion = '" + IdAsignacion + "'";
                FG.MakeRecordSet(Datos, SQL, "");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    ComboBox_Lotes.Value = Datos.Tables[0].Rows[0]["IdLote"];
                    //ComboBox_Lotes.Enabled = false;
                    TextBoxBeneficiario.Text = Datos.Tables[0].Rows[0]["NombreCompleto"].ToString();
                    TextBox_ValorLote.Text = Datos.Tables[0].Rows[0]["MontoTotal"].ToString();
                    TextBox_Prima.Text = Datos.Tables[0].Rows[0]["Prima"].ToString();
                    TextBox_Abonado.Text = Datos.Tables[0].Rows[0]["Abonado"].ToString();
                    TextBox_Saldo.Text = Datos.Tables[0].Rows[0]["Saldo"].ToString();
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void CargarDatosPago(string IdPago)
        {
            try
            {
                DataSet Datos = new DataSet();
                string SQL = "SELECT MesPagado,MontoPago,Mora,Interés,isnull(NumeroRecibo,'') NumeroRecibo,isnull(convert(varchar,FechaRecibo,103),'') FechaRecibo,TotalRecibo,Observaciones,Moneda,TasaCambio,MontoEfectivo FROM [dbo].[View_Pagos_Asignaciones] WHERE IdPago='" + IdPago + "'";
                FG.MakeRecordSet(Datos, SQL, "");
                if (Datos.Tables[0].Rows.Count != 0)
                {

                    ComboBox_MesPagar.Text = Datos.Tables[0].Rows[0]["MesPagado"].ToString();
                    ComboBox_MesPagar.Enabled = false;
                    DataSet Mes = new DataSet();
                    FG.MakeRecordSet(Mes, "SELECT MesPagado,Estado,MontoMinimo,ISNULL(Interes,0) Interes,ISNULL(Mora,0) Mora,TotalPagar FROM FN_Asignacion_PlandePago('"+ lblIdAsignacion.Text.Trim() +"') WHERE MesPagado='" + Datos.Tables[0].Rows[0]["MesPagado"].ToString() + "'", "");
                    if (Mes.Tables[0].Rows.Count != 0)
                    {
                        TextBox_MontoCuota.Text = Mes.Tables[0].Rows[0]["MontoMinimo"].ToString();
                        TextBox_MoraMes.Text = Mes.Tables[0].Rows[0]["Mora"].ToString();
                        TextBox_Interés.Text = Mes.Tables[0].Rows[0]["Interes"].ToString();
                        TextBox_TOTAL.Text = (Convert.ToDouble(TextBox_MontoCuota.Text) + Convert.ToDouble(TextBox_MoraMes.Text) + Convert.ToDouble(TextBox_Interés.Text)).ToString();
                    }
                    TextBox_Recibo.Text = Datos.Tables[0].Rows[0]["NumeroRecibo"].ToString();
                    DateEdit_FechaRecibo.Text = Datos.Tables[0].Rows[0]["FechaRecibo"].ToString();
                    SpinEditMontoPagado.Text = Datos.Tables[0].Rows[0]["MontoEfectivo"].ToString();
                    TextBox_Observaciones.Text = Datos.Tables[0].Rows[0]["Observaciones"].ToString();
                   
                    ComboBox_Moneda.Text = Datos.Tables[0].Rows[0]["Moneda"].ToString();
                    SpinEditTasaCambio.Text = Datos.Tables[0].Rows[0]["TasaCambio"].ToString();
                    if (ComboBox_Moneda.Text == "Dólares")
                        SpinEditTasaCambio.ClientEnabled = false;
                    else
                        SpinEditTasaCambio.ClientEnabled = true;
                    lblIdPago.Text = IdPago;
                }
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
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        #region:::::::::::::::::::EVENTOS DE CONTROLES::::::::::::::::::::
        protected void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Session["IdAsignacionPago"] = "";
                Session["IdPago"] = "";
                lblIdPago.Text = "0";
                lblIdAsignacion.Text = "0";
                ComboBox_Lotes.Focus();
                LimpiarCampos("General");
                HabilitarCampos(true);
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["IdAsignacionPago"] = "";
                Session["IdPago"] = "";
                lblIdAsignacion.Text = "";
                lblIdPago.Text = "";
                LimpiarCampos("General");
                HabilitarCampos(false);
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void ComboBox_Lotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_Lotes.SelectedIndex!=-1)
                {
                    lblIdAsignacion.Text = ComboBox_Lotes.SelectedItem.GetFieldValue("IdAsignacion").ToString();
                    lblIdPago.Text = "0";
                    CargarDatosAsignacion(lblIdAsignacion.Text.Trim());
                    LimpiarCampos("Detalle");
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void ComboBox_MesPagar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_MesPagar.SelectedIndex != -1)
                {
                    TextBox_MontoCuota.Text = ComboBox_MesPagar.SelectedItem.GetFieldValue("MontoMinimo").ToString();
                    TextBox_Interés.Text = ComboBox_MesPagar.SelectedItem.GetFieldValue("Interes").ToString();
                    TextBox_MoraMes.Text = ComboBox_MesPagar.SelectedItem.GetFieldValue("Mora").ToString();
                    TextBox_TOTAL.Text = ComboBox_MesPagar.SelectedItem.GetFieldValue("TotalPagar").ToString();

                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void BtnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                clsPagos Pago = new clsPagos();
                if(ComboBox_MesPagar.Text=="")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe seleccionar el mes a pagar.');", true);
                    return;
                }

                if (ComboBox_Moneda.Text=="")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe seleccionar la moneda.');", true);
                    return;
                }

                //if (TextBox_Recibo.Text.Trim() == "")
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar el Número de Recibo.');", true);
                //    return;
                //}
                if (DateEdit_FechaRecibo.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar la Fecha del Recibo.');", true);
                    return;
                }

                if (SpinEditMontoPagado.Text=="0" || SpinEditMontoPagado.Text=="")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar el valor pagado.');", true);
                    return;
                }
               

               

                if(ComboBox_Moneda.Text=="Córdobas")
                {
                    if(SpinEditTasaCambio.Text=="" || SpinEditTasaCambio.Text=="0.00")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar la Tasa de Cambio.');", true);
                        return;
                    }
                    if (Convert.ToDouble(TextBox_TOTAL.Text) >Math.Round(Convert.ToDouble(SpinEditMontoPagado.Text)/Convert.ToDouble(SpinEditTasaCambio.Text),2))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El monto pagado no puede ser menor que el total a pagar');", true);
                        return;
                    }
                }
                else
                {
                    if (Convert.ToDouble(TextBox_TOTAL.Text) > Convert.ToDouble(SpinEditMontoPagado.Text))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El monto pagado no puede ser menor que el total a pagar');", true);
                        return;
                    }
                }


                Pago.IdPago = Convert.ToInt32(lblIdPago.Text.Trim());
                Pago.IDAsignacion = Convert.ToInt32(lblIdAsignacion.Text.Trim());
                Pago.MesPagado = ComboBox_MesPagar.Text.Trim();
                Pago.NumeroRecibo = TextBox_Recibo.Text.Trim();
                Pago.FechaRecibo = DateEdit_FechaRecibo.Date;
                Pago.Moneda = ComboBox_Moneda.Text;
                Pago.TasaCambio = Pago.Moneda == "Dólares" ? 0 : Convert.ToDouble(SpinEditTasaCambio.Value);
                Pago.MontoPago = Convert.ToDouble(TextBox_MontoCuota.Text.Trim());
                Pago.Mora = Convert.ToDouble(TextBox_MoraMes.Text.Trim());
                Pago.Interes = Convert.ToDouble(TextBox_Interés.Text.Trim());
                Pago.TotalPagado = Convert.ToDouble(SpinEditMontoPagado.Value);
                Pago.Observaciones = TextBox_Observaciones.Text.Trim();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                string IdPago =  Neg.AgregarActualizarPago(Pago, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if(MsjSQL!="")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('" + MsjSQL +"');", true);
                    return;
                }
                else
                {
                    GridView_Pagos.DataBind();
                    CargarDatosAsignacion(lblIdAsignacion.Text.Trim());
                    //PopupControl_Ticket.ShowOnPageLoad = true;
                    Session["TicketImprimir"] = IdPago;
                    //GenerarTicket(Convert.ToInt32(IdPago));
                    PopupControl_Ticket.ShowOnPageLoad = true;
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "printReport();", true);
                    lblIdPago.Text = "0";
                    LimpiarCampos("Detalle");

                }

                
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

        }
        protected void GridView_Pagos_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                int IdPago = Convert.ToInt32(GridView_Pagos.GetRowValues(e.VisibleIndex, "IdPago"));
                Session["TicketImprimir"] = IdPago;
                //GenerarTicket(IdPago);
                PopupControl_Ticket.ShowOnPageLoad = true;
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "printReport();", true);
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void GridView_Pagos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            e.Cancel = true;
            string IdPago = e.EditingKeyValue.ToString();
            CargarDatosPago(IdPago);
            GridView_Pagos.CancelEdit();
        }
        protected void Btn_PrintReport_Click(object sender, EventArgs e)
        {
            Reportes.Rpt_TicketPago RptTicketPago = new Reportes.Rpt_TicketPago();

        }

        protected void GridView_Pagos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                string IdPago = e.Keys["IdPago"].ToString();
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.EliminarPago(IdPago, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    //GridView_Pagos.DataBind();
                    CargarDatosAsignacion(lblIdAsignacion.Text.Trim());
                    //PopupControl_Ticket.ShowOnPageLoad = true;
                    

                }

            }
            catch(Exception eX)
            {
                FG.Controlador_Error(eX, Page.Response);
            }
        }



        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::


    }
}