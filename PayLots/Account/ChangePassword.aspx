<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ChangePassword.aspx.cs" Inherits="PayLots.ChangePassword" %>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">

    <div class="row justify-content-center" style="margin-top: 5%">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header main">Avatar</div>
                <div class="card-body" style="align-self:center;">
                    <asp:UpdatePanel runat="server"><ContentTemplate>
                        <dx:ASPxBinaryImage ID="ASPxBinaryImage1" OnValueChanged="ASPxBinaryImage1_ValueChanged" Width="180" Height="180" runat="server">
                            <EditingSettings Enabled="true" EmptyValueText="Cargue su avatar" ButtonPanelSettings-Visibility="Faded"></EditingSettings>
                            <ClientSideEvents ValueChanged="function(s,e){e.processOnServer=true;}" />
                        </dx:ASPxBinaryImage>
                        </ContentTemplate></asp:UpdatePanel>
                </div>
                <div class="card-header main">Datos de Seguridad</div>
                <div class="card-body">

                    <dx:BootstrapTextBox ID="tbCurrentPassword" runat="server" Caption="Contraseña Anterior" Password="true" Width="100%">
                        <CaptionSettings Position="Before" />
                        <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup">
                            <RequiredField ErrorText="Old Password is required." IsRequired="true" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                    <dx:BootstrapTextBox ID="tbPassword" ClientInstanceName="Password" Caption="Nueva Contraseña" Password="true" runat="server"
                        Width="100%">
                        <CaptionSettings Position="Before" />
                        <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup">
                            <RequiredField ErrorText="Password is required." IsRequired="true" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                    <dx:BootstrapTextBox ID="tbConfirmPassword" Password="true" Caption="Confirmar Contraseña" runat="server" Width="100%">
                        <CaptionSettings Position="Before" />
                        <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup">
                            <RequiredField ErrorText="Confirm Password is required." IsRequired="true" />
                        </ValidationSettings>
                        <ClientSideEvents Validation="function(s, e) {
        var originalPasswd = Password.GetText();
        var currentPasswd = s.GetText();
        e.isValid = (originalPasswd  == currentPasswd );
        e.errorText = 'The Password and Confirmation Password must match.';
    }" />
                    </dx:BootstrapTextBox>
                    <asp:UpdatePanel ID="UdpCheck" runat="server">
                        <ContentTemplate>
                            <dx:BootstrapCheckBox ID="Check_CambiarPregunta" runat="server" OnCheckedChanged="Check_CambiarPregunta_CheckedChanged" Text="Cambiar Pregunta y Respuesta secreta?" AutoPostBack="true"></dx:BootstrapCheckBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UdpPregunta" runat="server">
                        <ContentTemplate>
                            <dx:BootstrapComboBox ClientVisible="false" Caption="Pregunta secreta" CaptionSettings-Position="Before" ID="BootstrapComboBox_Pregunta_Change" NullText="Seleccione su pregunta secreta" runat="server" DataSourceID="SqlDataSource_Preguntas2" TextField="Pregunta">
                                <ClearButton DisplayMode="Always" />
                            </dx:BootstrapComboBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:SqlDataSource ID="SqlDataSource_Preguntas2" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [Pregunta] FROM [Catalogo_Preguntas]"></asp:SqlDataSource>
                    <asp:UpdatePanel ID="UdpRespuesta" runat="server">
                        <ContentTemplate>
                            <dx:BootstrapTextBox Caption="Ingrese su respuesta" ClientVisible="false" CaptionSettings-Position="Before" ID="BootstrapTextBox_Respuesta_Change" runat="server" Password="True" MaxLength="15">
                            </dx:BootstrapTextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <dx:BootstrapButton ID="btnChangePassword" runat="server" Text="Cambiar Datos" ValidationGroup="ChangeUserPasswordValidationGroup"
                        OnClick="btnChangePassword_Click">
                    </dx:BootstrapButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
