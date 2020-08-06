using DevExpress.DashboardWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using cls_GENERAL;

namespace PayLots {
    public partial class _Default : System.Web.UI.Page {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet Datos = new DataSet();
                string sql = "select count(IdUbicacion) from Ubicaciones " +
                             "union ALL " +
                             "select distinct count(IdLote) Lotes from Lotes " +
                             "union ALL " +
                             "select count(distinct IdBeneficiario) Clientes from Asignaciones where Estado = 'Vigente' " +
                             "union ALL " +
                             "select ISNULL(SUM(ISNULL(MontoPago,0)+ISNULL(Interés, 0) + ISNULL(Mora, 0)),0) from Pagos where convert(date, FechaRecibo) = convert(date, GETDATE()) AND Moneda= 'DÓLARES' " + 
                             "union ALL " +
                             "select ISNULL(SUM(MontoEfectivo),0) from Pagos where convert(date, FechaRecibo) = convert(date, GETDATE()) AND Moneda= 'CÓRDOBAS'";
                FG.MakeRecordSet(Datos, sql, "");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    string Proyectos = Datos.Tables[0].Rows[0][0].ToString();
                    string Lotes = Datos.Tables[0].Rows[1][0].ToString();
                    string Clientes = Datos.Tables[0].Rows[2][0].ToString();
                    string PagosDolares = Datos.Tables[0].Rows[3][0].ToString();
                    string PagosCordobas = Datos.Tables[0].Rows[4][0].ToString();
                    string Parametros = "'" + Proyectos + "','" + Lotes + "','" + Clientes + "','" + PagosDolares + "','" + PagosCordobas + "'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dash", "FillDash(" + Parametros + ");", true);
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}