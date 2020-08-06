<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="PagosFechas.aspx.cs" Inherits="PayLots.Reportes.PagosFechas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="card" style="width: 100%;">
                <div class="card-header">Pagos por Fechas</div>
                <div class="card-body">
                    <div class="row">
                        <dx:ASPxFloatingActionButton ID="ASPxFloatingActionButton1" InitialActionContext="Imprimir" ClientInstanceName="fab" ContainerElementID="chart" runat="server" EnableTheming="True" Theme="MaterialCompact">
                            <ClientSideEvents ActionItemClick="function(s,e){btnImprimir.DoClick();}" />
                            <Items>
                                <dx:FABAction ContextName="Imprimir" Text="Ver Reporte" Image-ToolTip="Imprimir Reporte" ActionName="Imprimir">
                                    
<Image ToolTip="Imprimir Reporte" AlternateText="Ver Reporte" Height="32px" Url="~/Content/Imagenes/report.png" Width="32px"></Image>
                                    
                                </dx:FABAction>
                            </Items>
                        </dx:ASPxFloatingActionButton>
                        <div class="col-md-12" id="chart">
                            <asp:UpdatePanel ID="UdpGrafico" runat="server"><ContentTemplate>
                            <dx:BootstrapPieChart ID="BootstrapPieChart1" ClientInstanceName="pieChart"  runat="server" DataSourceID="SqlDataSource_Grafico" EncodeHtml="True" Palette="Office" TitleText="Pagos por Proyecto y Fecha">
                                
                                <SeriesCollection>
                                    <dx:BootstrapPieChartSeries ArgumentField="NombreProyecto" ValueField="Pagado">
                                        
                                        <Label  Visible="true">
                                            <Format Type="Decimal" />
                                        </Label>
                                    </dx:BootstrapPieChartSeries>
                                </SeriesCollection>
                                <SettingsLegend ColumnCount="1" />
                                <SettingsExport Enabled="True" ExportButtonText="Exportar" FileName="PagosProyecto" />
                            </dx:BootstrapPieChart>
                                </ContentTemplate></asp:UpdatePanel>
                            <asp:SqlDataSource ID="SqlDataSource_Grafico" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="select NombreProyecto,sum(Pagado) as Pagado from View_GraficoPagos group by NombreProyecto">
                               
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row" style="text-align:left;height:40%">
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                            <dx:BootstrapCalendar ID="BootstrapCalendar1" ClearButtonText="Limpiar Selección"  AutoPostBack="true" OnSelectionChanged="BootstrapCalendar1_SelectionChanged" EnableMultiSelect="true" Width="100%" runat="server" TodayButtonText="Hoy"></dx:BootstrapCalendar>
                                </ContentTemplate></asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row" style="padding-top:10px;">
                        <div class="col-md"></div>
                        <div class="col-md">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                            <dx:BootstrapButton runat="server" OnClick="Btn_Imprimir_Click" ClientVisible="false" ClientInstanceName="btnImprimir" ID="Btn_Imprimir" Text="Vista Previa" CssClasses-Icon="fa fa-print" SettingsBootstrap-RenderOption="Primary" Width="100%" AutoPostBack="false"></dx:BootstrapButton> 
                                </ContentTemplate></asp:UpdatePanel>
                        </div>
                        <div class="col-md"></div>
                    </div>
                </div>
                </div>
            </div>
        </div>
</asp:Content>
