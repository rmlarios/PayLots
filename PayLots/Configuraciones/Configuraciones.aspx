<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="PayLots.Configuraciones.Configuraciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .column {
            float: left;
            height: auto;
            padding: 5px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
    <div class="col-md-2"></div>
    <div class="col-md-8">
    <div class="card" style="margin-top: 5%; width: 100%;">
        <div class="card-header">Configuraciones del Sistema</div>
        <div class="card-body">
            
            
            <dx:ASPxFloatingActionButton ID="ASPxFloatingActionButton1" VerticalPosition="Bottom" VerticalMargin="-60"  HorizontalPosition="Right" TextVisibilityMode="OnHover"  InitialActionContext="Guardar" ClientInstanceName="fab" ContainerElementID="datos" runat="server" EnableTheming="True" Theme="MaterialCompact">
                <ClientSideEvents ActionItemClick="function(s,e){btnguardar.DoClick();}" />
                <Items>
                    <dx:FABAction ContextName="Guardar" Text="Guardar" ActionName="Guardar">
                        <Image IconID="save_save_32x32">
                        </Image>
                    </dx:FABAction>
                </Items>
            </dx:ASPxFloatingActionButton>
            <dx:BootstrapPageControl ID="BootstrapPageControl1" EnableTheming="true" EnableHierarchyRecreation="false"  Width="100%" ClientInstanceName="pagecontrol" runat="server">

                <TabPages>
                    <dx:BootstrapTabPage Text="Datos Empresa">
                        <ContentCollection>
                            <dx:ContentControl >
                                <div class="row" id="datos">
                                    <div class="col-md-7">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <dx:BootstrapTextBox ID="TextBox_NombreEmpresa" CaptionSettings-ShowColon="true" Caption="Nombre de la Empresa" runat="server" Width="100%"></dx:BootstrapTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <dx:BootstrapTextBox ID="TextBox_Direccion" Caption="Dirección de la Empresa" runat="server" Width="100%"></dx:BootstrapTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                        <dx:BootstrapTextBox ID="TextBox_Teléfono" Caption="Teléfono" runat="server"></dx:BootstrapTextBox>
                                         </div>
                                        <div class="col-md-4">
                                        <dx:BootstrapTextBox ID="TextBox_Email" Caption="Email" runat="server"></dx:BootstrapTextBox>
                                        </div>
                                        <div class="col-md-4">
                                        <dx:BootstrapTextBox ID="TextBox_Ruc" Caption="RUC" runat="server"></dx:BootstrapTextBox>
                                            </div>
                                    </div>
                                        </div>
                                   
                                        <div class="col-md-5" style="text-align:center;text-align:-webkit-center;">
                                         
                                            <dx:BootstrapBinaryImage ID="BinaryImage_Logo" ImageSizeMode="FitProportional" ImageAlign="Middle" Width="300px" Height="300px" EditingSettings-Enabled="true" EditingSettings-EmptyValueText="Seleccione el archivo a subir" runat="server">
                                                <EditingSettings UploadSettings-UploadValidationSettings-ShowErrors="true"></EditingSettings>
                                            </dx:BootstrapBinaryImage>
                                        </div>
                                   
                                </div>
                                <div class="row justify-content-center">
                                    <div class="col-12 ">
                                        <dx:ASPxButton RenderMode="Button" Text="Cambiar Idioma" ID="BtnCambiarIdioma" runat="server" OnClick="BtnCambiarIdioma_Click"></dx:ASPxButton>
                                    </div>
                                </div>
                                <hr />
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:BootstrapTabPage>
                    <dx:BootstrapTabPage Text="Respaldar/Restaurar BD">
                        <ContentCollection>
                            <dx:ContentControl>
                                <div class="row">
                                    <div class="col-md-12">
                                        <dx:ASPxButton ID="Btn_Respaldar" runat="server" Text="Respaldar" OnClick="Btn_Respaldar_Click"></dx:ASPxButton>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:UpdatePanel ID="UdpList" runat="server"><ContentTemplate>
                                        <dx:ASPxGridView ID="GridView_Respaldos" Width="100%" Theme="MaterialCompact" KeyFieldName="NombreArchivo" runat="server">
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="NombreArchivo" Width="70%" Caption="Nombre del Archivo"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FechaCreacion" Width="20%" Caption="Fecha de Creación"></dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Settings ShowFilterRow="true" VerticalScrollableHeight="300"/>
                                            <SettingsBehavior AllowSelectByRowClick="true" />
                                            <SettingsPager PageSize="10" AlwaysShowPager="true" ShowEmptyDataRows="true"></SettingsPager>
                                        </dx:ASPxGridView>
                                            </ContentTemplate></asp:UpdatePanel>
                                    </div>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:BootstrapTabPage>
                </TabPages>
            </dx:BootstrapPageControl>
            </div>
            
        </div>
    </div>      
        <div class="col-md-2">
            <asp:UpdatePanel ID="Udpguardar" runat="server"><ContentTemplate>
            <dx:ASPxButton ID="BtnGuardar" AutoPostBack="false" runat="server" ClientInstanceName="btnguardar" ClientVisible="false" UseSubmitBehavior="false" OnClick="BtnGuardar_Click"></dx:ASPxButton>
                </ContentTemplate></asp:UpdatePanel>
        </div>
        
  </div>
    



</asp:Content>
