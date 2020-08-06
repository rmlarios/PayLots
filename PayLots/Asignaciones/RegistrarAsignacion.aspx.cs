using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cls_GENERAL;
using PayLots.Clases;
using PayLots.Asignaciones;
using PayLots.Beneficiarios;
using DevExpress.Web;

namespace PayLots.Asignaciones
{
    public partial class RegistrarAsignacion : System.Web.UI.Page
    {
        Cls_General FG = new Cls_General();
        Negocio Neg = new Negocio();
        Toast Toast = new Toast();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name=="")
                {
                    Response.Redirect("~/Account/Login.aspx");
                    return;
                }
                if (!IsPostBack)
                {
                    if (Session["RegistrarAsignacion"] == null || Session["RegistrarAsignacion"] == "")
                    {
                        //Response.Redirect("~/Default.aspx", true);
                    }
                    else
                    {
                        lblIdAsignacion.Text = Session["RegistrarAsignacion"].ToString();
                        Session["RegistrarAsignacion"]="";
                    }

                    //NUEVA ASIGNACION
                    if (lblIdAsignacion.Text == "0")
                        LimpiarCampos();
                    else
                        CargarDatos(lblIdAsignacion.Text.Trim());
                }
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "active", "SetActiveMenu('RegistrarPago');", true);
                ASPxNavBar navMain = (this.Master.FindControl("LeftPanel").FindControl("nbMain") as ASPxNavBar);
                if (navMain != null)
                {
                    navMain.Groups.FindByName("Asignaciones").Expanded = true;
                    navMain.SelectedItem = navMain.Items.FindByName("RegistrarAsignacion");
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
            

        }

        #region::::::::::::::::::::FUNCIONES::::::::::::::::::::
        public void LimpiarCampos()
        {
            try
            {
                ComboBox_Lotes.Text = "";
                ComboBox_Beneficiarios.Text = "";
                SpinEdit_Monto.Text = "";
                SpinEdit_Cuota.Text = "";
                SpinEdit_Prima.Text = "";
                DateEdit_FechaPago.Text = "";
                TextBox_Observaciones.Text = "";
                CheckBox_Donado.Checked = false;
                CheckBox_AplicaInteres.Checked = false;
                CheckBox_AplicaMora.Checked = false;
                SpinEdit_TasaInteres.Text = "";
                SpinEdit_PlazoMeses.Text = "";
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void HabilitarCampos(Boolean opcion)
        {
            try
            {
                ComboBox_Lotes.Enabled = opcion;
                ComboBox_Beneficiarios.Enabled = opcion;
                SpinEdit_Monto.Enabled = opcion;
                SpinEdit_Cuota.Enabled = opcion;
                SpinEdit_Prima.Enabled = opcion;
                DateEdit_FechaPago.Enabled = opcion;
                TextBox_Observaciones.Enabled = opcion;
                CheckBox_Donado.Enabled = opcion;
                CheckBox_AplicaInteres.Enabled = opcion;
                CheckBox_AplicaMora.Enabled = opcion;
                
                SpinEdit_TasaInteres.Enabled = false;
                SpinEdit_PlazoMeses.Enabled = false;

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void AplicarInteres()
        {
            try
            {
                if (CheckBox_AplicaInteres.Checked == true)
                {
                    SpinEdit_PlazoMeses.Enabled = true;
                    SpinEdit_TasaInteres.Enabled = true;
                    SpinEdit_Cuota.Enabled = false;
                }
                else if (CheckBox_AplicaInteres.Checked == false)
                {
                    SpinEdit_PlazoMeses.Enabled = false;
                    SpinEdit_TasaInteres.Enabled = false;
                    SpinEdit_Cuota.Enabled = true;
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        public void CargarDatos(string IdAsignacion)
        {
            try
            {
                clsAsignaciones Asignacion = new clsAsignaciones();
                Asignacion = Neg.CargarAsignacion(IdAsignacion);
                if (Asignacion.IdAsignacion != 0)
                {
                    ComboBox_Lotes.Value = Asignacion.IdLote;
                    ComboBox_Beneficiarios.Value = Asignacion.IdBeneficiario;
                    SpinEdit_Monto.Value = Asignacion.MontoTotal;
                    SpinEdit_Cuota.Value = Asignacion.CuotaMinima;
                    SpinEdit_Prima.Value = Asignacion.Prima;
                    DateEdit_FechaPago.Text = Asignacion.FechaInicioPago.ToString() != "" ? Convert.ToDateTime(Asignacion.FechaInicioPago.ToString()).ToShortDateString() : "";
                    TextBox_Observaciones.Text = Asignacion.Observaciones;
                    CheckBox_Donado.Checked = Asignacion.Donado;
                    CheckBox_AplicaInteres.Checked = Asignacion.AplicaInteres;
                    CheckBox_AplicaMora.Checked = Asignacion.AplicaMora;
                    SpinEdit_PlazoMeses.Value = Asignacion.PlazoMeses;
                    SpinEdit_TasaInteres.Value = Asignacion.TasaInteres;
                    SpinEdit_PlazoMeses.Enabled = Asignacion.AplicaInteres;
                    SpinEdit_TasaInteres.Enabled = Asignacion.AplicaInteres;
                    AplicarInteres();
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::

                
        #region:::::::::::::::::::::::::POPUP AGREGAR BENEFICARIOS:::::::::::::::::::::::::::
        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_Nombre.Text == "" || TextBox_Cedula.Text == "" || TextBox_Telefono.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar todos los campos obligatorios.');", true);
                    return;
                }
                clsBeneficiarios Beneficiario = new clsBeneficiarios();
                Beneficiario.IdBeneficiario = 0;
                Beneficiario.NombreCompleto = TextBox_Nombre.Text.Trim();
                Beneficiario.CedulaIdentidad = TextBox_Cedula.Text.Trim();
                Beneficiario.Telefono = TextBox_Telefono.Text.Trim();
                Beneficiario.Direccion = Memo_Direccion.Text.Trim();
                FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                string IdNuevo = Neg.AgregarActualizarBeneficiario(Beneficiario, IdentityUser);
                string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                if (MsjSQL != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('" + MsjSQL + "');", true);
                    return;
                }
                else
                {
                    ComboBox_Beneficiarios.DataBind();
                    ComboBox_Beneficiarios.Value = IdNuevo;
                    ComboBox_Beneficiarios.Text = Beneficiario.NombreCompleto;
                    ASPxPopup_Beneficiarios.ShowOnPageLoad = false;
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            TextBox_Nombre.Text = "";
            TextBox_Cedula.Text = "";
            TextBox_Telefono.Text = "";
            Memo_Direccion.Text = "";
            ASPxPopup_Beneficiarios.ShowOnPageLoad = false;
        }
        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


        #region:::::::::::::::::::::EVENTOS CONTROLES::::::::::::::::::::::::::::::
        //Boton Agregar Nuevo Beneficiario
        protected void ComboBox_Beneficiarios_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
        {
            TextBox_Nombre.Text = "";
            TextBox_Cedula.Text = "";
            TextBox_Telefono.Text = "";
            Memo_Direccion.Text = "";
            ASPxPopup_Beneficiarios.ShowOnPageLoad = true;
        }
        //Boton Guardar ASIGNACION
        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if (ComboBox_Lotes.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Seleccione el lote');", true);
                        return;
                    }
                    if (ComboBox_Beneficiarios.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Seleccione el Beneficiario');", true);
                        return;
                    }
                    if (SpinEdit_Monto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Ingrese el Monto del Lote');", true);
                        return;
                    }
                    if (DateEdit_FechaPago.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Ingrese la Fecha de la primer cuota');", true);
                        return;
                    }
                   
                    if(CheckBox_AplicaInteres.Checked==true)
                    {   
                        if(SpinEdit_PlazoMeses.Text=="")
                        {
                            Toast.ShowToast(this, Toast.ToastType.Error, "Ingrese el Plazo del Financiamiento.");
                            return;
                        }
                        if(SpinEdit_TasaInteres.Text=="")
                        {
                            Toast.ShowToast(this, Toast.ToastType.Error, "Ingrese la Tasa de Interés a aplicar.");
                            return;
                        }
                    }
                    else
                    {
                        if (SpinEdit_Cuota.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Ingrese el valor de la Cuota Mínima');", true);
                            return;
                        }
                }

                    clsAsignaciones Asignacion = new clsAsignaciones();
                    if (lblIdAsignacion.Text == "0")
                        Asignacion.IdAsignacion = 0;
                    else
                        Asignacion.IdAsignacion = Convert.ToInt32(lblIdAsignacion.Text);

                    Asignacion.IdLote = Convert.ToInt32(ComboBox_Lotes.Value);
                    Asignacion.IdBeneficiario = Convert.ToInt32(ComboBox_Beneficiarios.Value);
                    Asignacion.MontoTotal = Convert.ToDouble(SpinEdit_Monto.Value);
                    Asignacion.FechaInicioPago = DateEdit_FechaPago.Date;
                    Asignacion.CuotaMinima = CheckBox_AplicaInteres.Checked ? 0 : Convert.ToDouble(SpinEdit_Cuota.Value);
                    Asignacion.Prima = SpinEdit_Prima.Text != "" ? Convert.ToDouble(SpinEdit_Prima.Value) : 0;
                    Asignacion.Donado = CheckBox_Donado.Checked;
                    Asignacion.AplicaMora = CheckBox_AplicaMora.Checked;
                    Asignacion.TasaInteres = CheckBox_AplicaInteres.Checked ? Convert.ToDouble(SpinEdit_TasaInteres.Value) : 0;
                    Asignacion.PlazoMeses = CheckBox_AplicaInteres.Checked ? Convert.ToInt32(SpinEdit_PlazoMeses.Value) : 0;
                    Asignacion.AplicaInteres = CheckBox_AplicaInteres.Checked;
                    Asignacion.Observaciones = TextBox_Observaciones.Text;
                    FG._NombreUsuario = HttpContext.Current.User.Identity.Name;
                    string IdentityUser = FG.CrearIdentificadorUsuario(FG._NombreUsuario);
                    string IdNuevo = Neg.AgregarActualizarAsignacion(Asignacion, IdentityUser);
                    string MsjSQL = FG.Obtener_MensajeSQL(IdentityUser);
                    if (MsjSQL != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + MsjSQL + "');", true);
                        return;
                    }
                    else
                    {
                        lblIdAsignacion.Text = IdNuevo;
                        CargarDatos(IdNuevo);
                        GridView_PlanPago.DataBind();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Registro guardado con exito.');", true);
                        return;
                    }


              
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        //Boton iniciar una nueva ASIGNACION
        protected void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                lblIdAsignacion.Text = "0";
                LimpiarCampos();
                HabilitarCampos(true);

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        protected void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
                HabilitarCampos(false);
                lblIdAsignacion.Text = "";
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
        //Cambiar check Aplicar Interes
        protected void CheckBox_AplicaInteres_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AplicarInteres();

            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        #endregion::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

       

       
    }
}