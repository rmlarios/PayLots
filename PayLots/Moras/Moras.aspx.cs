using cls_GENERAL;
using PayLots.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayLots.Moras
{
    public partial class Moras : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        Toast Toast = new Toast();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name == "")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void GridView_Moras_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsMoras Mora = new clsMoras();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Mora.IdMora = 0;
                Mora.Minimo = Convert.ToInt32(e.NewValues["Minimo"]);
                Mora.Maximo = Convert.ToInt32(e.NewValues["Maximo"]);
                Mora.Porcentaje = Convert.ToDouble(e.NewValues["Porcentaje"]);
                Neg.AgregarActualizarMora(Mora, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro creado con éxito.');", true);
                    GridView_Moras.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Moras_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsMoras Mora = new clsMoras();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Mora.IdMora = Convert.ToInt32(e.Keys["IdMora"]);
                Mora.Minimo = Convert.ToInt32(e.NewValues["Minimo"]);
                Mora.Maximo = Convert.ToInt32(e.NewValues["Maximo"]);
                Mora.Porcentaje = Convert.ToDouble(e.NewValues["Porcentaje"]);
                Neg.AgregarActualizarMora(Mora, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro creado con éxito.');", true);
                    GridView_Moras.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Moras_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                int IdMora = Convert.ToInt32(e.Keys["IdMora"].ToString());
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.EliminarMora(IdMora, IdentityUser);
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
    }
}