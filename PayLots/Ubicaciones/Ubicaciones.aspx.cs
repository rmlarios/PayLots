using cls_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayLots.Ubicaciones;
using PayLots.Clases;

namespace PayLots.Ubicaciones
{
    public partial class Ubicaciones : System.Web.UI.Page
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

        protected void GridView_Ubicaciones_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsUbicaciones Ubicacion = new clsUbicaciones();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Ubicacion.IdUbicacion = 0;
                Ubicacion.NombreProyecto = e.NewValues["NombreProyecto"].ToString();
                Ubicacion.IdMunicipio = Convert.ToInt32(e.NewValues["Id_Municipio"].ToString());
                Ubicacion.Direccion = e.NewValues["Direccion"] != null ? e.NewValues["Direccion"].ToString() : "";
                Ubicacion.AplicaInteres = Convert.ToBoolean(e.NewValues["AplicaInteres"]);
                Neg.AgregarActualizarUbicacion(Ubicacion, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro creado con éxito.');", true);
                    GridView_Ubicaciones.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Ubicaciones_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsUbicaciones Ubicacion = new clsUbicaciones();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Ubicacion.IdUbicacion = Convert.ToInt32(e.Keys["IdUbicacion"]);
                Ubicacion.NombreProyecto = e.NewValues["NombreProyecto"].ToString();
                Ubicacion.IdMunicipio = Convert.ToInt32(e.NewValues["Id_Municipio"].ToString());
                Ubicacion.Direccion = e.NewValues["Direccion"] != null ? e.NewValues["Direccion"].ToString() : "";
                Ubicacion.AplicaInteres = Convert.ToBoolean(e.NewValues["AplicaInteres"]);
                Neg.AgregarActualizarUbicacion(Ubicacion, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro actualizado con éxito.');", true);
                    GridView_Ubicaciones.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Ubicaciones_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                int IdUbicacion = Convert.ToInt32(e.Keys["IdUbicacion"].ToString());
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.EliminarUbicacion(IdUbicacion, IdentityUser);
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

        protected void GridView_Ubicaciones_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                if (e.ButtonID == "Bloques")
                {
                    Session["IdUbicacion"] = GridView_Ubicaciones.GetRowValues(e.VisibleIndex, "IdUbicacion");
                    ASPxPopup_Bloques.ShowOnPageLoad = true;
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void ASPxGridView_Bloques_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                if (Session["IdUbicacion"] == null)
                {
                    ASPxPopup_Bloques.ShowOnPageLoad = false;
                    ASPxGridView_Bloques.CancelEdit();
                    return;
                }
                clsBloques Bloque = new clsBloques();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Bloque.IdBloque = 0;
                Bloque.IdUbicacion = Convert.ToInt32(Session["IdUbicacion"]);
                Bloque.Bloque = e.NewValues["Bloque"].ToString();
                Bloque.Observaciones = e.NewValues["Observaciones"] != null ? e.NewValues["Observaciones"].ToString() : "";
                Neg.AgregarActualizarBloque(Bloque, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro creado con éxito.');", true);
                    ASPxGridView_Bloques.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void ASPxGridView_Bloques_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                if (Session["IdUbicacion"] == null)
                {
                    ASPxPopup_Bloques.ShowOnPageLoad = false;
                    ASPxGridView_Bloques.CancelEdit();
                    return;
                }
                clsBloques Bloque = new clsBloques();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Bloque.IdBloque = Convert.ToInt32(e.Keys["IdBloque"]);
                Bloque.IdUbicacion = Convert.ToInt32(Session["IdUbicacion"]);
                Bloque.Bloque = e.NewValues["Bloque"].ToString();
                Bloque.Observaciones = e.NewValues["Observaciones"] != null ? e.NewValues["Observaciones"].ToString() : "";
                Neg.AgregarActualizarBloque(Bloque, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro actualizado con éxito.');", true);
                    ASPxGridView_Bloques.CancelEdit();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void ASPxGridView_Bloques_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                int IdBloque = Convert.ToInt32(e.Keys["IdBloque"].ToString());
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.EliminarBloque(IdBloque, IdentityUser);
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