<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Beneficiarios.aspx.cs" Inherits="PayLots.Beneficiarios.Beneficiarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="card ">
      <div class="card-header main">Beneficiarios Registrados</div>
      <div class="card-body">
    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Beneficiarios" ClientInstanceName="gridBeneficiarios" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Beneficiarios" KeyFieldName="IdBeneficiario" EnableTheming="True" Theme="MaterialCompact" Width="100%"
     OnRowInserting="GridView_Beneficiarios_RowInserting" OnRowDeleting="GridView_Beneficiarios_RowDeleting" OnRowUpdating="GridView_Beneficiarios_RowUpdating" OnCustomButtonCallback="GridView_Beneficiarios_CustomButtonCallback">
        <ClientSideEvents RowDblClick="function(s,e){gridBeneficiarios.StartEditRow(e.visibleIndex);}" />
        <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true"/>
        <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" />
        <SettingsExport ExcelExportMode="WYSIWYG" EnableClientSideExportAPI="true"></SettingsExport>
        <SettingsContextMenu EnableRowMenu="True" RowMenuItemVisibility-ExportMenu-Visible="true"></SettingsContextMenu>
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
        <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="800">
            <AdaptiveDetailLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager PageSize="10">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowHeaderFilterButton="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" />
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
                <dx:GridViewColumnLayoutItem ColumnName="NombreCompleto" ColSpan="2" ColumnSpan="2"></dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Direccion" ColumnSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="CedulaIdentidad">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Telefono">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right" Width="100%" ColumnSpan="2"></dx:EditModeCommandLayoutItem>
            </Items>

            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                
            </SettingsAdaptivity>

        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="10%">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="Lotes" Image-IconID="layout_list_32x32devav" Image-ToolTip="Lotes Asignados" Text=" ">
                        <Image IconID="layout_list_32x32devav" ToolTip="Lotes Asignados">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="IdBeneficiario" VisibleIndex="1" ReadOnly="True" ShowInCustomizationForm="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreCompleto" VisibleIndex="2" ShowInCustomizationForm="True" Width="30%" >
                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-ErrorText="Debe ingresar el Nombre"></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CedulaIdentidad" VisibleIndex="3" ShowInCustomizationForm="True" Width="20%">
                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-ErrorText="Debe ingresar la Cedula de Identidad"></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Direccion" VisibleIndex="4" ShowInCustomizationForm="True" Width="40%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Telefono" VisibleIndex="5" ShowInCustomizationForm="True" Width="20%">
                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-ErrorText="Debe ingresar el número telefónico."></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
        </Columns>
        <Styles>
            <Header Wrap="False" ForeColor="#1d3757" HorizontalAlign="Center"></Header>

        </Styles>
    </dx:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource_Beneficiarios" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdBeneficiario], [NombreCompleto], [CedulaIdentidad], [Direccion], [Telefono] FROM [Beneficiarios]"></asp:SqlDataSource>
        </ContentTemplate></asp:UpdatePanel>
          </div>
        </div>
    <asp:UpdatePanel ID="UdpLotes" runat="server">
        <ContentTemplate>

            <dx:ASPxPopupControl ID="ASPxPopup_LotesAsignados" runat="server" AllowDragging="True" AutoUpdatePosition="True" CloseAction="CloseButton" CloseOnEscape="True" HeaderText="Lotes Asignados" Height="300px" MinHeight="300px" MinWidth="300px" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="MaterialCompact" Width="25%">
                <HeaderStyle BackColor="#dfdfdf" ForeColor="Black" />
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxGridView ID="ASPxGridView_Lotes" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_LotesAsignados" Theme="MaterialCompact" Width="100%">
                            <Settings ShowFilterRow="True" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="NombreProyecto" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NombreLote" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Estado" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <FormatConditions>
                                <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[Estado] = 'Anulada'" FieldName="Estado" ShowInColumn="Estado">
                                </dx:GridViewFormatConditionHighlight>
                            </FormatConditions>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SqlDataSource_LotesAsignados" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [NombreProyecto], [NombreLote], [Estado] FROM [View_Asignaciones_Lotes] WHERE ([IdBeneficiario] = @IdBeneficiario)">
                            <SelectParameters>
                                <asp:SessionParameter Name="IdBeneficiario" SessionField="IdBeneficiario" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
