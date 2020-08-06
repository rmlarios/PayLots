using cls_GENERAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PayLots {
    public partial class Register : System.Web.UI.Page {
        Cls_General FG = new Cls_General();
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        //protected void btnCreateUser_Click(object sender, EventArgs e) {
        //    try {

        //        MembershipUser user = Membership.CreateUser(tbUserName.Text, tbPassword.Text, tbEmail.Text);
                
        //        Response.Redirect(Request.QueryString["ReturnUrl"] ?? "~/Account/RegisterSuccess.aspx");
        //    }
        //    catch (MembershipCreateUserException exc) {
        //        if (exc.StatusCode == MembershipCreateStatus.DuplicateEmail || exc.StatusCode == MembershipCreateStatus.InvalidEmail) {
        //            tbEmail.ErrorText = exc.Message;
        //            tbEmail.IsValid = false;
        //        }
        //        else if (exc.StatusCode == MembershipCreateStatus.InvalidPassword) {
        //            tbPassword.ErrorText = exc.Message;
        //            tbPassword.IsValid = false;
        //        }
        //        else {
        //            tbUserName.ErrorText = exc.Message;
        //            tbUserName.IsValid = false;
        //        }
        //    }
        //}

        protected void GridView_Usuarios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                string Usuario = e.NewValues["UserName"].ToString();
                string Email = e.NewValues["Email"].ToString();
                string Password = "Tempo@123";
                string Rol = e.NewValues["RoleName"].ToString();
                MembershipCreateStatus createStatus;
                MembershipUser user = Membership.CreateUser(Usuario, Password, Email, "Ninguna", "Ninguna", true, out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    Roles.AddUserToRole(Usuario, Rol);
                    if (Roles.IsUserInRole(Usuario, Rol))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Usuario Creado correctamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('Usuario Creado correctamente pero sin asignar Rol');", true);
                    }

                    GridView_Usuarios.CancelEdit();
                    GridView_Usuarios.DataBind();
                }
                else
                {
                    string Error = GetErrorMessage(createStatus);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msj", "alert('" + Error + "');", true);
                }
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Usuarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                SqlDataSource_Usuarios.UpdateCommand = "UPDATE [ErroresSistema] SET Error='0' where [IdErrorSistema]=0";
                //e.Cancel = true;
                string Usuario = e.NewValues["UserName"].ToString();
                string Email = e.NewValues["Email"].ToString();
                string RolAnterior = e.OldValues["RoleName"].ToString();
                string RolActual = e.NewValues["RoleName"].ToString();
                Boolean Bloqueado = Convert.ToBoolean(e.NewValues["IsLockedOut"]);
                bool Activo = Convert.ToBoolean(e.NewValues["IsApproved"]);
                MembershipUser User = Membership.GetUser(Usuario);
                string UserId = User.ProviderUserKey.ToString();

                if (User!=null)
                {
                    User.Email = Email;
                    User.IsApproved = Activo;
                    Membership.UpdateUser(User);

                    if(RolAnterior!=RolActual)
                    {
                        if (Roles.IsUserInRole(Usuario, RolAnterior))
                        {
                            Roles.RemoveUserFromRole(Usuario, RolAnterior);
                        }

                        Roles.AddUserToRole(Usuario, RolActual);
                    }
                    if (Bloqueado == false)
                    {
                        if (User.IsLockedOut)
                        {
                            User.UnlockUser();
                        }
                    }
                    else
                    {
                        FG.ExecuteSql("UPDATE [dbo].[aspnet_Membership] SET [IsLockedOut]='" + Bloqueado + "' WHERE UserId='" + UserId + "'");
                    }
                   


                }
                GridView_Usuarios.DataBind();              
                //GridView_Usuarios.CancelEdit();
               
            }
            catch (Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }

        protected void GridView_Usuarios_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                string Usuario = GridView_Usuarios.GetRowValuesByKeyValue(e.Keys["UserId"], "UserName").ToString();
                Membership.DeleteUser(Usuario);
                GridView_Usuarios.DataBind();
            }
            catch(Exception Ex)
            {
                FG.Controlador_Error(Ex, Page.Response);
            }
        }


        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El Usuario ya existe. Favor ingresar un nombre de usuario distinto.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un usuario con este Email. Favor ingresar un Email distinto.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña es invalida. Favor ingresar una contraseña valida.";

                case MembershipCreateStatus.InvalidEmail:
                    return "El Email es invalido. Favor ingresar un Email valido."; 

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta es invalida. Favor verificar e intentar otra vez.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta es invalida. Favor verificar e intentar otra vez.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El Nombre Usuario es invalido. Favor verificar e intentar otra vez.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

    }
}