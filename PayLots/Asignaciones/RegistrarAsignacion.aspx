<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="RegistrarAsignacion.aspx.cs" Inherits="PayLots.Asignaciones.RegistrarAsignacion" %>


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
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="card ">
        <div class="card-header main">REGISTRAR ASIGNACION DE LOTE</div>
        <div class="card-body">
            <div class="container-fluid">
               
                <div class="row" style="text-align:center">
                    <div class="col-md-5 button-group btn-group justify-content-center">
                        <asp:UpdatePanel ID="UdpBotones" runat="server"><ContentTemplate>
                        <dx:BootstrapButton ID="Btn_Guardar" Width="33%" AutoPostBack="false" OnClick="Btn_Guardar_Click" runat="server" Text="Guardar" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-save fa-2x"></dx:BootstrapButton>
                        <dx:BootstrapButton ID="Btn_Nuevo" Width="33%" OnClick="Btn_Nuevo_Click" runat="server" AutoPostBack="false" Text="Nuevo" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-file-o fa-2x"></dx:BootstrapButton>
                        <dx:BootstrapButton ID="Btn_Cancelar" Width="33%" runat="server" OnClick="Btn_Cancelar_Click" Text="Cancelar" AutoPostBack="false" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-ban fa-2x"></dx:BootstrapButton>
                            </ContentTemplate></asp:UpdatePanel>
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
                    
                    <div class="col-md-1">
                        <asp:UpdatePanel ID="UdplblAsig" runat="server"><ContentTemplate>
                        <dx:ASPxLabel ID="lblIdAsignacion" runat="server" ClientVisible="false"></dx:ASPxLabel>
                        </ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" valign=center;>
                    
                    <div class="col-md-1">
                        Lote: 
                    </div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <dx:BootstrapComboBox ID="ComboBox_Lotes" Width="100%" runat="server" DataSourceID="SqlDataSource_Lotes" ValueField="IdLote" TextField="NombreLote" ValueType="System.Int32" TextFormatString="{0}; {1}">
                            <ClearButton DisplayMode="Always" />
                            <Fields>
                                
                                <dx:BootstrapListBoxField FieldName="NombreLote" />
                                <dx:BootstrapListBoxField FieldName="Ubicacion" />
                            </Fields>
                        </dx:BootstrapComboBox>
                                </ContentTemplate></asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource_Lotes" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT distinct [IdLote], [NombreLote], [NombreProyecto]+','+[Municipio] AS Ubicacion FROM [View_Lotes] WHERE Estado='Disponible' OR IdLote IN(SELECT IDLOTE FROM ASIGNACIONES WHERE IdAsignacion=@IdAsignacion)">
                            <SelectParameters>
                                    <asp:ControlParameter ControlID="lblIdAsignacion" Name="IdAsignacion" PropertyName="Text" />
                                </SelectParameters>
                        </asp:SqlDataSource>
                        
                    </div>
                    <div class="col-md-2">
                        Beneficiario
                    </div>
                    <div class="col-md-5">
                        <asp:UpdatePanel ID="UdpBenef" runat="server"><ContentTemplate>
                        <dx:BootstrapComboBox ID="ComboBox_Beneficiarios" OnButtonClick="ComboBox_Beneficiarios_ButtonClick"  Width="100%" runat="server" DataSourceID="SqlDataSource_Beneficiarios" ValueField="IdBeneficiario" TextField="NombreCompleto" ValueType="System.Int32" NullText="Seleccione el Beneficiario">
                            <Fields>
                                <dx:BootstrapListBoxField FieldName="NombreCompleto" />
                                <dx:BootstrapListBoxField FieldName="IdBeneficiario" />
                            </Fields>
                            <Buttons>
                              
                                <dx:BootstrapEditButton Position="Right" ToolTip="Agregar Beneficiario" IconCssClass="fa-plus fa m" />
                            </Buttons>
                           
                        </dx:BootstrapComboBox>
                        </ContentTemplate></asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource_Beneficiarios" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT DISTINCT [IdBeneficiario], [NombreCompleto] FROM [Beneficiarios]"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row">
                    
                    <div class="col-md-2">
                        Monto:
                    </div>
                    <div class="col-md-2">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Monto" Width="100%" NumberType="Float" runat="server" DecimalPlaces="2" MinValue="1" MaxValue="100000" DisplayFormatString="N2">
                         </dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        Fecha Inicial de Pago:
                    </div>
                    <div class="col-md-2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                        <dx:BootstrapDateEdit ID="DateEdit_FechaPago" Width="100%" runat="server"></dx:BootstrapDateEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        Cuota Mínima:
                    </div>
                    <div class="col-md-2">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEdit_Cuota" Width="100%" runat="server" DecimalPlaces="2" MinValue="1" MaxValue="100000" DisplayFormatString="N2"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-md-2">
                        Prima:
                    </div>
                   <div class="col-md-2">
                       <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                       <dx:BootstrapSpinEdit ID="SpinEdit_Prima" Width="100%" runat="server" DecimalPlaces="2" MinValue="0" MaxValue="100000" DisplayFormatString="N2"></dx:BootstrapSpinEdit>
                           </ContentTemplate></asp:UpdatePanel>
                   </div>
                    <div class="col-md-1">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                        <dx:BootstrapCheckBox ID="CheckBox_Donado" Width="100%" Text="Donado" runat="server"></dx:BootstrapCheckBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md-1">
                       <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapCheckBox ID="CheckBox_AplicaMora" Width="100%" Text="Mora" runat="server"></dx:BootstrapCheckBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        Observaciones:
                    </div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Observaciones" Width="100%" runat="server"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <dx:BootstrapCheckBox ID="CheckBox_AplicaInteres" AutoPostBack="true" OnCheckedChanged="CheckBox_AplicaInteres_CheckedChanged" Width="100%" Text="Aplicar Interés" runat="server"></dx:BootstrapCheckBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">Tasa de Interés</div>
                    <div class="col-md-2">
                         <asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate>
                       <dx:BootstrapSpinEdit ID="SpinEdit_TasaInteres" Enabled="false" Width="100%" runat="server" DecimalPlaces="2" MinValue="0" MaxValue="100000" DisplayFormatString="N2"></dx:BootstrapSpinEdit>
                           </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">Cuotas:</div>
                    <div class="col-md-2">
                         <asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate>
                       <dx:BootstrapSpinEdit ID="SpinEdit_PlazoMeses" Width="100%" Enabled="false" runat="server" DecimalPlaces="0" MinValue="0" MaxValue="100000" DisplayFormatString="N0"></dx:BootstrapSpinEdit>
                           </ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>
                <div class="row card-header text-center details">
                    <div class="col-md-12">
                    DETALLE PLAN DE PAGO
                        </div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
                            <dx:ASPxGridView ID="GridView_PlanPago" KeyFieldName="MesPagado;NumeroCuota" ClientInstanceName="gridPlanPago" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_PlanPago" EnableTheming="True" Theme="MaterialCompact" Width="100%">
                                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="HistoricoPago"></SettingsExport>
                                <SettingsDataSecurity AllowInsert="false" AllowDelete="false" AllowEdit="false" />
                                <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" AllowSelectByRowClick="True" />
                                
                                <Toolbars>
                                    <dx:GridViewToolbar Name="toolbar" EnableAdaptivity="true" Position="Top" ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Text="Exportar a Excel" DisplayMode="ImageWithText" Command="ExportToXlsx"></dx:GridViewToolbarItem>
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
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
                                    <DeleteButton RenderMode="Image" Image-IconID="actions_cancel_32x32office2013">
                                        <Image IconID="actions_cancel_32x32office2013"></Image>
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
                                <SettingsAdaptivity  AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="800">
                                    <AdaptiveDetailLayoutProperties>
                                        <SettingsAdaptivity AdaptivityMode="Off" />
                                    </AdaptiveDetailLayoutProperties>
                                </SettingsAdaptivity>
                                <SettingsPager PageSize="10">
                                </SettingsPager>
                                <Settings ShowFilterRow="True" ShowHeaderFilterButton="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" ShowFooter="True" />
                                <SettingsText SearchPanelEditorNullText="Buscar..." />
                                <SettingsSearchPanel Visible="True" />
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
                                  <dx:GridViewDataColumn FieldName="NumeroCuota" Caption="Cuota" Width="5%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="MesPagado" Caption="Mes" Width="15%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="MontoMinimo" Caption="Monto Cuota" Width="10%"></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="FechaCuota" Caption="Fecha Cuota" Width="10%"></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="MontoPagado" Caption="Monto Pagado" Width="10%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="Interes" Caption="Interés" Width="10%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="Mora" Caption="Mora" Width="10%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="FechaPago" Caption="Fecha Realizado" Width="10%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="Saldo" Width="10%" ></dx:GridViewDataColumn>
                                  <dx:GridViewDataColumn FieldName="Estado" Width="10%" ></dx:GridViewDataColumn>

                              </Columns>
                                <Styles>
                                    <Header Wrap="true" ForeColor="#1d3757" HorizontalAlign="Center"></Header>

                                </Styles>
                            </dx:ASPxGridView>     
                            <asp:SqlDataSource ID="SqlDataSource_PlanPago" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT * FROM FN_Asignacion_PlandePago(@IdAsignacion)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblIdAsignacion" Name="IdAsignacion" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md-1"></div>
                </div>

            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="UdpBeneficiarios" runat="server">
        <ContentTemplate>

            <dx:ASPxPopupControl ID="ASPxPopup_Beneficiarios" EnableHierarchyRecreation="false" Modal="true" ClientInstanceName="popBeneficiarios" runat="server" AllowDragging="True" AutoUpdatePosition="True" ShowCloseButton="false" CloseOnEscape="false" HeaderText="Agregar Beneficiario" Height="300px" MinHeight="300px" MinWidth="650px" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="MaterialCompact" MaxWidth="800px">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" />
                <HeaderStyle BackColor="#dfdfdf" ForeColor="black" />
                
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" Height="200px" runat="server">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-3">
                                    Nombre Completo: 
                                </div>
                                <div class="col-md-9">
                                    <dx:BootstrapTextBox ID="TextBox_Nombre" Width="100%" runat="server"></dx:BootstrapTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                  No. de Cédula: 
                                </div>
                                <div class="col-md-4">
                                    <dx:BootstrapTextBox ID="TextBox_Cedula" Width="100%" runat="server"></dx:BootstrapTextBox>
                                </div>
                                 <div class="col-md-2">
                                   Teléfono: 
                                </div>
                                <div class="col-md-3">
                                    <dx:BootstrapTextBox ID="TextBox_Telefono" Width="100%" runat="server"></dx:BootstrapTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    Dirección: 
                                </div>
                                <div class="col-md-9">
                                    <dx:BootstrapMemo ID="Memo_Direccion" Width="100%" runat="server" ></dx:BootstrapMemo>
                                </div>

                            </div>
                            <div class="row" style="padding:0px;">
                                <div class="col-md-6"></div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdGuardar" runat="server"><ContentTemplate>
                                    <dx:BootstrapButton ID="Button_Guardar" runat="server" OnClick="Button_Guardar_Click"  AutoPostBack="false" Text="Guardar" Width="98%">
                                        <SettingsBootstrap RenderOption="Default" Sizing="Normal" />
                                    </dx:BootstrapButton>
                                    </ContentTemplate></asp:UpdatePanel>
                                </div>
                                 <div class="col-md-3">
                                    <asp:UpdatePanel ID="UdpCancelar" runat="server"><ContentTemplate>
                                     <dx:BootstrapButton ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click"  AutoPostBack="false" Text="Cancelar" Width="98%">
                                        <SettingsBootstrap RenderOption="Default" Sizing="Normal" />
                                    </dx:BootstrapButton>
                                    </ContentTemplate></asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>

        </ContentTemplate>
    </asp:UpdatePanel> 

</asp:Content>
