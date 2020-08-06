using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PayLots.Clases;

namespace PayLots {
    public partial class Login : System.Web.UI.Page 
    {
        cls_GENERAL.Cls_General FG = new cls_GENERAL.Cls_General();
        Toast Toast = new Toast();
        protected void Page_Load(object sender, EventArgs e) 
        {
            LoginUser.Focus();    
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                //if (LoginUser.Text == "Admon" && LoginPassword.Text=="Admon")
                //{
                //    FormsAuthentication.RedirectFromLoginPage("Admon", false);
                //    return;
                //}
                
                MembershipUser User = Membership.GetUser(LoginUser.Text.Trim());
                if (User == null)
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Usuario o Contraseña Incorrectos');", true);
                    Toast.ShowToast(this, Toast.ToastType.Error, "Usuario o Contraseña Incorrectos.");
                }
                else if (Membership.ValidateUser(LoginUser.Text.Trim(), LoginPassword.Text.Trim()))
                {
                               
                    Session["NombreUsuario"] = LoginUser.Text.Trim();
                    if(Roles.GetRolesForUser(LoginUser.Text.Trim()).Count()==0)
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El Usuario no pertenece a ningún Perfil. Contacte al Administrador.');", true);
                        Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario no pertenece a ningún Perfil. Contacte al Administrador.");
                        return;
                    }

                    if (User.PasswordQuestion == "Ninguna")
                    {
                        ASPxPopupControl_Cambiar_Contraseña.ShowOnPageLoad = true;
                        BootstrapTextBox_Contraseña_Anterior_Change.Focus();
                        return;
                    }

