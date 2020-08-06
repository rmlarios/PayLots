using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Clases;
using DevExpress.Web;

namespace PayLots.Pagos
{
    public partial class Pagos : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name == "")
            {
                Response.Redirect("~Account/Login.aspx");
            }
        }
        //CAMBIO EL COLOR DEL ENCABEZADO DE GRUPO DE LAS ASIGNACIONES ANULADAS
        protected void GridView_Pagos_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if(e.RowType == DevExpress.Web.GridViewRowType.Group)
            {
                string Estado = GridView_Pagos.GetRowValues(e.VisibleIndex, "Estado").ToString();
                if (Estado == "Anulada")
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(252, 184, 185);
                    e.Row.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
        }
        protected void GridView_Pagos_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            
        }
        //BOTON PARA REGISTRAR NUEVO PAGO
        protected void ASPxButton_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewGroupRowTemplateContainer row = (GridViewGroupRowTemplateContainer)((sender as ASPxButton).NamingContainer);
                string IdAsignacion = row.KeyValue.ToString();
                Session["IdAsignacionPago"] = IdAsignacion;
                Session["IdPago"] = "0";
                Response.Redirect("RegistrarPago.aspx");
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        public string ObtenerCabezeraGrupo(object Container)
        {
            try
            {
                string Cabezera = "";
                GridViewGroupRowTemplateContainer row = (GridViewGroupRowTemplateContainer)Container;
                Cabezera = "Lote: " + row.GroupTexts[1] + " Nombre: " + row.GroupTexts[2] + " " + row.SummaryText;
                return Cabezera;
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
                return "";
            }
        }

        protected void GridView_Pagos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                string IdPago = e.EditingKeyValue.ToString().Split('|')[0];
                
                Session["IdAsignacionPago"] = GridView_Pagos.GetRowValuesByKeyValue(e.EditingKeyValue, "IdAsignacion");
                Session["IdPago"] = IdPago;
                Response.Redirect("RegistrarPago.aspx");
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

    }
}