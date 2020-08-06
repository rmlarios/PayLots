<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Ubicaciones.aspx.cs" Inherits="PayLots.Ubicaciones.Ubicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="card ">
      <div class="card-header main">ASENTAMIENTOS REGISTRADOS</div>
      <div class="card-body">
     <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Ubicaciones" Caption="Proyectos de Lotificación" ClientInstanceName="gridUbicaciones" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Ubicaciones" KeyFieldName="IdUbicacion" EnableTheming="True" Theme="MaterialCompact" Width="100%"
     OnRowInserting="GridView_Ubicaciones_RowInserting" OnRowUpdating="GridView_Ubicaciones_RowUpdating" OnRowDeleting="GridView_Ubicaciones_RowDeleting" OnCustomButtonCallback="GridView_Ubicaciones_CustomButtonCallback" >
        <ClientSideEvents RowDblClick="function(s,e){gridUbicaciones.StartEditRow(e.visibleIndex);}" />
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
        <SettingsAdaptivity AdaptivityMode="HideDataCells">
            <AdaptiveDetailLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit"/>
                
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
        <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit" ColumnCount="1">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="NombreProyecto" ColSpan="1"></dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Id_Municipio">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Direccion">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Interés" Caption="Aplica Interes">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right" Width="100%"></dx:EditModeCommandLayoutItem>
            </Items>

            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
            </SettingsAdaptivity>

        </EditFormLayoutProperties>
        <Columns>
             <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="15%">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="Bloques" Image-IconID="layout_list_32x32devav" Image-ToolTip="Bloques registrados" Text=" ">
                        <Image IconID="layout_list_32x32devav" ToolTip="Bloques registrados">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="IdUbicacion" VisibleIndex="1" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NombreProyecto" Width="20%" Caption="Nombre del Proyecto" VisibleIndex="2" >
                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-ErrorText="Debe ingresar el Nombre del Proyecto">
                    <ValidationSettings ErrorText="Debe ingresar el Nombre del Proyecto">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Direccion" CellStyle-Wrap="True" Width="20%" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Bloques" VisibleIndex="5" Width="5%" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Asignados" VisibleIndex="6" Width="5%" Caption="Lotes Asignados" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Diponibles" ReadOnly="True" Width="5%" Caption="Lotes Disponibles" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Municipio" FieldName="Id_Municipio" VisibleIndex="3" Width="15%">
                <PropertiesComboBox DataSourceID="SqlDataSource_Municipios" NullValueItemDisplayText="{0}; {1}" TextField="Municipio" TextFormatString="{0}; {1}" ValueField="Municipio_Id">
                    <Columns>
                        <dx:ListBoxColumn FieldName="Municipio_Id" Visible="False">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Municipio" Width="50%">
                        </dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Departamento" Width="50%">
                        </dx:ListBoxColumn>
                    </Columns>
                    <ValidationSettings RequiredField-IsRequired="true">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn Caption="Interés" FieldName="AplicaInteres" VisibleIndex="8"></dx:GridViewDataCheckColumn>
        </Columns>
        <Styles>
            <Header Wrap="true" ForeColor="#1d3757" HorizontalAlign="Center"></Header>
            

        </Styles>
    </dx:ASPxGridView>
        
         <asp:SqlDataSource ID="SqlDataSource_Ubicaciones" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdUbicacion], [NombreProyecto], [Id_Municipio], [Direccion],AplicaInteres,[Bloques], [Asignados], [Diponibles] FROM [View_Consolidado_Ubicaciones]"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource_Municipios" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [Municipio_Id], [Municipio], [Departamento] FROM [View_Departamentos_Municipios]"></asp:SqlDataSource>
        
        </ContentTemplate></asp:UpdatePanel>
    <asp:UpdatePanel ID="UdpBloques" runat="server">
        <ContentTemplate>

            <dx:ASPxPopupControl ID="ASPxPopup_Bloques" runat="server" AllowDragging="True" AutoUpdatePosition="True" CloseAction="CloseButton" CloseOnEscape="True" HeaderText="Bloques de la Ubicacion" Height="300px" MinHeight="300px" MinWidth="400px" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="MaterialCompact" MaxWidth="800px">
                <HeaderStyle BackColor="#dfdfdf" ForeColor="Black" />
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="800" />
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                        
                        <dx:ASPxGridView ID="ASPxGridView_Bloques" EnableCallBacks="false"  runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Bloques" Theme="MaterialCompact" Width="100%" KeyFieldName="IdBloque"
                         OnRowInserting="ASPxGridView_Bloques_RowInserting" OnRowUpdating="ASPxGridView_Bloques_RowUpdating" OnRowDeleting="ASPxGridView_Bloques_RowDeleting">
                            <Settings ShowFilterRow="True" />
                            <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" />
                            <SettingsDataSecurity AllowDelete="true" AllowEdit="true" AllowInsert="true" />
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="20%">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="IdBloque" ShowInCustomizationForm="True" VisibleIndex="0" ReadOnly="True" Visible="False">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Bloque" ShowInCustomizationForm="True" EditFormSettings-Visible="true" VisibleIndex="1">
                                    <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" ValidationSettings-ErrorText="Ingrese el código del Bloque"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn FieldName="TotalLotes" ShowInCustomizationForm="True" EditFormSettings-Visible="false" VisibleIndex="2" Caption="Total Lotes">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Disponibles" ShowInCustomizationForm="True" VisibleIndex="3" EditFormSettings-Visible="false" Caption="Lotes Disponibles" Width="5%">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Lotes Asignados" FieldName="Asignados" ShowInCustomizationForm="True" VisibleIndex="4" EditFormSettings-Visible="false" Width="5%">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                             <SettingsCommandButton>
                                 <ShowAdaptiveDetailButton Image-Width="15" RenderMode="Image" Image-IconID="iconbuilder_actions_arrow3down_svg_dark_16x16" Image-ToolTip="Detalles">
                                     <Image ToolTip="Detalles" IconID="iconbuilder_actions_arrow3down_svg_dark_16x16"></Image>

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
                            <Styles>
                                <Header Wrap="True"></Header>
                            </Styles>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SqlDataSource_Bloques" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdBloque], [Bloque],([Disponibles]+[Asignados]) TotalLotes, [Disponibles], [Asignados] FROM [View_Consolidado_Bloques] WHERE ([IdUbicacion] = @IdUbicacion)">
                            <SelectParameters>
                                <asp:SessionParameter Name="IdUbicacion" SessionField="IdUbicacion" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>

        </ContentTemplate>
    </asp:UpdatePanel>
          </div>
         </div>
    
</asp:Content>
