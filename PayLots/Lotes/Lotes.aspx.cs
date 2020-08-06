using cls_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayLots.Lotes;
using PayLots.Clases;

namespace PayLots.Lotes
{
    public partial class Lotes : System.Web.UI.Page
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

        protected void GridView_Lotes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsLotes Lote = new clsLotes();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Lote.IdLote = 0;
                Lote.IdBloque = Convert.ToInt32(e.NewValues["IdBloque"].ToString());
                Lote.NumeroLote = e.NewValues["NumeroLote"].ToString();
                Lote.Area = Convert.ToDouble(e.NewValues["Area"]);
                Neg.AgregarActualizarLote(Lote, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro creado con éxito.');", true);
                    GridView_Lotes.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Lotes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                int IdLote = Convert.ToInt32(e.Keys["IdLote"].ToString());
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.EliminarLote(IdLote, IdentityUser);
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

        protected void GridView_Lotes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsLotes Lote = new clsLotes();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Lote.IdLote = Convert.ToInt32(e.Keys["IdLote"].ToString());
                Lote.IdBloque = Convert.ToInt32(e.NewValues["IdBloque"].ToString());
                Lote.NumeroLote = e.NewValues["NumeroLote"].ToString();
                Lote.Area = Convert.ToDouble(e.NewValues["Area"]);
                Neg.AgregarActualizarLote(Lote, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro actualizado con éxito.');", true);
                    GridView_Lotes.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

       
    }
}