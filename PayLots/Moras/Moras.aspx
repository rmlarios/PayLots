<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Moras.aspx.cs" Inherits="PayLots.Moras.Moras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="card" style="margin-top: 5%; width: 100%;">
                <div class="card-header">Rango de Moras a aplicar por Dias</div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
                            <dx:ASPxGridView ID="GridView_Moras" Theme="MaterialCompact" ClientInstanceName="gridMoras" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" KeyFieldName="IdMora" EnableTheming="True" Width="100%" DataSourceID="SqlDataSource_RangosMora" OnRowInserting="GridView_Moras_RowInserting" OnRowUpdating="GridView_Moras_RowUpdating" OnRowDeleting="GridView_Moras_RowDeleting">
                                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="RangosMora"></SettingsExport>
                                <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true" />
                                <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" AllowSelectByRowClick="True" />
                                <ClientSideEvents RowDblClick="function(s,e){gridMoras.StartEditRow(e.visibleIndex);}" />
                              
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
                                <SettingsPager PageSize="6">
                                </SettingsPager>
                                <Settings ShowHeaderFilterButton="true" VerticalScrollableHeight="300" VerticalScrollBarMode="Visible" ShowFooter="True" />
                                <SettingsText SearchPanelEditorNullText="Buscar..." />
                                <SettingsSearchPanel Visible="false" />
                                <SettingsEditing Mode="PopupEditForm">
                                </SettingsEditing>
                                <SettingsPopup EditForm-MinWidth="200px" EditForm-CloseOnEscape="False" EditForm-SettingsAdaptivity-Mode="OnWindowInnerWidth" HeaderFilter-SettingsAdaptivity-Mode="OnWindowInnerWidth" EditForm-Modal="true" EditForm-VerticalAlign="WindowCenter" EditForm-HorizontalAlign="WindowCenter">
                                    <EditForm MinWidth="300px" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="True" CloseOnEscape="False">
                                        <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
                                    </EditForm>
                                </SettingsPopup>
                                <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit">
                                    <Items>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Minimo">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Maximo">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Porcentaje">
                                        </dx:GridViewColumnLayoutItem>
                                       <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right" Width="100%"></dx:EditModeCommandLayoutItem>
                                    </Items>

                                </EditFormLayoutProperties>
                              <Columns>
                                  <dx:GridViewDataTextColumn FieldName="IdMora" ReadOnly="True" VisibleIndex="0" Visible="false">
                                      <PropertiesTextEdit DisplayFormatString="g">
                                      </PropertiesTextEdit>
                                      <EditFormSettings Visible="False" />
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true"></dx:GridViewCommandColumn>
                                  <dx:GridViewDataSpinEditColumn FieldName="Minimo" VisibleIndex="1">
                                      <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="n0" MaxValue="9999" MinValue="1" NumberFormat="Custom">
                                          <ValidationSettings>
                                              <RequiredField IsRequired="True" />
                                          </ValidationSettings>
                                      </PropertiesSpinEdit>
                                  </dx:GridViewDataSpinEditColumn>
                                  <dx:GridViewDataSpinEditColumn FieldName="Maximo" VisibleIndex="2">
                                      <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="n0" MaxValue="9999" MinValue="1" NumberFormat="Custom">
                                          <ValidationSettings>
                                              <RequiredField IsRequired="True" />
                                          </ValidationSettings>
                                      </PropertiesSpinEdit>
                                  </dx:GridViewDataSpinEditColumn>
                                  <dx:GridViewDataSpinEditColumn FieldName="Porcentaje" VisibleIndex="3">
                                      <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatInEditMode="True" DisplayFormatString="n2" NumberFormat="Custom">
                                          <ValidationSettings>
                                              <RequiredField IsRequired="True" />
                                          </ValidationSettings>
                                      </PropertiesSpinEdit>
                                  </dx:GridViewDataSpinEditColumn>

                              </Columns>
                               
                                <Styles>
                                    <Header Wrap="true" ForeColor="#1d3757" HorizontalAlign="Center"></Header>

                                </Styles>
                            </dx:ASPxGridView>     
                            
                          
                            
                            <asp:SqlDataSource ID="SqlDataSource_RangosMora" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdMora], [Minimo], [Maximo], [Porcentaje] FROM [Mora]"></asp:SqlDataSource>
                            
                          
                            
                        </ContentTemplate></asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
