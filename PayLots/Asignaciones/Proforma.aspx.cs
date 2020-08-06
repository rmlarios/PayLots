using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Clases;
using PayLots.Reportes;

namespace PayLots.Asignaciones
{
    public partial class Proforma : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Toast Toast = new Toast();
        Negocio Neg = new Negocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    Response.Redirect("~/Account/Login.aspx");
                }

                if (!IsPostBack)
                {
                    LimpiarCampos();
                }

                if (lblIdProforma.Text == "0")
                    Btn_Imprimir.Enabled = false;
                else
                {
                    Btn_Imprimir.Enabled = true;
                    GenerarProforma();

                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected  void LimpiarCampos()
        {
            try
            {
                lblIdProforma.Text = "0";

                TextBox_Nombre.Text = "";
                TextBox_Domicilio.Text = "";
                TextBox_Telefono.Text = "";
                TextBox_Email.Text = "";

                ComboBox_Proyecto.Text = "";
                TextBox_Lote.Text = "";
                SpinEdit_Areas.Text = "";
                SpinEdit_PrecioVara.Text = "";
                SpinEdit_Total.Text = "";
                SpinEdit_Prima.Text = "0";

                SpinEdit_Financiar.Text = "";
                SpinEdit_Plazo.Text = "";
                SpinEdit_Interes.Text = "";
                SpinEdit_Cuota.Text = "";
                SpinEdit_InteresAcumulado.Text = "";
                SpinEdit_FinalPagado.Text = "";

                Btn_Imprimir.Enabled = false;

            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void CargarDatos(string IdProforma)
        {
            DataSet Datos = new DataSet();
            FG.MakeRecordSet(Datos, "SELECT * FROM Proformas WHERE IdProforma='" + IdProforma + "'", "");
            if(Datos.Tables[0].Rows.Count!=0)
            {
                lblIdProforma.Text = Datos.Tables[0].Rows[0]["IdProforma"].ToString();
                TextBox_Nombre.Text = Datos.Tables[0].Rows[0]["Nombre"].ToString();
                TextBox_Domicilio.Text = Datos.Tables[0].Rows[0]["Domicilio"].ToString();
                TextBox_Telefono.Text= Datos.Tables[0].Rows[0]["Telefono"].ToString();
                TextBox_Email.Text = Datos.Tables[0].Rows[0]["Email"].ToString();
                ComboBox_Proyecto.Text = Datos.Tables[0].Rows[0]["Proyecto"].ToString();
                TextBox_Lote.Text = Datos.Tables[0].Rows[0]["Lote"].ToString();
                SpinEdit_Areas.Text = Datos.Tables[0].Rows[0]["Area"].ToString();
                SpinEdit_PrecioVara.Text = Datos.Tables[0].Rows[0]["PrecioVara"].ToString();
                SpinEdit_Total.Text =Datos.Tables[0].Rows[0]["Total"].ToString();
                SpinEdit_Prima.Text = Datos.Tables[0].Rows[0]["Prima"].ToString();
                SpinEdit_Financiar.Text = Datos.Tables[0].Rows[0]["Financiar"].ToString();
                SpinEdit_Interes.Text = Datos.Tables[0].Rows[0]["Interes"].ToString();
                SpinEdit_Plazo.Text = Datos.Tables[0].Rows[0]["Plazo"].ToString();
                SpinEdit_Cuota.Text = Datos.Tables[0].Rows[0]["Cuota"].ToString();
                SpinEdit_InteresAcumulado.Text = Datos.Tables[0].Rows[0]["InteresAcumulado"].ToString();
                SpinEdit_FinalPagado.Text = Datos.Tables[0].Rows[0]["TotalAPagar"].ToString();

               
            }

        }

        protected void GenerarProforma()
        {
            try
            {
                Rpt_Proforma RptProforma = new Rpt_Proforma();
                string path = HttpContext.Current.Server.MapPath(@"~\Reportes\Rpt_Proforma.repx");
                RptProforma.LoadLayout(path);
                int IdProforma = Convert.ToInt32(lblIdProforma.Text); //Convert.ToInt32(Session["IdProforma"]);
                RptProforma.Parameters["IdProforma"].Value = IdProforma;
                DataSet Datos = new DataSet();
                //FG.MakeRecordSet(Datos, "SELECT * FROM Proformas WHERE IdProforma='" + IdProforma +"'", "");
                PayLots.Reportes.ReportViewer reportViewer = new ReportViewer();
                reportViewer.CargarDatosEmpresa(RptProforma);
                RptProforma.CreateDocument();
                //RptProforma.DataSource = Datos;
                //RptProforma.DataMember = "Proformas_1";
                //VisorProforma.Report = RptProforma;
                ASPxWebDocumentViewer1.OpenReport(RptProforma);
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
                
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Nombre.Text == "")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el nombre del cliente.");
                else if (TextBox_Domicilio.Text=="")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el domicilio del cliente.");
                else if (TextBox_Telefono.Text=="")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el número telefónico del cliente.");
                else if (ComboBox_Proyecto.Text=="")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe seleccionar el Proyecto donde está ubicado el Lote.");
                else if (TextBox_Lote.Text=="")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el Número del Lote.");
                else if (SpinEdit_Areas.Text=="" || SpinEdit_Areas.Text=="0")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el Área del Lote.");
                else if (SpinEdit_PrecioVara.Text=="" || SpinEdit_PrecioVara.Text=="0")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el Precio de la Vara Cuadrada.");
                else if (SpinEdit_Interes.Text=="" || SpinEdit_Interes.Text=="0")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar la Tasa de Interés a aplicar.");
                else if (SpinEdit_Plazo.Text=="" || SpinEdit_Plazo.Text=="0")
                    Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar el Plazo del Crédito.");
                else
                {
                    clsProformas Proforma = new clsProformas();
                    Proforma.IdProforma = Convert.ToInt32(lblIdProforma.Text);
                    Proforma.Nombre = TextBox_Nombre.Text;
                    Proforma.Domicilio = TextBox_Domicilio.Text;
                    Proforma.Telefono = TextBox_Telefono.Text;
                    Proforma.Email = TextBox_Email.Text;
                    Proforma.Proyecto = ComboBox_Proyecto.Text.Trim();
                    Proforma.Lote = TextBox_Lote.Text;
                    Proforma.Area = Convert.ToDouble(SpinEdit_Areas.Text);
                    Proforma.PrecioVara = Convert.ToDouble(SpinEdit_PrecioVara.Text);
                    Proforma.Prima = Convert.ToDouble(SpinEdit_Prima.Text);
                    Proforma.Interes = Convert.ToInt32(SpinEdit_Interes.Text);
                    Proforma.Plazo = Convert.ToInt32(SpinEdit_Plazo.Text);

                    FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                    string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                    string IdProforma = Neg.AgregarActualizarProforma(Proforma, IdentityUser);
                    string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('" + MsjSQL + "');", true);
                        return;
                    }
                    else
                    {

                        lblIdProforma.Text = IdProforma;
                        Btn_Imprimir.Enabled = true;
                        CargarDatos(IdProforma);
                        Toast.ShowToast(this, Toast.ToastType.Success, "Registro Guardado con éxito.");
                        GridView_Proformas.DataBind();


                    }


                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

        }

        protected void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblIdProforma.Text!="0" && lblIdProforma.Text!="")
                {
                    Session["IdProforma"] = lblIdProforma.Text.Trim();
                    PopupControl_Proforma.ShowOnPageLoad = true;
                    //Session["ReportName"] = "Proforma";
                    //string host = HttpContext.Current.Request.UrlReferrer.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/Reportes/ReportViewer.aspx";
                    //Response.Redirect(host);
                }

            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Btn_Lista_Click(object sender, EventArgs e)
        {
            try
            {
                PopupControl_Lista.ShowOnPageLoad = true;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Proformas_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                lblIdProforma.Text = e.EditingKeyValue.ToString();
                CargarDatos(lblIdProforma.Text.Trim());
                Btn_Imprimir.Enabled = true;
                PopupControl_Lista.ShowOnPageLoad = false;
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

        }
    }
}