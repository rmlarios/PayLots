<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ListadoPagos.aspx.cs" Inherits="PayLots.Pagos.ListadoPagos" %>
<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web.WebDocumentViewer" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="card ">
      <div class="card-header main">LISTADO DE PAGOS</div>
      <div class="card-body">

    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Pagos" ClientInstanceName="gridPagos" KeyFieldName="IdPago" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Pagos" EnableTheming="True" Theme="MaterialCompact" Width="100%"
     OnCustomSummaryCalculate="GridView_Pagos_CustomSummaryCalculate" OnStartRowEditing="GridView_Pagos_StartRowEditing" OnCustomButtonCallback="GridView_Pagos_CustomButtonCallback" >
        <ClientSideEvents RowDblClick="function(s,e){gridPagos.StartEditRow(e.visibleIndex);}" />
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
            <dx:GridViewDataTextColumn FieldName="IdPago" VisibleIndex="0" Visible="False" EditFormSettings-Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IdAsignacion" VisibleIndex="0" Visible="False" EditFormSettings-Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true" Width="10%" ButtonRenderMode="Image">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton Image-IconID="print_printer_32x32" Image-ToolTip="Imprimir Ticket"></dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="NombreLote" VisibleIndex="3" Width="5%" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreCompleto" VisibleIndex="4" Width="20%" EditFormSettings-Visible="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NumeroRecibo" VisibleIndex="1" ReadOnly="True" EditFormSettings-Visible="False" Width="5%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="FechaRecibo" VisibleIndex="2" EditFormSettings-Visible="True" Width="10%">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="MesPagado" Width="10%" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            
            <dx:GridViewDataTextColumn FieldName="Principal" Width="5%" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Mora" VisibleIndex="7" Width="5%" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Interés" VisibleIndex="8" Width="5%" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TotalRecibo" VisibleIndex="9" Width="10%" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Moneda" VisibleIndex="10" Width="5%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MontoEfectivo" VisibleIndex="11" Width="10%">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Toolbars>
            <dx:GridViewToolbar EnableAdaptivity="True">
                <Items>
                    <dx:GridViewToolbarItem Command="ExportToXlsx"></dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="ClearFilter"></dx:GridViewToolbarItem>
                </Items>
            </dx:GridViewToolbar>
        </Toolbars>
       
       <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG"></SettingsExport>
       <TotalSummary>
           <dx:ASPxSummaryItem FieldName="MontoEfectivo" DisplayFormat="Córdobas: {0:N2}" ShowInColumn="Interés" SummaryType="Custom" Tag="Cordobas" />
           <dx:ASPxSummaryItem FieldName="MontoEfectivo" DisplayFormat="Dólares: {0:N2}" ShowInColumn="MontoEfectivo" SummaryType="Custom" Tag="Dolares" />
       </TotalSummary>
        
        <Styles>
            <Header Wrap="true" HorizontalAlign="Center"></Header>
           <Footer Font-Bold="true"></Footer>
            <GroupRow BackColor="#99CCFF" Wrap="True" ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" Cursor="pointer">
            </GroupRow>
            

            <SearchPanel ForeColor="Black">
            </SearchPanel>
            

        </Styles>
    </dx:ASPxGridView>
       
        
       
        <asp:SqlDataSource ID="SqlDataSource_Pagos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdPago],IdAsignacion, [NombreLote], [NombreCompleto], [NumeroRecibo], [FechaRecibo], [MesPagado], [MontoPago] Principal, [Mora], [Interés], [TotalRecibo],Moneda,MontoEfectivo FROM [View_Pagos_Asignaciones] WHERE MesPagado IS NOT NULL AND Donado=0 order by IdPago desc"></asp:SqlDataSource>
       
        
       
        </ContentTemplate></asp:UpdatePanel>
           </div>
        </div>
    <asp:UpdatePanel ID="UdpTicket" runat="server"><ContentTemplate>
    <dx:BootstrapPopupControl ID="PopupControl_Ticket" ClientInstanceName="popTicket" Width="400" AllowResize="true" MaxWidth="800" MinWidth="300" Height="600"  AllowDragging="true" AppearAfter="100" DisappearAfter="100" CloseAction="CloseButton" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AutoUpdatePosition="true" runat="server" HeaderText="Imprimir Recibo" Modal="True">
        <ContentCollection>
            <dx:ContentControl>
                
                <dx:ASPxDocumentViewer ID="VisorTicket" ClientInstanceName="webViewer" runat="server" Height="100%" Width="100%">
                    <SettingsReportViewer PrintUsingAdobePlugIn="False" />
                </dx:ASPxDocumentViewer>
                
            </dx:ContentControl>

            </ContentCollection>
        <SettingsBootstrap Sizing="Normal" />
        <SettingsAdaptivity MinHeight="600" VerticalAlign="WindowTop" Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="800" />

    </dx:BootstrapPopupControl>
   </ContentTemplate></asp:UpdatePanel>
</asp:Content>
