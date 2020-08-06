<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="PayLots.Asignaciones.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row
        {
            padding-bottom:1%;
        }
    </style>
    <script type="text/javascript">
        function CheckChanged(s, e) {
            var checkState = s.GetCheckState();
            if (checkState == "Checked") {
                
                gridAsignaciones.ApplyFilter("Estado='Vigente'");
                chkFiltro.SetText("Vigentes");
                
            }
            else if (checkState == "Unchecked") {
                
                gridAsignaciones.ApplyFilter("Estado='Anulada'");
                chkFiltro.SetText("Anuladas");
              
                
            }
            else if (checkState == "Indeterminate") {
                
                gridAsignaciones.ClearFilter();
                chkFiltro.SetText("Todas");
              
            }
        }
    </script>
     <link rel="stylesheet" type="text/css" href='<%# ResolveUrl("~/Content/GridView.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="card ">
      <div class="card-header main">ASIGNACIONES REGISTRADAS</div>
      <div class="card-body justify-content-center">
          
    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
        <dx:ASPxLabel ID="lblFiltro" ClientInstanceName="lblfilter" runat="server" ClientVisible="true"></dx:ASPxLabel>
    <dx:ASPxGridView ID="GridView_Asignaciones" ClientInstanceName="gridAsignaciones" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Asignaciones" EnableTheming="True" Width="100%"
     OnAutoFilterCellEditorInitialize="GridView_Asignaciones_AutoFilterCellEditorInitialize" OnCellEditorInitialize="GridView_Asignaciones_CellEditorInitialize" KeyFieldName="IdAsignacion"
      OnStartRowEditing="GridView_Asignaciones_StartRowEditing" OnInitNewRow="GridView_Asignaciones_InitNewRow" OnRowDeleting="GridView_Asignaciones_RowDeleting" OnCustomButtonCallback="GridView_Asignaciones_CustomButtonCallback">
        <ClientSideEvents RowDblClick="function(s,e){gridAsignaciones.StartEditRow(e.visibleIndex);}" />
        <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true"/>
        <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" AllowSelectByRowClick="True" />
        <SettingsExport FileName="AsignacionesRegistradas" ExcelExportMode="WYSIWYG" EnableClientSideExportAPI="true"></SettingsExport>
        <Toolbars>
            <dx:GridViewToolbar Position="Top" ItemAlign="Right" EnableAdaptivity="true">
                
                <Items>
                    <dx:GridViewToolbarItem Name="Filtrar" >
                        <Template>
                            <dx:ASPxCheckBox ID="chkFiltro" Text='<%#GridView_Asignaciones.FilterExpression != "" ? GridView_Asignaciones.FilterExpression  :  "Todas"%>' runat="server" ToggleSwitchDisplayMode="Always" ValueType="System.String" AutoPostBack="false" ValueChecked="Vigente" CheckState="Indeterminate" ValueGrayed="Todas" ValueUnchecked="Anulada" AllowGrayed="true" AllowGrayedByClick="true" ClientInstanceName="chkFiltro" Theme="MaterialCompact" Width="80px">
                                <ClientSideEvents ValueChanged="CheckChanged" />
                            </dx:ASPxCheckBox>
                        </Template>
                    </dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ExportToXlsx"></dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ExportToPdf"></dx:GridViewToolbarItem>
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
        <SettingsAdaptivity AllowHideDataCellsByColumnMinWidth="true" AdaptivityMode="HideDataCells"  HideDataCellsAtWindowInnerWidth="800">
            <AdaptiveDetailLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager PageSize="10">
        </SettingsPager>
        <Settings ShowHeaderFilterButton="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" ShowFooter="True" />
        <SettingsText SearchPanelEditorNullText="Buscar..." />
        <SettingsSearchPanel Visible="True" />
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <SettingsPopup EditForm-MinWidth="200px" EditForm-CloseOnEscape="False" EditForm-SettingsAdaptivity-Mode="OnWindowInnerWidth" HeaderFilter-SettingsAdaptivity-Mode="OnWindowInnerWidth" EditForm-Modal="true" EditForm-VerticalAlign="WindowCenter" EditForm-HorizontalAlign="WindowCenter">
            <EditForm MinWidth="300px" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="True" CloseOnEscape="False">
                <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
            </EditForm>
        </SettingsPopup>
        <SettingsText ConfirmDelete="¿Esta seguro que desea anular la asignación?" />
        <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit" ColCount="2" ColumnCount="2">
            <Items>
                
               
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="IdLote">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="IdBeneficiario">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="MontoTotal">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="FechaInicioPago">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="CuotaMinima">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Donado">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="AplicaInteres">
                </dx:GridViewColumnLayoutItem>
                
               
                <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right" Width="100%"></dx:EditModeCommandLayoutItem>
            </Items>

            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
            </SettingsAdaptivity>

        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" ButtonRenderMode="Image" VisibleIndex="0" Width="15%">
                
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="PlanPago" Text="" Visibility="BrowsableRow">
                        <Image IconID="scheduling_groupbynone_32x32" ToolTip="Calendario de Pagos">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
                <CellStyle>
                    <Paddings Padding="0px" />
                </CellStyle>
                
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="IdAsignacion" VisibleIndex="1" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreProyecto" Width="10%" VisibleIndex="3" EditFormSettings-Visible="True" Caption="Proyecto" AllowTextTruncationInAdaptiveMode="True">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreLote" Caption="Lote" VisibleIndex="4" ReadOnly="True" Width="5%" EditFormSettings-Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn FieldName="MontoTotal" Caption="Costo Total" VisibleIndex="6" EditFormSettings-Visible="True" Width="10%">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="Prima" Caption="Prima" VisibleIndex="7" EditFormSettings-Visible="True" Width="10%">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="Abonado" VisibleIndex="8" EditFormSettings-Visible="False" Width="10%">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="Saldo" VisibleIndex="9" EditFormSettings-Visible="False" ReadOnly="True" Width="10%">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataDateColumn FieldName="FechaInicioPago" Caption="Fecha Pago" VisibleIndex="10" EditFormSettings-Visible="True" AdaptivePriority="1" Visible="False">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataSpinEditColumn FieldName="CuotaMinima" Caption="Cuota Mínima" VisibleIndex="11" EditFormSettings-Visible="True" AdaptivePriority="1" Visible="False">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="12" EditFormSettings-Visible="False" AdaptivePriority="1" Visible="True" Width="10%">
                <EditFormSettings Visible="false" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="Donado" VisibleIndex="13" EditFormSettings-Visible="True" AdaptivePriority="1" Visible="False">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="IdLote" ShowInCustomizationForm="True" EditFormSettings-Visible="True" Visible="False" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="SqlDataSource_Lotes" TextField="NombreLote" DisplayFormatInEditMode="true" DisplayFormatString="{0}" TextFormatString="{0}; {1}" ValueField="IdLote">
                    <Columns>
                        <dx:ListBoxColumn FieldName="IdLote" Visible="False">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="NombreLote">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Ubicacion">
                        </dx:ListBoxColumn>
                    </Columns>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Beneficiario" Width="20%" FieldName="IdBeneficiario" VisibleIndex="5">
                <PropertiesComboBox ClientInstanceName="cboBeneficiario" DataSourceID="SqlDataSource_Beneficiarios" DisplayFormatString="{1}" TextField="NombreCompleto" ValueField="IdBeneficiario">
                    <Columns>
                        <dx:ListBoxColumn FieldName="IdBeneficiario" Visible="False">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="NombreCompleto">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="CedulaIdentidad">
                        </dx:ListBoxColumn>
                    </Columns>
                  <%--  <Buttons>
                        <dx:EditButton ToolTip="Nuevo Beneficiario">
                            <Image Height="24px" IconID="actions_addfile_32x32" Width="24px">
                            </Image>
                        </dx:EditButton>
                    </Buttons>--%>
                    <ClientSideEvents ButtonClick="function(s,e){popBeneficiarios.Show();}" />
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn FieldName="AplicaInteres" EditFormSettings-Visible="True" Visible="false">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
        </Columns>
        <TotalSummary>
            
            <dx:ASPxSummaryItem DisplayFormat="N2" FieldName="MontoTotal" ShowInColumn="Costo Total" SummaryType="Sum" ValueDisplayFormat="N2" />
            <dx:ASPxSummaryItem DisplayFormat="N2" FieldName="Prima" ShowInColumn="Prima" SummaryType="Sum" ValueDisplayFormat="N2" />
            <dx:ASPxSummaryItem DisplayFormat="N2" FieldName="Abonado" ShowInColumn="Abonado" SummaryType="Sum" ValueDisplayFormat="N2" />
            <dx:ASPxSummaryItem DisplayFormat="N2" FieldName="Saldo" ShowInColumn="Saldo" SummaryType="Sum" ValueDisplayFormat="N2" />
        </TotalSummary>
        <FormatConditions>
            <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[Estado] = 'Anulada'" FieldName="Estado" ShowInColumn="Estado">
            </dx:GridViewFormatConditionHighlight>
        </FormatConditions>
        <Styles>
            <Row Wrap="True"></Row>
            <Footer Font-Bold="true"></Footer>
            <Header Wrap="true" HorizontalAlign="Center"></Header>
            <Cell Wrap="false" />
            <%--<PagerBottomPanel CssClass="pager" />
            <FocusedRow CssClass="focused" />--%>
        </Styles>
    </dx:ASPxGridView>
       
        <asp:SqlDataSource ID="SqlDataSource_Asignaciones" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdAsignacion], [IdLote],[IdBeneficiario], [NombreProyecto], [NombreLote], [NombreCompleto], [MontoTotal], [Abonado],[Prima], [Saldo], [FechaInicioPago], [CuotaMinima], [Estado], [Donado],[AplicaInteres] FROM [View_Asignaciones_Saldo]"
        >
           
          
        </asp:SqlDataSource>
       
        <asp:SqlDataSource ID="SqlDataSource_Lotes" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT IdLote, NombreLote, NombreProyecto +', ' + Municipio +','+Departamento as Ubicacion FROM View_Lotes"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource_Beneficiarios" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdBeneficiario], [NombreCompleto], [CedulaIdentidad] FROM [Beneficiarios]"></asp:SqlDataSource>
       
        </ContentTemplate></asp:UpdatePanel>
           </div>
        </div>

       <asp:UpdatePanel ID="UdpBeneficiarios" runat="server">
        <ContentTemplate>

            <dx:ASPxPopupControl ID="ASPxPopup_Beneficiarios" EnableHierarchyRecreation="false" Modal="true" ClientInstanceName="popBeneficiarios" runat="server" AllowDragging="True" AutoUpdatePosition="True" CloseAction="CloseButton" CloseOnEscape="false" HeaderText="Agregar Beneficiario" Height="300px" MinHeight="300px" MinWidth="650px" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="MaterialCompact" MaxWidth="800px">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" />
                <HeaderStyle BackColor="#4BBE80" ForeColor="Black" />
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
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
                            <div class="row">
                                <div class="col-md-6"></div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdGuardar" runat="server"><ContentTemplate>
                                    <dx:BootstrapButton ID="Button_Guardar" runat="server" OnClick="Button_Guardar_Click" AutoPostBack="false" Text="Guardar" Width="95%">
                                        <SettingsBootstrap RenderOption="Primary" Sizing="Normal" />
                                    </dx:BootstrapButton>
                                    </ContentTemplate></asp:UpdatePanel>
                                </div>
                                 <div class="col-md-3">
                                    <asp:UpdatePanel ID="UdpCancelar" runat="server"><ContentTemplate>
                                     <dx:BootstrapButton ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" AutoPostBack="false" Text="Cancelar" Width="95%">
                                        <SettingsBootstrap RenderOption="Primary" Sizing="Normal" />
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

     <asp:UpdatePanel ID="UpdAnular" runat="server">
        <ContentTemplate>

            <dx:ASPxPopupControl ID="ASPxPopupControl_Anular" EnableHierarchyRecreation="false" Modal="true" ClientInstanceName="popAnular" runat="server" AllowDragging="True" AutoUpdatePosition="True" CloseAction="CloseButton" CloseOnEscape="false" HeaderText="Anular Asignación" Height="200px" MinHeight="200px" MinWidth="500px" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="MaterialCompact" MaxWidth="600px">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" />
                <HeaderStyle BackColor="#4BBE80" ForeColor="Black" />
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                        <div class="container-fluid">
                            
                            <div class="row">
                                <div class="col-md-3">
                                    Motivo de Anulación: 
                                </div>
                                <div class="col-md-9">
                                    <dx:BootstrapMemo ID="Memo_MotivoAnular" Width="100%" runat="server" ></dx:BootstrapMemo>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UdpLblanular" runat="server"><ContentTemplate>
                                    <dx:ASPxLabel ID="lblIdAnular" ClientVisible="false" runat="server"></dx:ASPxLabel>
                                    </ContentTemplate></asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6"></div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                    <dx:BootstrapButton ID="Button_Anular" runat="server" AutoPostBack="false" OnClick="Button_Anular_Click" Text="Anular" Width="95%">
                                        <SettingsBootstrap RenderOption="Primary" Sizing="Small" />
                                    </dx:BootstrapButton>
                                    </ContentTemplate></asp:UpdatePanel>
                                </div>
                                 <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                                     <dx:BootstrapButton ID="Button_CancelarAnular" runat="server" OnClick="Button_CancelarAnular_Click" AutoPostBack="false" Text="Cancelar" Width="95%">
                                        <SettingsBootstrap RenderOption="Primary" Sizing="Small" />
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
