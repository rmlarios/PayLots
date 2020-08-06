using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;
using cls_GENERAL;

namespace PayLots {
    public partial class ChangePassword : System.Web.UI.Page {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!IsPostBack)
                {
                    byte[] Avatar = ASPxBinaryImage1.ContentBytes;
                    ProfileBase profile = HttpContext.Current.Profile;
                    byte[] avatar = (byte[])profile.GetPropertyValue("Avatar");
                    ASPxBinaryImage1.ContentBytes = avatar;
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e) {
            try
            {
                MembershipUser user = Membership.GetUser(User.Identity.Name);
                if (!Membership.ValidateUser(user.UserName, tbCurrentPassword.Text))
                {
                    tbCurrentPassword.ErrorText = "Contraseña Anterior Incorrecta";
                    tbCurrentPassword.IsValid = false;
                }
                else if (!user.ChangePassword(tbCurrentPassword.Text, tbPassword.Text))
                {
                    tbPassword.ErrorText = "Nueva Contraseña no Válida.";
                    tbPassword.IsValid = false;
                }
                else
                {
                    if (Check_CambiarPregunta.Checked == true)
                    {
                        if (BootstrapComboBox_Pregunta_Change.Text == "" || BootstrapTextBox_Respuesta_Change.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert(Debe seleccionar una Pregunta y Respuesta Secreta);", true);
                            return;
                        }
                        if (!user.ChangePasswordQuestionAndAnswer(tbPassword.Text, BootstrapComboBox_Pregunta_Change.Text, BootstrapTextBox_Respuesta_Change.Text.Trim()))
                        {

                        }
                        else
                            Response.Redirect("~/");
                    }
                    Response.Redirect("~/");
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void Check_CambiarPregunta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Check_CambiarPregunta.Checked == true)
                {
                    BootstrapComboBox_Pregunta_Change.ClientVisible = true;
                    BootstrapTextBox_Respuesta_Change.ClientVisible = true;
                }
                else
                {
                    BootstrapComboBox_Pregunta_Change.ClientVisible = false;
                    BootstrapTextBox_Respuesta_Change.ClientVisible = false;
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

       
        protected void ASPxBinaryImage1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] Avatar = ASPxBinaryImage1.ContentBytes;
                ProfileBase profile = HttpContext.Current.Profile;
                profile.SetPropertyValue("Avatar", Avatar);
                profile.Save();
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }
    }
}