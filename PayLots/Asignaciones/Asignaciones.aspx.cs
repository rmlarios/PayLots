using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using cls_GENERAL;
using PayLots.Clases;
using PayLots.Beneficiarios;

namespace PayLots.Asignaciones
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RegistrarAsignacion"] = "";
            }
            if (HttpContext.Current.User.Identity.Name=="")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            
        }
        #region:::::::::::::::::GRID ASIGNACIONES:::::::::::::::::::
        protected void GridView_Asignaciones_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "IdBeneficiario")
                {
                    if (Session["IdNuevoBeneficiario"] != null)
                        e.Editor.Value = Session["IdNuevoBeneficiario"];
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void GridView_Asignaciones_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "IdBeneficiario")
                {
                    ASPxComboBox combo = (ASPxComboBox)e.Editor;
                    combo.Buttons.Clear();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void GridView_Asignaciones_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                GridView_Asignaciones.CancelEdit();
                Session["RegistrarAsignacion"] = e.EditingKeyValue;
                Response.Redirect("RegistrarAsignacion.aspx", true);
                
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Asignaciones_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            try
            {
                GridView_Asignaciones.CancelEdit();
                Session["RegistrarAsignacion"] = "0";
                Response.Redirect("RegistrarAsignacion.aspx", true);
                
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Asignaciones_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                lblIdAnular.Text = e.Keys["IdAsignacion"].ToString();
                ASPxPopupControl_Anular.ShowOnPageLoad = true;
                Memo_MotivoAnular.Text = "";
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

        }

        protected void GridView_Asignaciones_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                if (e.ButtonID == "PlanPago")
                {

                    string IdAsignacion = GridView_Asignaciones.GetRowValues(e.VisibleIndex, "IdAsignacion").ToString();
                    Session["ReportName"] = "PlanPago";
                    string host = HttpContext.Current.Request.UrlReferrer.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/Reportes/ReportViewer.aspx?RP=" + IdAsignacion;
                    Response.Redirect(host);
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::::::POPUP BENEFICIARIOS::::::::::::::::::::::
        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            if(TextBox_Nombre.Text=="" || TextBox_Cedula.Text=="" || TextBox_Telefono.Text=="")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar todos los campos obligatorios.');", true);
                return;
            }
            clsBeneficiarios Beneficiario = new clsBeneficiarios();
            Beneficiario.IdBeneficiario = 0;
            Beneficiario.NombreCompleto = TextBox_Nombre.Text.Trim();
            Beneficiario.CedulaIdentidad = TextBox_Cedula.Text.Trim();
            Beneficiario.Telefono = TextBox_Telefono.Text.Trim();
            Beneficiario.Direccion = Memo_Direccion.Text.Trim();
            FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
            string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
            string IdNuevo = Neg.AgregarActualizarBeneficiario(Beneficiario, IdentityUser);
            string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
            if(MsjSQL!="")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('" + MsjSQL +"');", true);
                return;
            }
            else
            {
                Session["IdNuevoBeneficiario"] = IdNuevo;
                SqlDataSource_Beneficiarios.DataBind();
            }
        }
        
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            TextBox_Nombre.Text = "";
            TextBox_Cedula.Text = "";
            TextBox_Telefono.Text = "";
            Memo_Direccion.Text = "";
            ASPxPopup_Beneficiarios.ShowOnPageLoad = false;
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region:::::::::::::::POPUP ANULAR ASIGNACION:::::::::::::::::::
        protected void Button_CancelarAnular_Click(object sender, EventArgs e)
        {
            try
            {
                Memo_MotivoAnular.Text = "";
                ASPxPopupControl_Anular.ShowOnPageLoad = false;
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Button_Anular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Memo_MotivoAnular.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Ingrese el motivo de anulación.');", true);
                    return;
                }
                if (lblIdAnular.Text != "")
                {
                    int IdAnular = Convert.ToInt32(lblIdAnular.Text.Trim());
                    FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                    string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                    Neg.AnularAsignacion(IdAnular, Memo_MotivoAnular.Text, IdentityUser);
                    string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                        return;
                    }
                    else
                    {
                        ASPxPopupControl_Anular.ShowOnPageLoad = false;
                        GridView_Asignaciones.DataBind();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Asignacion anulada con éxito.');", true);
                        return;
                    }
                }
                else
                {
                    ASPxPopupControl_Anular.ShowOnPageLoad = false;
                }

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        protected void Unnamed_Init(object sender, EventArgs e)
        {
            
        }

        protected void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //ASPxCheckBox checkBox = (ASPxCheckBox)sender;
                //if (checkBox.CheckState == CheckState.Checked)
                //    SqlDataSource_Asignaciones.SelectCommand = "SELECT [IdAsignacion], [IdLote],[IdBeneficiario], [NombreProyecto], [NombreLote], [NombreCompleto], [MontoTotal], [Abonado],[Prima], [Saldo], [FechaInicioPago], [CuotaMinima], [Estado], [Donado],[AplicaInteres] FROM [View_Asignaciones_Saldo] WHERE ESTADO='Vigente'";
                //else if(checkBox.CheckState == CheckState.Unchecked)
                //    SqlDataSource_Asignaciones.SelectCommand = "SELECT [IdAsignacion], [IdLote],[IdBeneficiario], [NombreProyecto], [NombreLote], [NombreCompleto], [MontoTotal], [Abonado],[Prima], [Saldo], [FechaInicioPago], [CuotaMinima], [Estado], [Donado],[AplicaInteres] FROM [View_Asignaciones_Saldo] WHERE ESTADO='Anulada'";

                //GridView_Asignaciones.DataBind();

            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}