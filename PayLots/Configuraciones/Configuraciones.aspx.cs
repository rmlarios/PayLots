using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Configuraciones;
using PayLots.Clases;
using System.IO;
using System.Data;

namespace PayLots.Configuraciones
{
    public partial class Configuraciones : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        Toast Toast = new Toast();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarDatosEmpresa();

            }
            if(HttpContext.Current.User.Identity.Name=="")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            CargarRespaldos();
            if (User.IsInRole("Visualizador"))
                ASPxFloatingActionButton1.Visible = false;
            else
                ASPxFloatingActionButton1.Visible = true;
        }

        public void CargarRespaldos()
        {
            try
            {
                DataTable Data = new DataTable();
                Data.Columns.Add("NombreArchivo");
                Data.Columns.Add("FechaCreacion");
                string Ruta = HttpContext.Current.Server.MapPath(@"~\App_Data\Respaldos");
                if (System.IO.Directory.Exists(Ruta))
                {
                    string[] files = System.IO.Directory.GetFiles(Ruta, "*.bak");
                    foreach (string s in files)
                    {
                        if (System.IO.File.Exists(s))
                        {
                            FileInfo Info = new FileInfo(s);
                            string NombreArchivo = s.Replace(Ruta, "").Replace("\\","");
                            string FechaCreacion= Info.CreationTime.ToString();
                            Info.Length.ToString();
                            //ListReportes.Items.Add(s.Replace(Ruta, ""), s.Replace(Ruta, ""), "~/Content/report-icon-32.jpg");
                            Data.Rows.Add(new Object[] { NombreArchivo,FechaCreacion });


                        }
                    }
                    GridView_Respaldos.DataSource = Data;
                    GridView_Respaldos.DataBind();

                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        public void CargarDatosEmpresa()
        {
            clsDatosEmpresa DatosEmpresa = new clsDatosEmpresa();
            DatosEmpresa = Neg.CargarDatosEmpresa();
            if (DatosEmpresa.NombreEmpresa!="Empty")
            {
                TextBox_NombreEmpresa.Text = DatosEmpresa.NombreEmpresa;
                TextBox_Direccion.Text = DatosEmpresa.Direccion;
                TextBox_Teléfono.Text = DatosEmpresa.Telefono;
                TextBox_Email.Text = DatosEmpresa.Email;
                TextBox_Ruc.Text = DatosEmpresa.Ruc;
                if (DatosEmpresa.Logo != null)
                    BinaryImage_Logo.ContentBytes = DatosEmpresa.Logo;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(TextBox_NombreEmpresa.Text=="")
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Ingrese el nombre de la empresa');", true);
                    Toast.ShowToast(this, Toast.ToastType.Error, "Ingrese el nombre de la empresa.","",Toast.ToastPosition.BottomStretch);
                    return;
                }

                if(TextBox_Direccion.Text=="")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Ingrese el nombre de la empresa');", true);
                    return;
                }


                clsDatosEmpresa DatosEmpresa = new clsDatosEmpresa();
                DatosEmpresa.NombreEmpresa = TextBox_NombreEmpresa.Text.Trim();
                DatosEmpresa.Direccion = TextBox_Direccion.Text.Trim();
                DatosEmpresa.Telefono = TextBox_Teléfono.Text.Trim();
                DatosEmpresa.Email = TextBox_Email.Text.Trim();
                DatosEmpresa.Ruc = TextBox_Ruc.Text.Trim();
                DatosEmpresa.Logo = BinaryImage_Logo.ContentBytes;
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                Neg.AgregarActualizarDatosEmpresa(DatosEmpresa, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if(MsjSQL!="")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('"+ MsjSQL +"');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Datos Guardado Correctamente');", true);
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                FG.IniciarProcedimiento("CambiarIdioma");
                FG.EjecutarProcedimiento();
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Btn_Respaldar_Click(object sender, EventArgs e)
        {
            try
            {
                string Ruta = HttpContext.Current.Server.MapPath(@"~\App_Data\Respaldos");
                FG.IniciarProcedimiento("BK");
                FG.AgregarParametroProcedimiento("@Path", System.Data.SqlDbType.NVarChar, Ruta);
                var result = FG.EjecutarProcedimiento();
                if (result != null)
                {

                    MemoryStream m = new MemoryStream();
                    Ruta = Ruta + "\\" + result.ToString();
                    byte[] reportContent = System.IO.File.ReadAllBytes(Ruta);
                    Response.ContentType = "application/pdf";
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}", "attachment", result.ToString()));
                    Response.BinaryWrite(reportContent);
                    Response.End();
                    CargarRespaldos();
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}