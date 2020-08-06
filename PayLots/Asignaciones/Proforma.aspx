<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Proforma.aspx.cs" Inherits="PayLots.Asignaciones.Proforma" %>
<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web.WebDocumentViewer" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Botones.css" rel="stylesheet" />
    <style>
         .row
        {
            padding-bottom:1%;
            text-align:left;
        }

        .fa.m {
            height:auto;
            width:auto;
        }
        .btn-circle.btn-xl {
  width: 50px;
  height: 50px;
  padding: 10px 16px;
  font-size: 18px;
  line-height: 1.33;
  border-radius: 25px;
}
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="card ">
        <div class="card-header main">CREAR PROFORMA</div>
        <div class="card-body">
            <div class="container-fluid">
                <div class="row" style="text-align: center">
                    <div class="col-md-5 button-group btn-group justify-content-center">
                        <asp:UpdatePanel ID="UdpBotones" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapButton ID="Btn_Guardar" OnClick="Btn_Guardar_Click" Width="33%" AutoPostBack="false" runat="server" Text="Guardar" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-save fa-2x"></dx:BootstrapButton>
                                <dx:BootstrapButton ID="Btn_Nuevo" OnClick="Btn_Nuevo_Click" Width="33%" runat="server" AutoPostBack="false" Text="Nuevo" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-file-o fa-2x"></dx:BootstrapButton>
                                <dx:BootstrapButton ID="Btn_Imprimir" OnClick="Btn_Imprimir_Click" Width="33%" runat="server" Text="Imprimir" AutoPostBack="false" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-print fa-2x"></dx:BootstrapButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                  

                    <%--<div class="col-md-4 button-group justify-content-center">
                        <asp:UpdatePanel ID="UdpTool" runat="server"><ContentTemplate>
                        <dx:BootstrapToolbar ID="ToolbarOpciones"  ShowPopOutImages="True"  AllowSelectItem="false" runat="server" OnItemClick="ToolbarOpciones_ItemClick">
                            
                            <Items>
                                <dx:BootstrapToolbarItem  CssClass="blue button"  Name="ToolNuevo" Text="Nuevo" IconCssClass="fa fa-save fa-2x"></dx:BootstrapToolbarItem>
                                <dx:BootstrapToolbarItem CssClass="blue button"  Name="ToolGuardar" Text="Guardar" IconCssClass="fa fa-save fa-2x"></dx:BootstrapToolbarItem>
                                <dx:BootstrapToolbarItem CssClass="blue button" Name="ToolCancelar" Text="Cancelar" IconCssClass="fa fa-ban fa-2x"></dx:BootstrapToolbarItem>
                                
                            </Items>
                            </dx:BootstrapToolbar>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>--%>
                    </div>
                <div class="row">
                    <div class="col-md-6"></div>
                    <div class="col-md-2 text-right">Proforma No. </div>
                    <div class="col-md-1 text-left">
                           
                        <asp:UpdatePanel ID="UdplblProforma" runat="server">
                            <ContentTemplate>
                             
                                <dx:ASPxLabel ID="lblIdProforma" Width="100%" Font-Bold="true" runat="server"></dx:ASPxLabel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                
                  <div class="col-md-1">
                        <asp:UpdatePanel ID="UpdatePanel99" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapButton ID="Btn_Lista" runat="server" AutoPostBack="false" OnClick="Btn_Lista_Click" CssClasses-Icon="fa fa-search" SettingsBootstrap-RenderOption="Primary" CssClasses-Control= "btn-circle btn-xl" ToolTip="Buscar Proforma"></dx:BootstrapButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row h5">
                    DATOS DEL CLIENTE
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">Nombre Completo: </div>
                    <div class="col-md-8">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapTextBox ID="TextBox_Nombre" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">Domicilio: </div>
                    <div class="col-md-8">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapTextBox ID="TextBox_Domicilio" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                 <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">Teléfono: </div>
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapTextBox ID="TextBox_Telefono" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                      <div class="col-md-2">Email: </div>
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapTextBox ID="TextBox_Email" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                 <div class="row h5">
                    DATOS DEL LOTE
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md">Proyecto: </div>
                    <div class="col-md-3">
                         <asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate>
                       <dx:BootstrapComboBox ID="ComboBox_Proyecto" runat="server" Width="100%" DataSourceID="SqlDataSource_Proyectos">
                           <Fields>
                               <dx:BootstrapListBoxField FieldName="Proyecto" />
                           </Fields>
                       </dx:BootstrapComboBox>
                             <asp:SqlDataSource ID="SqlDataSource_Proyectos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT DISTINCT Proyecto FROM View_Consolidado_Ubicaciones"></asp:SqlDataSource>
                             
                             </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md">Lote: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Lote" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     <div class="col-md">Area (Vrs2): </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Areas" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    
                    
                    <div class="col-md-1"></div>
                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                     <div class="col-md">Precio por Vrs2: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_PrecioVara" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     <div class="col-md">Valor Total: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Total" ReadOnly="true" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md">Prima: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Prima" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    
                    <div class="col-md-1"></div>
                </div>

                <div class="row">

                    <div class="col-md-1"></div>
                     <div class="col-md">A Financiar: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Financiar" ReadOnly="true" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     <div class="col-md">Plazo (meses): </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Plazo" runat="server" Width="100%" DisplayFormatString="N0" DecimalPlaces="0" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     <div class="col-md">Tasa de Interés: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Interes" runat="server" Width="100%" DisplayFormatString="N0" DecimalPlaces="0" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                   
                    
                   
                    <div class="col-md-1"></div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                     <div class="col-md">Cuota Mensual: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Cuota" ReadOnly="true" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     <div class="col-md">Total Interés Acumulado: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_InteresAcumulado" ReadOnly="true" runat="server" Width="100%" DisplayFormatString="N2" DecimalPlaces="2" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     <div class="col-md">Valor Final Pagado: </div>
                    <div class="col-md">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_FinalPagado" runat="server" ReadOnly="true" Width="100%" DisplayFormatString="N2" DecimalPlaces="0" MinValue="1" MaxValue="10000"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                 
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
        <ContentTemplate>
            <dx:BootstrapPopupControl ID="PopupControl_Proforma" ClientInstanceName="popProforma" Width="1000" AllowResize="true" MaxWidth="800" MinWidth="800" Height="900" AllowDragging="true" AppearAfter="100" DisappearAfter="100" CloseAction="CloseButton" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AutoUpdatePosition="true" runat="server" HeaderText="Imprimir Proforma" Modal="True">
                <ContentCollection>
                    <dx:ContentControl>

                        <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" DisableHttpHandlerValidation="False" Height="100%">
                        </dx:ASPxWebDocumentViewer>

                    </dx:ContentControl>

                </ContentCollection>
                <SettingsBootstrap Sizing="Normal" />
                <SettingsAdaptivity MinHeight="600" VerticalAlign="WindowTop" Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="800" />

            </dx:BootstrapPopupControl>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
        <ContentTemplate>
              <dx:BootstrapPopupControl ID="PopupControl_Lista" EnableHierarchyRecreation="false" ClientInstanceName="popLista" Width="900" AllowResize="true" MaxWidth="900" MinWidth="700" Height="400" AllowDragging="true" AppearAfter="100" DisappearAfter="100" CloseOnEscape="true" CloseAction="CloseButton" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AutoUpdatePosition="true" runat="server" HeaderText="Listado de Proformas Creadas" Modal="True">
                <ContentCollection>
                    <dx:ContentControl>
                          <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Proformas" ClientInstanceName="gridProformas" KeyFieldName="IdProforma" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="MaterialCompact" Width="100%" DataSourceID="SqlDataSource_Proformas"
     OnStartRowEditing="GridView_Proformas_StartRowEditing"  >
        <ClientSideEvents RowDblClick="function(s,e){gridProformas.StartEditRow(e.visibleIndex);}" />
        <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true"/>
        <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" AllowSelectByRowClick="True" AllowFixedGroups="True" MergeGroupsMode="Always" />
        <SettingsCommandButton>
            <ShowAdaptiveDetailButton RenderMode="Image" Image-IconID="iconbuilder_actions_arrow3down_svg_dark_16x16" Image-ToolTip="Mostrar más">
                <Image ToolTip="Mostrar m&#225;s" IconID="iconbuilder_actions_arrow3down_svg_dark_16x16"></Image>

                <Styles>
                    <Style Spacing="0px"></Style>
                </Styles>
            </ShowAdaptiveDetailButton>
            <NewButton RenderMode="Image">
                <Image IconID="actions_addfile_32x32office2013">
                </Image>
            </NewButton>
            <DeleteButton RenderMode="Image" Image-IconID="actions_cancel_32x32office2013" Image-ToolTip="Anular Asignacion">
                <Image IconID="snap_removegroupfooter_32x32" Height="32px" Width="32px"></Image>
            </DeleteButton>
            <EditButton RenderMode="Image" Image-IconID="edit_edit_32x32office2013">
                <Image IconID="edit_edit_32x32office2013"></Image>
            </EditButton>
            <HideAdaptiveDetailButton RenderMode="Image" Image-IconID="iconbuilder_actions_arrow3up_svg_dark_16x16" Image-ToolTip="Ocultar">
                <Image ToolTip="Ocultar" IconID="iconbuilder_actions_arrow3up_svg_dark_16x16"></Image>
            </HideAdaptiveDetailButton>
            <%--<NewButton Image-SpriteProperties-CssClass="fa fa-plus-circle fa-2x" Text=""></NewButton>
            <EditButton Image-SpriteProperties-CssClass="fa fa-pencil fa-2x" Text=""></EditButton>
            <DeleteButton Image-SpriteProperties-CssClass="fa fa-remove fa-2x" Text=""></DeleteButton>
            <UpdateButton Image-SpriteProperties-CssClass="fa fa-save fa-2x" Text="Actualizar"></UpdateButton>
            <CancelButton Image-SpriteProperties-CssClass="fa fa-close fa-2x" Text="Cancelar"></CancelButton>--%>
        </SettingsCommandButton>
        <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="800">
            <AdaptiveDetailLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager PageSize="10">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowHeaderFilterButton="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" ShowFooter="True"/>
        <SettingsText SearchPanelEditorNullText="Buscar..." />
        <SettingsSearchPanel Visible="True" ShowClearButton="True" />
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <SettingsPopup EditForm-MinWidth="200px" EditForm-CloseOnEscape="False" EditForm-SettingsAdaptivity-Mode="OnWindowInnerWidth" HeaderFilter-SettingsAdaptivity-Mode="OnWindowInnerWidth" EditForm-Modal="true" EditForm-VerticalAlign="WindowCenter" EditForm-HorizontalAlign="WindowCenter">
            <EditForm MinWidth="300px" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="True" CloseOnEscape="False">
                <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
            </EditForm>
        </SettingsPopup>
        
        <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit" ColCount="2" ColumnCount="2">
            <Items>
                
                <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right" Width="100%"></dx:EditModeCommandLayoutItem>
            </Items>

            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
            </SettingsAdaptivity>

        </EditFormLayoutProperties>
      
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0" Width="5%"></dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="IdProforma" VisibleIndex="0" Visible="false" EditFormSettings-Visible="False" ReadOnly="True">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Nombre" CellStyle-HorizontalAlign="Justify" VisibleIndex="1" Width="35%" EditFormSettings-Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Lote" Width="15%" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Area" VisibleIndex="3" Width="15%" EditFormSettings-Visible="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PrecioVara" VisibleIndex="4" Width="15%" EditFormSettings-Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" VisibleIndex="5" Width="15%">
            </dx:GridViewDataTextColumn>
            
        </Columns>
      
        
        <Styles>
            <Header Wrap="true" HorizontalAlign="Center"></Header>
           <Footer Font-Bold="true"></Footer>
            <GroupRow BackColor="#99CCFF" Wrap="True" ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" Cursor="pointer">
            </GroupRow>
            

            <SearchPanel ForeColor="Black">
            </SearchPanel>
            

        </Styles>
    </dx:ASPxGridView>
       
        
       
                              <asp:SqlDataSource ID="SqlDataSource_Proformas" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdProforma], [Nombre], [Lote], [Area], [PrecioVara], [Total] FROM [Proformas]"></asp:SqlDataSource>
       
        
       
        <asp:SqlDataSource ID="SqlDataSource_Pagos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdPago],IdAsignacion, [NombreLote], [NombreCompleto], [NumeroRecibo], [FechaRecibo], [MesPagado], [MontoPago] Principal, [Mora], [Interés], [TotalRecibo],Moneda,MontoEfectivo FROM [View_Pagos_Asignaciones] WHERE MesPagado IS NOT NULL AND Donado=0 order by IdPago desc"></asp:SqlDataSource>
       
        
       
        </ContentTemplate></asp:UpdatePanel>
                       

                    </dx:ContentControl>

                </ContentCollection>
                <SettingsBootstrap Sizing="Normal" />
                <SettingsAdaptivity MinHeight="600" VerticalAlign="WindowTop" Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="800" />

            </dx:BootstrapPopupControl>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
