<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="RegistrarPago.aspx.cs" Inherits="PayLots.Pagos.RegistrarPago" %>

<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web.WebDocumentViewer" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Botones.css" rel="stylesheet" />
    <link href="../Content/PrintIcon.css" rel="stylesheet" />
    <script type="text/javascript">
         function printReport() {
            //btnPrint.DoClick();
             //webViewer.Print();
             //popTicket.Show();
        }
    </script>
    <style>
      /*.form-control[readonly] {
    background-color: #b1cce6;
    opacity: 1;
}*/

         .row
        {
            padding-bottom:1%;
            text-align:left;
            overflow-wrap:initial;
            width:100%;
            
        }

        .fa.m {
            color:#060688;
        }

        .col-md-2 {
            /*padding-left:0px;*/
        }

        
              
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="card ">
        <div class="card-header main" id="cardheader">REGISTRAR PAGO DE CUOTA</div>
          <div class="card-body" style="padding-bottom:0px;" id="bodycard">
            <div class="container-fluid" id="contenido">
               
                <div class="row" style="text-align:center;"> <%--style="text-align:center;position:fixed;z-index:25000;"--%>
                    <div class="col-md-4 button-group btn-group">
                         <asp:UpdatePanel ID="UdpBotones" runat="server"><ContentTemplate>
                        
                        <dx:BootstrapButton ID="Btn_Nuevo" Width="45%" ToolTip="Nuevo Recibo"  runat="server" OnClick="Btn_Nuevo_Click" AutoPostBack="false" Text="Nuevo" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-file-o fa-2x"></dx:BootstrapButton>
                        <dx:BootstrapButton ID="Btn_Cancelar" Width="45%" runat="server" OnClick="Btn_Cancelar_Click"  Text="Cancelar" AutoPostBack="false" CssClasses-Control="small blue button" CssClasses-Icon="fa fa-ban fa-2x"></dx:BootstrapButton>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    <div class="col-md-1">
                        <asp:UpdatePanel ID="UdplblIdPago" runat="server">
                            <ContentTemplate>
                                <dx:ASPxLabel ID="lblIdPago" runat="server" ClientVisible="false"></dx:ASPxLabel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-1">
                        <asp:UpdatePanel ID="UdplblIdAsig" runat="server">
                            <ContentTemplate>
                                <dx:ASPxLabel ID="lblIdAsignacion" runat="server" Visible="true" ClientVisible="false"></dx:ASPxLabel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                
                <div class="row">
                   
                    
                    <div class="col-md-12">
                        Lote:&nbsp; 
                        <asp:UpdatePanel ID="UdpLote" runat="server"><ContentTemplate>
                             
                        <dx:BootstrapComboBox ID="ComboBox_Lotes" AutoPostBack="true" OnSelectedIndexChanged="ComboBox_Lotes_SelectedIndexChanged" Width="100%" runat="server" DataSourceID="SqlDataSource_Lotes" ValueField="IdLote" TextField="NombreLote" ValueType="System.Int32" TextFormatString="{0}; {1}">
                            <ClearButton DisplayMode="Always" />
                            <Fields>
                                
                                <dx:BootstrapListBoxField FieldName="NombreLote" />
                                <dx:BootstrapListBoxField FieldName="Ubicacion" />
                            </Fields>
                        </dx:BootstrapComboBox>
                            </ContentTemplate></asp:UpdatePanel>
                        <asp:SqlDataSource ID="SqlDataSource_Lotes" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT IdLote,IdAsignacion,NombreLote +' ' +ISNULL(Grupo,'') NombreLote,NombreProyecto+' ' + Municipio + ', ' + Departamento +'. Dueño: '+ NombreCompleto AS Ubicacion FROM [View_Asignaciones_Lotes] where Estado='Vigente'"></asp:SqlDataSource>
                    </div>
                    
                        <asp:UpdatePanel ID="UdpBenef" runat="server">
                            <ContentTemplate> 
                                <dx:BootstrapTextBox ID="TextBoxBeneficiario" Visible="false" runat="server" Width="0%" ReadOnly="true"></dx:BootstrapTextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
              <%--  </div>--%>
               <%-- <div class="row" style="display:none;">
                    
                    <div class="col-md-2">
                        Monto:
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapSpinEdit ID="SpinEdit_Monto" ReadOnly="true" Width="100%" NumberType="Float" runat="server" DecimalPlaces="2" MinValue="1" MaxValue="100000" DisplayFormatString="N2">
                        </dx:BootstrapSpinEdit>
                    </div>
                    <div class="col-md-2" style="text-align:left;">
                        Fecha Inicial:
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapTextBox ID="TextBox_FechaInicio" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2">
                        Cuota Mínima:
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapSpinEdit ID="SpinEdit_Cuota" ReadOnly="true" Width="100%" runat="server" DecimalPlaces="2" MinValue="1" MaxValue="100000" DisplayFormatString="N2"></dx:BootstrapSpinEdit>
                    </div>

                </div>--%>
                <div class="row">
                     
                    <div class="col-md ">
                        Valor Lote:&nbsp;
                        <asp:UpdatePanel runat="server" ID="UdpValor"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_ValorLote" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                  
                    <div class="col-md ">
                        Prima:&nbsp;
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Prima" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                          </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    <div class="col-md ">
                        Abonado: &nbsp;
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Abonado" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    <div class="col-md ">
                        Saldo:&nbsp;
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Saldo" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                   
                </div>
                <div class="row text-center" style="padding-bottom:0px;">
                    <div class="col-md-12">
                <div class="card">
                    <div class="card-body" style="padding:10px;">
                        Detalle del Pago
                    </div>
                </div>
                    </div>
                    </div>
                <div class="row" style="padding-top:1%">
                    
                    <div class="col-md-3">
                        Mes: &nbsp;
                        <asp:UpdatePanel ID="UdpMes" runat="server"><ContentTemplate>
                         <dx:BootstrapComboBox ID="ComboBox_MesPagar" CaptionSettings-Position="Before" OnSelectedIndexChanged="ComboBox_MesPagar_SelectedIndexChanged" AutoPostBack="True" Width="100%" runat="server" DataSourceID="SqlDataSource_Meses" TextField="MesPagado" ValueField="MesPagado" DisplayFormatString="{0}" TextFormatString="{0}">
                             <Fields>
                                 <dx:BootstrapListBoxField FieldName="MesPagado" />
                                 <dx:BootstrapListBoxField FieldName="MontoMinimo" />
                                 <dx:BootstrapListBoxField FieldName="Interes" />
                                 <dx:BootstrapListBoxField FieldName="Mora" />
                                 <dx:BootstrapListBoxField FieldName="TotalPagar" />
                             </Fields>
                            <ClearButton DisplayMode="Always" />
                        </dx:BootstrapComboBox>
                            </ContentTemplate></asp:UpdatePanel>
                         <asp:SqlDataSource ID="SqlDataSource_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT MesPagado,Estado,MontoMinimo,ISNULL(Interes,0) Interes,ISNULL(Mora,0) Mora,TotalPagar FROM FN_Asignacion_PlandePago(@IdAsignacion) WHERE (MesPagado!='Prima' and Estado !='Cancelado') OR MesPagado= (SELECT MesPagado FROM Pagos WHERE IdPago=@IdPago)">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="lblIdAsignacion" Name="IdAsignacion" PropertyName="Text"/>
                                 <asp:ControlParameter ControlID="lblIdPago" Name="IdPago" PropertyName="Text" />
                             </SelectParameters>
                         </asp:SqlDataSource>
                    </div>
                   
                    <div class="col-md">
                        Principal:&nbsp;
                        <asp:UpdatePanel ID="UdpMonCuota" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_MontoCuota" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    <div class="col-md">
                        Mora:&nbsp;
                        <asp:UpdatePanel ID="UdpMora" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_MoraMes" ReadOnly="true" runat="server" Width="100%" ></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    <div class="col-md">
                        Interés:&nbsp;
                        <asp:UpdatePanel ID="UdpInteres" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Interés" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                   
                    <div class="col-md">
                        Total:&nbsp;
                        <asp:UpdatePanel ID="uDPtotal" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_TOTAL" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                     
                </div>
                <div class="row" style="color:blue;font-weight:bold;align-items:center;">
                    
                    <div class="col-md">
                        No. Recibo:
                        <asp:UpdatePanel ID="UdpRecibo" runat="server"><ContentTemplate>
                        <dx:BootstrapTextBox ID="TextBox_Recibo" ReadOnly="true" runat="server" Width="100%"></dx:BootstrapTextBox>
                        </ContentTemplate></asp:UpdatePanel>
                    </div>
                 
                    <div class="col-md">
                        Fecha Recibo:
                        <asp:UpdatePanel ID="UdpFechaRecibo" runat="server"><ContentTemplate>
                        <dx:BootstrapDateEdit ID="DateEdit_FechaRecibo" runat="server" Width="100%"></dx:BootstrapDateEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md">
                        Moneda:
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                       <dx:BootstrapComboBox ID="ComboBox_Moneda" runat="server" ClientInstanceName="cboMoneda">
                           <Items>
                               <dx:BootstrapListEditItem Value="Dólares" Text="Dólares" Selected="true"></dx:BootstrapListEditItem>
                               <dx:BootstrapListEditItem Value="Córdobas" Text="Córdobas"></dx:BootstrapListEditItem>
                           </Items>
                           <ClientSideEvents ValueChanged="function(s,e){
                               var m= s.GetText();
                               if (m=='Córdobas')
                                spinTC.SetEnabled(true);
                               else
                                spinTC.SetEnabled(false);
                               }" />
                       </dx:BootstrapComboBox>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md">
                        T/C:
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEditTasaCambio" ClientInstanceName="spinTC" ClientEnabled="false" Width="100%" runat="server" DecimalPlaces="2" MinValue="2" MaxValue="100000" DisplayFormatString="N2"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                    <div class="col-md">
                        Total Pagado:
                        <asp:UpdatePanel ID="UdpPagado" runat="server"><ContentTemplate>
                        <dx:BootstrapSpinEdit ID="SpinEditMontoPagado" Width="100%" runat="server" DecimalPlaces="2" MinValue="1" MaxValue="100000" DisplayFormatString="N2"></dx:BootstrapSpinEdit>
                            </ContentTemplate></asp:UpdatePanel>
                    </div>
                    <div class="col-md">
                        Observaciones:
                        <asp:UpdatePanel ID="UdpObservaciones" runat="server"><ContentTemplate>
                            <dx:BootstrapTextBox ID="TextBox_Observaciones" runat="server" Width="100%"></dx:BootstrapTextBox>
                        </ContentTemplate></asp:UpdatePanel>
                    </div>
                    
                 </div>
                <div class="row" style="text-align:center">
                    <div class="col-md-5"></div>
                    <div class="col-md-2 button-group btn-group justify-content-center">
                        <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="Callback">
                            <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); }" />
                        </dx:ASPxCallback>
                        <asp:UpdatePanel runat="server" ID="UdpPagar"><ContentTemplate>
                        <dx:ASPxButton ID="BtnCobrar" ClientInstanceName="BtnCobrar" Width="100%" OnClick="BtnCobrar_Click" AutoPostBack="false" runat="server" Text="Cobrar" CssClass="small green button">
                            <Image Url="../Content/Imagenes/pagos.png" Height="32px" Width="32px"></Image>
                             <ClientSideEvents Click="function(s, e) {
                       
                        LoadingPanel.Show();
                    }" />
                        </dx:ASPxButton>
                            <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="True" ContainerElementID="BtnCobrar"></dx:ASPxLoadingPanel>
                            </ContentTemplate></asp:UpdatePanel>
                        
                        
                    </div>
                    <div class="col-md-5"></div>
                </div>
                
                <div class="row" style="text-align:center;">
                    <div class="col-md-12">
                        <div class="card-header" style="background-color:#cecece">Pagos Realizados</div>
                        <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
                            <dx:ASPxGridView ID="GridView_Pagos" ClientInstanceName="gridPagos" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" KeyFieldName="IdPago" EnableTheming="True" Width="100%" DataSourceID="SqlDataSource_Pagos" OnCustomButtonCallback="GridView_Pagos_CustomButtonCallback" OnRowDeleting="GridView_Pagos_RowDeleting" OnStartRowEditing="GridView_Pagos_StartRowEditing">
                                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="HistoricoPago"></SettingsExport>
                                <SettingsDataSecurity AllowInsert="false" AllowDelete="true" AllowEdit="true" />
                                <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" AllowSelectByRowClick="True" />
                                <ClientSideEvents RowDblClick="function(s,e){gridPagos.StartEditRow(e.visibleIndex);}" />
                                <Toolbars>
                                    <dx:GridViewToolbar Position="Top" ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="ExportToXlsx" ></dx:GridViewToolbarItem>
                                            <dx:GridViewToolbarItem Command="ExportToPdf"></dx:GridViewToolbarItem>
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars> 
                                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="WYSIWYG" FileName="PagosRealizados"></SettingsExport>
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
                                <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit" ColCount="2" ColumnCount="2">
                                    <Items>
                                       <dx:EditModeCommandLayoutItem ColSpan="1" HorizontalAlign="Right" Width="100%"></dx:EditModeCommandLayoutItem>
                                    </Items>

                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                                    </SettingsAdaptivity>

                                </EditFormLayoutProperties>
                              <Columns>
                                  <dx:GridViewDataTextColumn FieldName="IdPago" ReadOnly="True" Visible="False" VisibleIndex="0">
                                      <EditFormSettings Visible="False" />
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="IdAsignacion" Visible="False" VisibleIndex="1">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataDateColumn FieldName="FAR" Visible="false" SortIndex="0" SortOrder="Descending">
                                  </dx:GridViewDataDateColumn>
                                  <dx:GridViewDataTextColumn FieldName="MesPagado" VisibleIndex="3">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="NumeroRecibo" VisibleIndex="4">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataDateColumn FieldName="FechaRecibo" VisibleIndex="5">
                                  </dx:GridViewDataDateColumn>
                                  <dx:GridViewDataTextColumn FieldName="MontoPago" VisibleIndex="6">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="Mora" VisibleIndex="7">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="Interés" VisibleIndex="8">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalPagado" UnboundExpression="[MontoPago] + [Interés] + [Mora]" UnboundType="Decimal" VisibleIndex="9">
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewCommandColumn ShowDeleteButton="true" ShowEditButton="true" ButtonRenderMode="Image" ButtonType="Image" VisibleIndex="2">
                                      <CustomButtons>
                                          <dx:GridViewCommandColumnCustomButton ID="Ticket">
                                              <Image IconID="print_printer_32x32">
                                              </Image>
                                          </dx:GridViewCommandColumnCustomButton>
                                      </CustomButtons>
                                  </dx:GridViewCommandColumn>

                              </Columns>
                                <TotalSummary>
                                    <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="MontoPago" ShowInColumn="MontoPago" SummaryType="Sum" ValueDisplayFormat="N2" />
                                    <dx:ASPxSummaryItem DisplayFormat="{0}" FieldName="TotalPagado" ShowInColumn="TotalPagado" SummaryType="Sum" ValueDisplayFormat="N2" />
                                </TotalSummary>
                                <Styles>
                                    <Header Wrap="true" ForeColor="#1d3757" HorizontalAlign="Center"></Header>

                                </Styles>
                            </dx:ASPxGridView>     
                            
                            <asp:SqlDataSource ID="SqlDataSource_Pagos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdPago],[IdAsignacion], [MesPagado], [NumeroRecibo], [FechaRecibo], [MontoPago], [Mora], [Interés],[FAR] FROM [Pagos] WHERE IdAsignacion = @IdAsignacion">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblIdAsignacion" Name="IdAsignacion" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            
                        </ContentTemplate></asp:UpdatePanel>
                    </div>
                </div>
                
            </div>
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
    <dx:ASPxButton ID="Btn_PrintReport" runat="server" ClientInstanceName="btnPrint" AutoPostBack="false" ClientVisible="false" OnClick="Btn_PrintReport_Click"></dx:ASPxButton>
</asp:Content>
