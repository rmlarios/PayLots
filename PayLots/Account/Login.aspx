<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PayLots.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Login</title>
	<meta charset="UTF-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../Content/toastr.min.css" rel="stylesheet" />
    <script src="../Scripts/scriptToast.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/toastr.min.js"></script>
    <script type="text/javascript">
    
    </script>

    <style>

        .fade-in {
            opacity: 0; /* make things invisible upon start */
            -webkit-animation: fadeIn ease-in 1; /* call our keyframe named fadeIn, use animattion ease-in and repeat it only 1 time */
            -moz-animation: fadeIn ease-in 1;
            animation: fadeIn ease-in 1;
            -webkit-animation-fill-mode: forwards; /* this makes sure that after animation is done we remain at the last keyframe value (opacity: 1)*/
            -moz-animation-fill-mode: forwards;
            animation-fill-mode: forwards;
            -webkit-animation-duration: 1.5s;
            -moz-animation-duration: 1.5s;
            animation-duration: 1.5s;
        }

        .limiter {
            width: 100%;
            margin: 0 auto;
        }

        .container-login100 {
            width: 100%;
            min-height: 100vh;
            display: -webkit-box;
            display: -webkit-flex;
            display: -moz-box;
            display: -ms-flexbox;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            align-items: center;
            padding: 15px;
            background: #cfcfcf;
        }

        .wrap-login100 {
            width: 350px;
            background: #fff;
            /*border-radius: 10px;*/
            overflow: hidden;
            padding: 77px 55px 33px 55px;
            box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
            -moz-box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
            -webkit-box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
            -o-box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
            -ms-box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
        }

        /*----------[ Form ]*/

        .login100-form {
            width: 100%;
        }

        .login100-form-title {
            display: block;
            font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-weight:bold;
            font-size: 30px;
            color: #333333;
            line-height: 1.2;
            text-align: center;
        }

        .login100-form-title i {
                font-size: 60px;
            }

        /*------------------------------------------------------------------*/

        /*------------------------------------------------------------------
[ Input ]*/

        .wrap-input100 {
            width: 100%;
            position: relative;
            /*border-bottom: 2px solid #adadad;*/
            margin-bottom: 37px;
        }

        .input100 {
            font-family: Poppins-Regular;
            font-size: 15px;
            color: #555555;
            line-height: 1.2;
            display: block;
            width: 100%;
            height: 45px;
            background: transparent;
            padding: 0 5px;
        }

        /*---------------------------------------------*/


        /*------------------------------------------------------------------
[ Button ]*/
        .container-login100-form-btn {
            display: -webkit-box;
            display: -webkit-flex;
            display: -moz-box;
            display: -ms-flexbox;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            padding-top: 13px;
        }

        .wrap-login100-form-btn {
            width: 100%;
            display: block;
            position: relative;
            z-index: 1;
            border-radius: 25px;
            overflow: hidden;
            margin: 0 auto;
        }

        .login100-form-bgbtn {
            position: absolute;
            z-index: -1;
            width: 300%;
            height: 100%;
            background: #a64bf4;
            background: -webkit-linear-gradient(right, #21d4fd, #b721ff, #21d4fd, #b721ff);
            background: -o-linear-gradient(right, #21d4fd, #b721ff, #21d4fd, #b721ff);
            background: -moz-linear-gradient(right, #21d4fd, #b721ff, #21d4fd, #b721ff);
            background: linear-gradient(right, #21d4fd, #b721ff, #21d4fd, #b721ff);
            top: 0;
            left: -100%;
            -webkit-transition: all 0.4s;
            -o-transition: all 0.4s;
            -moz-transition: all 0.4s;
            transition: all 0.4s;
        }

        .login100-form-btn {
            font-family: Poppins-Medium;
            
            font-size: 15px;
            color: #fff;
            line-height: 1.2;
            text-transform: uppercase;
            display: -webkit-box;
            display: -webkit-flex;
            display: -moz-box;
            display: -ms-flexbox;
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 0 20px;
            width: 100%;
            height: 50px;
        }

        .wrap-login100-form-btn:hover .login100-form-bgbtn {
            left: 0;
        }


        /*------------------------------------------------------------------*/
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .field-icon {
        float: right;
        margin-left: -25px;
        margin-top: -25px;
        margin-right: 5px;
        position: relative;
        z-index: 4;
        height: auto;
    }


        @-webkit-keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

        @-moz-keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }


    </style>

</head>


<%--<body style=" height:100%;position:relative; background: rgba(147,206,222,1);
background: -moz-linear-gradient(top, rgba(147,206,222,1) 0%, rgba(117,189,209,1) 35%, rgba(73,165,191,1) 100%);
background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(147,206,222,1)), color-stop(35%, rgba(117,189,209,1)), color-stop(100%, rgba(73,165,191,1)));
background: -webkit-linear-gradient(top, rgba(147,206,222,1) 0%, rgba(117,189,209,1) 35%, rgba(73,165,191,1) 100%);
background: -o-linear-gradient(top, rgba(147,206,222,1) 0%, rgba(117,189,209,1) 35%, rgba(73,165,191,1) 100%);
background: -ms-linear-gradient(top, rgba(147,206,222,1) 0%, rgba(117,189,209,1) 35%, rgba(73,165,191,1) 100%);
background: linear-gradient(to bottom, rgba(147,206,222,1) 0%, rgba(117,189,209,1) 35%, rgba(73,165,191,1) 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#93cede', endColorstr='#49a5bf', GradientType=0 );">--%>

<body style="background-repeat: repeat; background-image:linear-gradient(rgb(10, 42, 63), rgb(45, 66, 107));height: -webkit-fill-available;background-attachment:fixed">

<%--<h2 style="text-align:center;color:antiquewhite;text-shadow:inherit 20px 20px 20px 20px;">Sistema de Control de Pagos</h2>--%>
<form id="form1" runat="server">


    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>

    	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 fade-in">
				<div class="login100-form validate-form">
					<span class="login100-form-title p-b-26">
						Sistema de Control de Pagos
					</span>
					<div class="login100-form-title p-b-48">
                        <div class="imgcontainer">
                            <img src="../Content/Imagenes/img_avatar2.png" alt="Avatar" class="avatar" />
                        </div>
					</div>

					<div class="wrap-input100 validate-input">
                        <dx:BootstrapTextBox ID="LoginUser" ClientInstanceName="bstLoginUser" runat="server" NullText="Ingrese Usuario" Width="98%">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" ErrorText="" />
                            </ValidationSettings>
                        </dx:BootstrapTextBox>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
                        
                        <dx:BootstrapTextBox ID="LoginPassword" ClientInstanceName="bstLoginPassword" runat="server" NullText="Ingrese Contraseña" Password="True" Width="98%" MaxLength="15">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:BootstrapTextBox>
                        <span toggle="#bstLoginPassword" style="height: auto" class="fa fa-fw fa-eye field-icon toggle-password"></span>
					</div>

					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"> </div>
                            <asp:UpdatePanel runat="server" ID="UdpLogin"><ContentTemplate>
                            <dx:BootstrapButton ID="LoginButton" OnClick="LoginButton_Click" runat="server" AutoPostBack="false" Width="100%" Text="Iniciar Sesión">
                                <CssClasses Control="login100-form-btn"/>
                                <SettingsBootstrap RenderOption="Success"/>
                                <ClientSideEvents Click="function(s,e){
                                    if(bstLoginUser.GetText()!='' && bstLoginPassword.GetText()!='')
                                        s.SetText('Conectando...');
                                    }" />
                            </dx:BootstrapButton>
                               </ContentTemplate></asp:UpdatePanel>
						</div>
					</div>

					<div class="p-t-115" style="text-align:center;">
						<span class="txt1">
							<asp:LinkButton Visible="true" ID="LinkButton_Recup_Contra" runat="server" OnClick="LinkButton_Recup_Contra_Click" ForeColor="#0099FF" TabIndex="-1">Recuperar Contraseña</asp:LinkButton>
						</span>
                        						
					</div>
				</div>
			</div>
		</div>
	</div>
              
    
    <asp:UpdatePanel ID="UdpPopup1" runat="server"><ContentTemplate>
         <dx:ASPxPopupControl ID="ASPxPopupControl_Recuperar_Contraseña" runat="server" AutoUpdatePosition="True" ClientInstanceName="popuprecupcontra" CloseAction="CloseButton" HeaderText="Recuperar Contraseña" Height="100%" MaxHeight="480px" MinHeight="350px" MinWidth="600px" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" TabIndex="-1" Theme="MaterialCompact" Width="85%" EnableHierarchyRecreation="False">
                <ContentStyle Wrap="True">
                </ContentStyle>
                <HeaderStyle HorizontalAlign="Center" />
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">

                        <dx:ASPxRoundPanel ID="ASPxRoundPanel_Paso1" runat="server" EnableHierarchyRecreation="False" ShowHeader="False" Theme="MaterialCompact" Width="100%">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <div align="Right" style="font-weight: 700">
                                        PASO 1/2
                                    </div>
                                    <div align="center" style="font-size: medium">
                                        Seleccione su Pregunta Secreta<br />
                                        <br />
                                    </div>
                                    <div align="center">
                                        <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel1" runat="server">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <dx:BootstrapComboBox ID="BootstrapComboBox_Pregunta" NullText="Seleccione su pregunta secreta" runat="server" DataSourceID="SqlDataSource_Preguntas" TextField="Pregunta">
                                                        <ClearButton DisplayMode="Always" />
                                                    </dx:BootstrapComboBox>
                                                    <asp:SqlDataSource ID="SqlDataSource_Preguntas" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [Pregunta] FROM [Catalogo_Preguntas]"></asp:SqlDataSource>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:BootstrapCallbackPanel>
                                        <br />
                                    </div>
                                     <div align="center">
                                        <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel3" runat="server">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <dx:BootstrapTextBox ID="BootstrapTextBox_Respuesta" Width="100%" NullText="Ingrese su respuesta secreta" runat="server"></dx:BootstrapTextBox>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:BootstrapCallbackPanel>
                                        <br />
                                    </div>
                                    <div>
                                        <div align="left" style="text-align: center; width: 100%;">
                                            <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel2" runat="server">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <asp:Label ID="Label_Mensaje_Pregunta" runat="server" Style="font-size: medium"></asp:Label>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapCallbackPanel>
                                            <br />
                                        </div>
                                    </div>
                                    <div style="text-align:center">
                                        <asp:Button ID="Button_Pregunta" runat="server" OnClick="Button_Pregunta_Click" CssClass="btn btn-primary" Style="max-width: 150px" Text="Continuar" UseSubmitBehavior="False" Width="100%" />
                                    </div>
                        <br />
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                         <dx:ASPxRoundPanel ID="ASPxRoundPanel_Paso2" Visible="false" Enabled="false" runat="server" EnableHierarchyRecreation="False" ShowHeader="False" Theme="MaterialCompact" Width="100%">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <div align="Right" style="font-weight: 700">
                                        PASO 2/2
                                    </div>
                                    <div align="center" style="font-size: medium">
                                        Ingrese la Nueva Contraseña<br />
                                        <br />
                                    </div>
                                    <div align="center">
                                        <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel4" runat="server">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <dx:BootstrapTextBox ID="BootstrapTextBox_NuevaContraseña" Width="100%" NullText="Ingrese su nueva contraseña" Password="true" runat="server"></dx:BootstrapTextBox>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:BootstrapCallbackPanel>
                                        <br />
                                    </div>
                                     <div align="center">
                                        <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel5" runat="server">
                                            <ContentCollection>
                                                <dx:ContentControl runat="server">
                                                    <dx:BootstrapTextBox ID="BootstrapTextBox_ConfirmarContraseña" Width="100%" NullText="Confirme la nueva contraseña" Password="true" runat="server"></dx:BootstrapTextBox>
                                                </dx:ContentControl>
                                            </ContentCollection>
                                        </dx:BootstrapCallbackPanel>
                                        <br />
                                    </div>
                                    <div>
                                        <div align="left" style="text-align: center; width: 100%;">
                                            <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel6" runat="server">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <asp:Label ID="Label_Mensaje_NuevaContra" runat="server" Style="font-size: medium"></asp:Label>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapCallbackPanel>
                                            <br />
                                        </div>
                                    </div>
                                    <div style="text-align:center">
                                        <asp:Button ID="Button_NuevaContraseña" runat="server" OnClick="Button_NuevaContraseña_Click" CssClass="btn btn-primary" Style="max-width: 250px" Text="Cambiar Contraseña" UseSubmitBehavior="False" Width="100%" />
                                    </div>
                        <br />
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
             </dx:ASPxPopupControl>
    </ContentTemplate></asp:UpdatePanel>
    <asp:UpdatePanel ID="UdpPopup2" runat="server"><ContentTemplate>
         <dx:ASPxPopupControl ID="ASPxPopupControl_Cambiar_Contraseña" runat="server" AutoUpdatePosition="True" ClientInstanceName="popupcambiarcontra" CloseAction="CloseButton" HeaderText="Cambiar Contraseña" Height="100%" MaxHeight="480px" MinHeight="350px" MinWidth="600px" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" TabIndex="-1" Theme="MaterialCompact" Width="85%" EnableHierarchyRecreation="False">
                <ContentStyle Wrap="True">
                </ContentStyle>
                <HeaderStyle HorizontalAlign="Center" />
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <div class="conte"></div>
                        <div align="center" class="auto-style4" style="font-size: medium">
                            <dx:ASPxLabel runat="server" ID="lblChangeTitle" Text="Cambie sus datos de acceso temporal para continuar." ForeColor="#FF9900" Font-Size="Medium" Wrap="True"></dx:ASPxLabel>
                        </div>
                        <br />
                        <br />
                        <div align="center" style="font-size: medium">
                            Ingrese su contraseña anterior:<br />
                            <br />
                        </div>
                        <div align="center">
                            <span class="style15">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <span class="style15">
                                            <dx:BootstrapTextBox ID="BootstrapTextBox_Contraseña_Anterior_Change" ClientInstanceName="Checkcontrachange1" runat="server" Password="True" MaxLength="15">
                                            </dx:BootstrapTextBox>
                                        </span>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                        <div align="center" style="font-size: medium">
                            Ingrese su nueva contraseña:<br />
                            <br />
                        </div>
                        <div align="center">
                            <span class="style15">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <span class="style15">
                                            <dx:BootstrapTextBox ID="BootstrapTextBox_Nueva_Contraseña_change" runat="server" Password="True" MaxLength="15">
                                            </dx:BootstrapTextBox>
                                        </span>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                        <div align="center" style="font-size: medium">
                            Confirmar contraseña:<br />
                            <br />
                        </div>
                        <div align="center">
                            <span class="style15">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <span class="style15">
                                            <dx:BootstrapTextBox ID="BootstrapTextBox_Confirmar_Contra_Change" runat="server" Password="True" MaxLength="15">
                                            </dx:BootstrapTextBox>
                                        </span>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                         <div align="center" style="font-size: medium">
                            Seleccione su Pregunta secreta:<br />
                            <br />
                        </div>
                        <div align="center">
                            <span class="style15">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <span class="style15">
                                             <dx:BootstrapComboBox ID="BootstrapComboBox_Pregunta_Change" NullText="Seleccione su pregunta secreta" runat="server" DataSourceID="SqlDataSource_Preguntas2" TextField="Pregunta">
                                                        <ClearButton DisplayMode="Always" />
                                                    </dx:BootstrapComboBox>
                                                    <asp:SqlDataSource ID="SqlDataSource_Preguntas2" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [Pregunta] FROM [Catalogo_Preguntas]"></asp:SqlDataSource>
                                        </span>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                        <div align="center" style="font-size: medium">
                            Respuesta secreta:<br />
                            <br />
                        </div>
                        <div align="center">
                            <span class="style15">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <span class="style15">
                                            <dx:BootstrapTextBox ID="BootstrapTextBox_Respuesta_Change" runat="server" Password="True" MaxLength="15">
                                            </dx:BootstrapTextBox>
                                        </span>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </span>
                        </div>
                        <div>
                            <div align="left" style="text-align: center; width: 100%;">
                                <dx:BootstrapCallbackPanel ID="BootstrapCallbackPanel7" runat="server">
                                    <ContentCollection>
                                        <dx:ContentControl runat="server">
                                            <asp:Label ID="Label_Mensaje_NuevaContra_Change" runat="server" Style="font-size: medium"></asp:Label>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapCallbackPanel>
                                <br />
                            </div>
                        </div>
                        <div align="center">
                            <asp:Button ID="Button_Continuar_Change" runat="server" CssClass="btn btn-primary" OnClick="Button_Continuar_Change_Click" Style="max-width: 150px" Text="Continuar" UseSubmitBehavior="False" Width="100%" />
                            <br />
                        </div>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
             </dx:ASPxPopupControl>
    </ContentTemplate></asp:UpdatePanel>
    </form>

    <script type="text/javascript" src='<%= ResolveUrl("~/Scripts/jquery-3.3.1.min.js") %>'></script>
             <script type="text/javascript">
            $(document).on('click', '.toggle-password', function () {

                $(this).toggleClass("fa-eye fa-eye-slash");

                var input = bstLoginPassword.GetInputElement();
                var tipo = input.attributes["type"].nodeValue;
                //alert(tipo);
                tipo === 'password' ? input.setAttribute("type", "text") : input.setAttribute("type", "password");
            });

        </script>


   


</body>
</html>