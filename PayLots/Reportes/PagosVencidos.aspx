<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="PagosVencidos.aspx.cs" Inherits="PayLots.Reportes.PagosVencidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="card ">
        <div class="card-header main">Beneficirarios en Mora</div>
        <div class="card-body">
               <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
                            <dx:ASPxGridView ID="GridView_PlanPago" ClientInstanceName="gridPlanPago" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_PagosVencidos" EnableTheming="True" Theme="MaterialCompact" Width="100%" OnCustomButtonCallback="GridView_PlanPago_CustomButtonCallback">
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
                                  <dx:GridViewDataTextColumn FieldName="IdAsignacion" Visible="False" VisibleIndex="1">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="Beneficiario" VisibleIndex="2">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="Cuotas" Caption="Cuotas Vencidas" VisibleIndex="3">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="Telefono" VisibleIndex="4">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn Caption="Lote" FieldName="NombreLote" VisibleIndex="5">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="Ubicacion" VisibleIndex="6">
                                  </dx:GridViewDataTextColumn>
                                  

                                  <dx:GridViewCommandColumn VisibleIndex="0" ButtonRenderMode="Image">
                                      <CustomButtons>
                                          <dx:GridViewCommandColumnCustomButton ID="EstadoCuenta" Image-ToolTip="Ver Estado de Cuenta">
                                              <Image IconID="numberformats_accounting_32x32">
                                              </Image>
                                          </dx:GridViewCommandColumnCustomButton>
                                      </CustomButtons>
                                  </dx:GridViewCommandColumn>

                              </Columns>
                                <Styles>
                                    <Header Wrap="true" ForeColor="#1d3757" HorizontalAlign="Center"></Header>

                                </Styles>
                            </dx:ASPxGridView>     
                           
                            <asp:SqlDataSource ID="SqlDataSource_PagosVencidos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT IdAsignacion,Beneficiario,Telefono,NombreLote,Ubicacion,CuotasRequeridas-Cuotas as Cuotas FROM View_Reporte_Morosos WHERE CuotasRequeridas>Cuotas">
                                
                            </asp:SqlDataSource>
                           
                        </ContentTemplate></asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
