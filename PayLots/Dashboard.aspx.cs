using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using cls_GENERAL;
using DevExpress.DashboardWeb;

namespace PayLots
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["RegistrarAsignacion"] = "";
                DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
                ASPxDashboard1.SetDashboardStorage(dashboardFileStorage);
                if (User.IsInRole("Desarrollo"))
                    ASPxDashboard1.WorkingMode = WorkingMode.Viewer;
                // Uncomment this string to allow end users to create new data sources based on predefined connection strings.
                ASPxDashboard1.SetConnectionStringsProvider(new DevExpress.DataAccess.Web.ConfigFileConnectionStringsProvider());
                //ASPxDashboard1.OpenDashboard("dashboard1.xml");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}