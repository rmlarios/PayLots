using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Beneficiarios;
using PayLots.Clases;

namespace PayLots.Beneficiarios
{
    public partial class Beneficiarios : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name == "")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void GridView_Beneficiarios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsBeneficiarios Beneficario = new clsBeneficiarios();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Beneficario.IdBeneficiario = 0;
                Beneficario.NombreCompleto = e.NewValues["NombreCompleto"].ToString();
                Beneficario.CedulaIdentidad = e.NewValues["CedulaIdentidad"].ToString();
                Beneficario.Direccion = e.NewValues["Direccion"] != null ? e.NewValues["Direccion"].ToString() : "";
                Beneficario.Telefono = e.NewValues["Telefono"].ToString();
                Neg.AgregarActualizarBeneficiario(Beneficario, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro creado con éxito.');", true);
                    GridView_Beneficiarios.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Beneficiarios_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                int IdBeneficario = Convert.ToInt32(e.Keys["IdBeneficiario"].ToString());
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.EliminarBeneficiario(IdBeneficario, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro eliminado con éxito.');", true);

                }



            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Beneficiarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsBeneficiarios Beneficario = new clsBeneficiarios();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Beneficario.IdBeneficiario = Convert.ToInt32(e.Keys["IdBeneficiario"]);
                Beneficario.NombreCompleto = e.NewValues["NombreCompleto"].ToString();
                Beneficario.CedulaIdentidad = e.NewValues["CedulaIdentidad"].ToString();
                Beneficario.Direccion = e.NewValues["Direccion"] != null ? e.NewValues["Direccion"].ToString() : "";
                Beneficario.Telefono = e.NewValues["Telefono"].ToString();
                Neg.AgregarActualizarBeneficiario(Beneficario, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro actualizado con éxito.');", true);
                    GridView_Beneficiarios.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Beneficiarios_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                if (e.ButtonID == "Lotes")
                {
                    Session["IdBeneficiario"] = GridView_Beneficiarios.GetRowValues(e.VisibleIndex, "IdBeneficiario");
                    ASPxPopup_LotesAsignados.ShowOnPageLoad = true;
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}