                    string Rol = Roles.GetRolesForUser(LoginUser.Text.Trim())[0].ToString();
                    //Roles.AddUserToRole(LoginUser.Text.Trim(), "Administrador");
                    FG.Logueos_Usuarios(LoginUser.Text.Trim(),Rol);
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.Text.Trim(), false);
                }
                else if (User.IsApproved == false)
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El Usuario está inactivo contacte al Administrador.');", true);
                    Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario está inactivo contacte al Administrador.");
                    return;
                }
                else if (User.IsLockedOut)
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El Usuario está bloqueado contacte al Administrador.');", true);
                    User.UnlockUser();
                    string Rol = Roles.GetRolesForUser(LoginUser.Text.Trim())[0].ToString();
                    FG.Logueos_Usuarios(LoginUser.Text.Trim(), Rol);
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.Text.Trim(), false);
                    //Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario está bloqueado contacte al Administrador.");
                    //return;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Usuario o Contraseña Incorrectos');", true);
                    Toast.ShowToast(this, Toast.ToastType.Error, "Usuario o Contraseña Incorrectos.");
                    return;
                }
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }

            
        }

        protected void LinkButton_Recup_Contra_Click(object sender, EventArgs e)
        {
            if (LoginUser.Text.Trim() != "")
            {
                ASPxPopupControl_Recuperar_Contraseña.ShowOnPageLoad = true;
                ASPxRoundPanel_Paso1.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar un nombre de usuario.');", true);
                return;
            }
        }

        protected void Button_Pregunta_Click(object sender, EventArgs e)
        {
            if(BootstrapComboBox_Pregunta.Text=="" || BootstrapComboBox_Pregunta.SelectedIndex==-1)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe seleccionar una pregunta.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Debe seleccionar una pregunta.");
                return;
            }

            if(BootstrapTextBox_Respuesta.Text=="")
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar una respuesta.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar una respuesta.");
                return;
            }

            MembershipUser User = Membership.GetUser(LoginUser.Text.Trim());
            if(User!=null)
            {
                string UserId = User.ProviderUserKey.ToString();
                if (User.PasswordQuestion == BootstrapComboBox_Pregunta.Text.Trim())
                {
                   // User.ChangePasswordQuestionAndAnswer("Yahir*85", "Ninguna", "Ninguna");
                   if(FG.ValidarRespuesta(UserId,BootstrapTextBox_Respuesta.Text.Trim())==true)
                   {
                        ASPxRoundPanel_Paso1.Visible = false;
                        ASPxRoundPanel_Paso2.Enabled = true;
                        ASPxRoundPanel_Paso2.Visible = true;
                        BootstrapTextBox_NuevaContraseña.Focus();
                   }
                   else
                   {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Pregunta o Respuesta Incorrectas.');", true);
                        Toast.ShowToast(this, Toast.ToastType.Error, "Pregunta o Respuesta Incorrectas.");
                        return;
                   }
                   
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Pregunta o Respuesta Incorrectas.');", true);
                    Toast.ShowToast(this, Toast.ToastType.Error, "Pregunta o Respuesta Incorrectas.");
                    return;
                }
            }
        }

        protected void Button_NuevaContraseña_Click(object sender, EventArgs e)
        {
            if(BootstrapTextBox_NuevaContraseña.Text.Trim()=="")
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Ingrese la Nueva Contraseña.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Ingrese la Nueva Contraseña.");
                return;
            }

            if (BootstrapTextBox_ConfirmarContraseña.Text.Trim() == "")
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Ingrese la Confirmación de la Nueva Contraseña.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Ingrese la Confirmación de la Nueva Contraseña.");
                return;
            }

            if (FG.ValidarPassword(BootstrapTextBox_NuevaContraseña.Text.Trim()) == false)
            {
                Label_Mensaje_NuevaContra.Text = "Mensaje: La nueva constraseña no cumple con los requisitos de longitud y complejidad. Esta debe contener un mínimo de 8 caracteres incluyendo Mayúscula, Minúscula, Caracter especial y Número.";
                return;
            }

            if(BootstrapTextBox_NuevaContraseña.Text.Trim()!=BootstrapTextBox_ConfirmarContraseña.Text.Trim())
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Las contraseñas no coinciden.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Las contraseñas no coinciden.");
                return;
            }

            string NuevaContraseña = BootstrapTextBox_NuevaContraseña.Text.Trim();           

            MembershipUser User = Membership.GetUser(LoginUser.Text.Trim());
            if (User.IsLockedOut)
            {
                User.UnlockUser();
            }

            User.ChangePassword(User.ResetPassword(), NuevaContraseña);
            if(Membership.ValidateUser(LoginUser.Text.Trim(),NuevaContraseña))
            {
                if (Roles.GetRolesForUser(LoginUser.Text.Trim()).Count() == 0)
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El Usuario no pertenece a ningún Perfil. Contacte al Administrador.');", true);
                    Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario no pertenece a ningún Perfil. Contacte al Administrador.");
                    return;
                }
                string Rol = Roles.GetRolesForUser(LoginUser.Text.Trim())[0].ToString();
                FG.Logueos_Usuarios(LoginUser.Text.Trim(), Rol);
                FormsAuthentication.RedirectFromLoginPage(LoginUser.Text.Trim(), false);
            }
            else if (User.IsApproved == false)
            {
                Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario está Deshabilitado del sistema. Contacte al Administrador.");
                return;
            }


        }

        protected void Button_Continuar_Change_Click(object sender, EventArgs e)
        {
            if (BootstrapTextBox_Contraseña_Anterior_Change.Text.Trim()=="")
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar la contraseña actual.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar la contraseña actual.");
                return;
            }

            if (BootstrapTextBox_Nueva_Contraseña_change.Text.Trim()=="" || BootstrapTextBox_Confirmar_Contra_Change.Text.Trim()=="")
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Debe ingresar la nueva contraseña y su confirmacion.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Debe ingresar la nueva contraseña y su confirmacion.");
                return;
            }

            if(FG.ValidarPassword(BootstrapTextBox_Nueva_Contraseña_change.Text.Trim())==false)
            {
                Label_Mensaje_NuevaContra_Change.Text = "Mensaje: La nueva constraseña no cumple con los requisitos de longitud y complejidad. Esta debe contener un mínimo de 8 caracteres incluyendo Mayúscula, Minúscula, Caracter especial y Número.";
                return;
            }

            if(BootstrapTextBox_Nueva_Contraseña_change.Text.Trim()!= BootstrapTextBox_Confirmar_Contra_Change.Text.Trim())
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('Las contraseñas no coinciden.');", true);
                Toast.ShowToast(this, Toast.ToastType.Error, "Las contraseñas no coinciden.");
                return;
            }
            MembershipUser User = Membership.GetUser(LoginUser.Text.Trim());
            if (User.IsLockedOut)
            {
                User.UnlockUser();
            }
            if(Membership.ValidateUser(LoginUser.Text.Trim(),BootstrapTextBox_Contraseña_Anterior_Change.Text.Trim()))
            {
                
                string ContraseñaAnterior = BootstrapTextBox_Contraseña_Anterior_Change.Text.Trim();
                string NuevaContraseña = BootstrapTextBox_Nueva_Contraseña_change.Text.Trim();
                if (User!=null)
                {
                    User.ChangePassword(ContraseñaAnterior, NuevaContraseña);
                    User.ChangePasswordQuestionAndAnswer(NuevaContraseña, BootstrapComboBox_Pregunta_Change.Text.Trim(), BootstrapTextBox_Respuesta_Change.Text.Trim());
                    if (Roles.GetRolesForUser(LoginUser.Text.Trim()).Count() == 0)
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('El Usuario no pertenece a ningún Perfil. Contacte al Administrador.');", true);
                        Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario no pertenece a ningún Perfil. Contacte al Administrador.");
                        return;
                    }

                    string Rol = Roles.GetRolesForUser(LoginUser.Text.Trim())[0].ToString();
                    //Roles.AddUserToRole(LoginUser.Text.Trim(), "Administrador");
                    FG.Logueos_Usuarios(LoginUser.Text.Trim(), Rol);
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.Text.Trim(), false);


                }
            }
            else if (User.IsApproved == false)
            {
                Toast.ShowToast(this, Toast.ToastType.Error, "El Usuario está Deshabilitado del sistema. Contacte al Administrador.");
                return;
            }
        }

        //protected void btnLogin_Click(object sender, EventArgs e) {
        //    if (Membership.ValidateUser(tbUserName.Text, tbPassword.Text)) {
        //        if(string.IsNullOrEmpty(Request.QueryString["ReturnUrl"])) {
        //            FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
        //            Response.Redirect("~/");
        //        }
        //        else
        //            FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
        //    }
        //    else {
        //        tbUserName.ErrorText = "Invalid user";
        //        tbUserName.IsValid = false;
        //    }
        //}
    }
}