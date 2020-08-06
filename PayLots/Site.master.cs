using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using cls_GENERAL;


namespace PayLots {
    public partial class SiteMaster : System.Web.UI.MasterPage {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name == "")
            {
                Response.Redirect("~/Account/Login.aspx", true);
                return;
            }
            AnonymousMenu.Items.FindByName("LoginUser").Text = HttpContext.Current.User.Identity.Name;
            UpdateUserInfo();
            if (HttpContext.Current.User.IsInRole("Desarrollo"))
                nbMain.Groups.FindByName("Desarrollo").Visible = true;
            else
                nbMain.Groups.FindByName("Desarrollo").Visible = false;
            
            //if (Request.Url.Segments[Request.Url.Segments.Count() - 1] == "RegistrarAsignacion.aspx")
            //{
            //    nbMain.SelectedItem = nbMain.Items.FindByName("RegistrarAsignacion");
            //}
        }

        protected void UpdateUserInfo()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                             
                var myAccountItem = AnonymousMenu.Items.FindByName("LoginUser");
                var accountImage = (ASPxBinaryImage)AnonymousMenu.Items[1].FindControl("ImgAvatar");
                accountImage.ContentBytes=(byte[])HttpContext.Current.Profile.GetPropertyValue("Avatar");
                
            }
        }
        public void Permisos()
        {
            try
            {
                string Rol = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name)[0].ToLower();
                if (Rol != "" && Rol != null)
                {
                    if (Rol != "administrador" && Rol!="desarrollo")
                    {
                        nbMain.Groups.FindByName("Desarrollo").Visible = false;
                        nbMain.Groups.FindByName("Administrar").Visible = false;
                    }
                }
                else
                    nbMain.Enabled = false;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void LoggedInMenuMenu_ItemClick(object source, DevExpress.Web.Bootstrap.BootstrapMenuItemEventArgs e)
        {
            if (e.Item.Name == "Logout")
            {
                FormsAuthentication.SignOut();

                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void nbMain_ItemClick(object source, NavBarItemEventArgs e)
        {
            try
            {
                string host = HttpContext.Current.Request.UrlReferrer.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;

                if (e.Item.Name == "EstadoCuenta")
                {
                    Session["ReportName"] = "EstadoCuenta";
                    Session["IdAsignacionEstadoCuenta"] = "";
                    Response.Redirect(host + "/Reportes/ReportViewer.aspx");
                }
                if (e.Item.Name == "RegistrarAsignacion")
                {
                    Session["RegistrarAsignacion"] = 0;
                    Response.Redirect(host + "/Asignaciones/RegistrarAsignacion.aspx");
                }
                if (e.Item.Name == "RegistrarPago")
                {
                    Session["IdAsignacionPago"] = "0";
                    Session["IdPago"] = "0";
                    Response.Redirect(host + "/Pagos/RegistrarPago.aspx");
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

        }

        protected void LeftAreaMenu_ItemClick(object source, MenuItemEventArgs e)
        {
            try
            {
                if (e.Item.Name== "ToggleLeftPanel")
                {
                    if (e.Item.Checked == true)
                        e.Item.Image.IconID = "iconbuilder_actions_delete_svg_white_32x32";
                    else
                        e.Item.Image.IconID = "spreadsheet_chartgridlineshorizontal_major_svg_32x32";
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        
    }
}