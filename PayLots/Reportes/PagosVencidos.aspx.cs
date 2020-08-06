using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using System.Data;

namespace PayLots.Reportes
{
    public partial class PagosVencidos : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //DataSet dataset = new DataSet();
                //FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                //string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                //var retorno = FG.ExecuteSQLEscalar("SP_PagosVencidos '" + IdentityUser + "'");
                //string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                //if(MsjSQL!="")
                //{
                //    return;
                //}
                //FG.FilldataSource(SqlDataSource_PagosVencidos, "SELECT * FROM Morosos");
                //GridView_PlanPago.DataBind();

            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_PlanPago_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if(e.ButtonID=="EstadoCuenta")
            {
                Session["ReportName"] = "EstadoCuenta";
                Session["IdAsignacionEstadoCuenta"] = GridView_PlanPago.GetRowValues(e.VisibleIndex, "IdAsignacion");
                Response.Redirect("ReportViewer.aspx");
            }

        }
    }
}