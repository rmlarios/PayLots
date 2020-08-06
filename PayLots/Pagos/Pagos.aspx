<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="PayLots.Pagos.Pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="card ">
      <div class="card-header main">PAGOS REGISTRADOS</div>
      <div class="card-body">

    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Pagos" ClientInstanceName="gridPagos" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Pagos" EnableTheming="True" Theme="MaterialCompact" Width="100%"
     KeyFieldName="IdPago;IdAsignacion" OnHtmlRowPrepared="GridView_Pagos_HtmlRowPrepared" OnToolbarItemClick="GridView_Pagos_ToolbarItemClick"
      OnStartRowEditing="GridView_Pagos_StartRowEditing">
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
        <SettingsAdaptivity AdaptivityMode="HideDataCells">
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
        <Templates>
            <GroupRowContent>
                <div class="row" style="text-align:center;">
                    <div class="col-md-1">
                        <dx:ASPxButton ID="ASPxButton_Nuevo" ToolTip="Registrar Pago" runat="server" OnClick="ASPxButton_Nuevo_Click">
                            <Image IconID="reports_addgroupfooter_16x16">
                            </Image>
                        </dx:ASPxButton>
                    </div>
                    <div class="col-md-11" style="text-align:left;">
                        <dx:ASPxLabel ID="lblGrupo" Font-Size="Medium" EncodeHtml="false" runat="server" Text='<%#ObtenerCabezeraGrupo(Container) %>'></dx:ASPxLabel>
                    </div>
                </div>
            </GroupRowContent>
        </Templates>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="IdAsignacion" VisibleIndex="1" ReadOnly="True" GroupIndex="0" SortIndex="0" SortOrder="Ascending" Visible="False">
                <Settings GroupInterval="Value" />
                <CellStyle Font-Size="0pt">
                </CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IdPago" VisibleIndex="2" Visible="false" EditFormSettings-Visible="False" ReadOnly="True">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreLote" VisibleIndex="3" ReadOnly="True" EditFormSettings-Visible="False" GroupIndex="1" SortIndex="1" SortOrder="Ascending" Caption="Lote" Name="NombreLote">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreCompleto" VisibleIndex="4" EditFormSettings-Visible="True" GroupIndex="2" SortIndex="2" SortOrder="Ascending">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NumeroRecibo" Width="14%" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="FechaRecibo" VisibleIndex="6" Width="15%" EditFormSettings-Visible="True">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="NumeroAbono" VisibleIndex="7" Width="14%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MesPagado" VisibleIndex="8" Width="21%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MontoPago" VisibleIndex="9" Width="15%" Caption="Monto">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Mora" VisibleIndex="10" Width="15%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Interés" VisibleIndex="11" Width="15%">
            </dx:GridViewDataTextColumn>
            <dx:BootstrapGridViewDataColumn FieldName="Saldo" Visible="false" VisibleIndex="12"></dx:BootstrapGridViewDataColumn>
            <dx:BootstrapGridViewDataColumn FieldName="Prima" Visible="false" ></dx:BootstrapGridViewDataColumn>
            
            <dx:GridViewDataTextColumn FieldName="Estado" Visible="False" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn ShowDeleteButton="false" ShowEditButton="True" VisibleIndex="0" Width="6%" CellStyle-HorizontalAlign="Center">
            </dx:GridViewCommandColumn>
        </Columns>
        <Toolbars>
            <dx:GridViewToolbar EnableAdaptivity="True">
                <Items>
                    <dx:GridViewToolbarItem Command="FullExpand" DisplayMode="Image" ToolTip="Expandir Todo">
                        <Image IconID="spreadsheet_expandfieldpivottable_32x32">
                        </Image>
                    </dx:GridViewToolbarItem>
                    <dx:GridViewToolbarItem Command="FullCollapse" DisplayMode="Image" ToolTip="Contraer todo">
                        <Image IconID="spreadsheet_collapsefieldpivottable_32x32">
                        </Image>
                    </dx:GridViewToolbarItem>
                </Items>
            </dx:GridViewToolbar>
        </Toolbars>
        <TotalSummary>
            <dx:ASPxSummaryItem DisplayFormat="Total Pagos: {0}" FieldName="MontoPago" SummaryType="Sum" ValueDisplayFormat="N2" />
        </TotalSummary>
        <GroupSummary>
            <dx:ASPxSummaryItem DisplayFormat="Prima: {0}" FieldName="Prima" SummaryType="Average" ValueDisplayFormat="N2" />
            <dx:ASPxSummaryItem DisplayFormat="Total Abonado: {0}" FieldName="MontoPago" SummaryType="Sum" ValueDisplayFormat="N2" />
            <dx:ASPxSummaryItem DisplayFormat="Saldo: {0}" FieldName="Saldo" SummaryType="Average" ValueDisplayFormat="N2" />
            
        </GroupSummary>
        <FormatConditions>
            <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[Estado] = 'Anulada'" FieldName="Estado" ShowInColumn="Estado">
            </dx:GridViewFormatConditionHighlight>
        </FormatConditions>
        
        <Styles>
            <Header Wrap="true" HorizontalAlign="Center"></Header>
           
            <GroupRow BackColor="#99CCFF" Wrap="True" ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" Cursor="pointer">
            </GroupRow>
            

            <SearchPanel ForeColor="Black">
            </SearchPanel>
            

        </Styles>
    </dx:ASPxGridView>
       
        
       
        <asp:SqlDataSource ID="SqlDataSource_Pagos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT PAGOS.[IdAsignacion],[IdPago], PAGOS.[NombreLote], PAGOS.[NombreCompleto], [NumeroRecibo], [FechaRecibo],  PAGOS.[NumeroAbono], [MesPagado], [MontoPago], PAGOS.[Interés],[Mora],Saldo,Estado,PAGOS.[Prima] FROM [View_Pagos_Asignaciones] PAGOS WHERE ESTADO='Vigente' AND DONADO=0"></asp:SqlDataSource>
       
        
       
        </ContentTemplate></asp:UpdatePanel>
           </div>
        </div>
</asp:Content>
