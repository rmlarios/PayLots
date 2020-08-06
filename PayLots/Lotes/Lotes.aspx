<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Lotes.aspx.cs" Inherits="PayLots.Lotes.Lotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="card ">
      <div class="card-header main">LOTES REGISTRADOS</div>
      <div class="card-body">
    <asp:SqlDataSource ID="SqlDataSource_Lotes" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [NombreProyecto], [NumeroLote], [Area], [EstadoActual], [Municipio], [Departamento], [IdLote], [IdBloque], [NombreLote] FROM [View_Lotes]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource_Bloques" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdBloque], [Bloque], [NombreProyecto], [Municipio], [Departamento] FROM [View_Bloques_Ubicacion]"></asp:SqlDataSource>
    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Lotes" ClientInstanceName="gridLotes" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Lotes" KeyFieldName="IdLote" EnableTheming="True" Theme="MaterialCompact" Width="100%"
     OnRowInserting="GridView_Lotes_RowInserting" OnRowDeleting="GridView_Lotes_RowDeleting" OnRowUpdating="GridView_Lotes_RowUpdating">
        <ClientSideEvents RowDblClick="function(s,e){gridLotes.StartEditRow(e.visibleIndex);}" />
        <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true"/>
        <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" />
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
        <SettingsAdaptivity AdaptivityMode="HideDataCells">
            <AdaptiveDetailLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager PageSize="9">
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
        <SettingsExport ExcelExportMode="WYSIWYG" EnableClientSideExportAPI="true"></SettingsExport>
        <SettingsContextMenu EnableRowMenu="True" RowMenuItemVisibility-ExportMenu-Visible="true"  RowMenuItemVisibility-ExportMenu-ExportToXlsx="true"></SettingsContextMenu>
        <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit" ColCount="1">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="NombreProyecto" ColSpan="1"></dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="IdBloque">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="NumeroLote">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Area">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right" Width="100%"></dx:EditModeCommandLayoutItem>
            </Items>

            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit"></SettingsAdaptivity>

        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="10%">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="NombreProyecto" VisibleIndex="4" ReadOnly="True" Width="20%">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreLote" VisibleIndex="5" Caption="No. Lote" Width="10%">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn FieldName="Area" VisibleIndex="6" Width="10%">
                <EditFormSettings Visible="True" />
                <PropertiesSpinEdit MinValue="1" MaxValue="100000" DecimalPlaces="2">
                    <ValidationSettings RequiredField-IsRequired="true" ErrorText="Ingrese el área." >
<RequiredField IsRequired="True"></RequiredField>
                    </ValidationSettings>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataTextColumn FieldName="EstadoActual" VisibleIndex="7" ReadOnly="True" Width="30%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Municipio" VisibleIndex="8" Width="10%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Departamento" VisibleIndex="9" Width="10%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IdLote" Visible="False" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="IdBloque" Visible="False" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="SqlDataSource_Bloques" TextField="Bloque" ValueField="IdBloque" ValueType="System.Int32">
                    <Columns>
                        <dx:ListBoxColumn FieldName="IdBloque" Visible="False">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Bloque">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="NombreProyecto">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Municipio">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Departamento">
                        </dx:ListBoxColumn>
                    </Columns>
                    <ValidationSettings RequiredField-IsRequired="true" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" ErrorText="Debe seleccionar el Bloque">
<RequiredField IsRequired="True"></RequiredField>
                    </ValidationSettings>
                </PropertiesComboBox>
                
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="NumeroLote" Visible="False" VisibleIndex="3">
                <PropertiesTextEdit>
                    <ValidationSettings RequiredField-IsRequired="true">
<RequiredField IsRequired="True"></RequiredField>
                    </ValidationSettings>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
        </Columns>
        <Styles>
            <Header Wrap="False" ForeColor="#1d3757" HorizontalAlign="Center"></Header>

        </Styles>
    </dx:ASPxGridView>
        </ContentTemplate></asp:UpdatePanel>
          </div>
        </div>
</asp:Content>
