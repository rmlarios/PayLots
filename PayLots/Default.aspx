<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="PayLots._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Content/material-dashboard.css" rel="stylesheet" />
    <link href="Content/w3.css" rel="stylesheet" />
    <script type="text/javascript">
        function FillDash(Proyectos,Lotes,Clientes,Pagos,PagosC) {
            document.getElementById("Proyectos").innerHTML = Proyectos;
            document.getElementById("Lotes").innerHTML = Lotes;
            document.getElementById("Clientes").innerHTML = Clientes;
            document.getElementById("Pagos").innerHTML = "U$" + Pagos + "/ C$" + PagosC;
          
        }
    </script>
    <style type="text/css">
        .icon {
        }

        .card-counter {
            box-shadow: 2px 2px 10px #DADADA;
            margin: 5px;
            padding: 20px 10px;
            background-color: #fff;
            height: 100px;
            border-radius: 5px;
            -webkit-transition: all .3s ease-in-out;
            transition: all .3s ease-in-out;
        }


        .card-counter {
            animation-duration: 1s;
            animation-delay: 1s;
            animation-name: slidein;
            animation-iteration-count: 1;
            opacity: 0;
            animation-fill-mode: forwards;
        }

        @keyframes slidein {
            0% {
                opacity: 0;
            }

            25%,75% {
                opacity: 1;
            }

            100% {
                opacity: 1;
            }
        }

        .animate-delay-2 {
            animation-delay: 2s;
        }

        .animate-delay-3 {
            animation-delay: 3s;
        }

        .card-counter:hover {
            box-shadow: 0px 2px 30px rgba(0, 0, 0, 0.3);
            -ms-transform: scale(1.3); /* IE 9 */
            -webkit-transform: scale(1.3); /* Safari 3-8 */
            transform: scale(1.3);
            z-index: 3000000;
        }

        .card-counter:hover {
            box-shadow: 4px 4px 20px #DADADA;
            transition: .3s linear all;
        }

        .card-counter.primary {
            background-color: #007bff;
            color: #FFF;
        }

        .card-counter.danger {
            background-color: #ef5350;
            color: #FFF;
        }

        .card-counter.success {
            background-color: #66bb6a;
            color: #FFF;
        }

        .card-counter.info {
            background-color: #26c6da;
            color: #FFF;
        }

        .card-counter i {
            font-size: 5em;
            opacity: 0.2;
        }

        .card-counter .count-numbers {
            position: absolute;
            right: 35px;
            top: 20px;
            font-size: 32px;
            display: block;
        }

        .card-counter .count-name {
            position: absolute;
            right: 35px;
            top: 65px;
            font-style: italic;
            text-transform: capitalize;
            opacity: 0.5;
            display: block;
            font-size: 18px;
        }
    </style>
    <style type="text/css">
        .card-stats {
            -webkit-transition: all .3s ease-in-out;
            transition: all .3s ease-in-out;
        }
         .card-stats:hover {
            box-shadow: 0px 2px 30px rgba(0, 0, 0, 0.3);
            -ms-transform: scale(1.3); /* IE 9 */
            -webkit-transform: scale(1.3); /* Safari 3-8 */
            transform: scale(1.3);
            z-index: 3000000;
        }
         .w3-animate-opacity {
    animation: opac 2s;
}

    </style>
    <style type="text/css">
        .label,.badge{display:inline-block;padding:2px 4px;font-size:11.844px;font-weight:bold;line-height:14px;color:#ffffff;vertical-align:baseline;white-space:nowrap;text-shadow:0 -1px 0 rgba(0, 0, 0, 0.25);background-color:#999999;}
.label{-webkit-border-radius:3px;-moz-border-radius:3px;border-radius:3px;}
.badge{padding-left:9px;padding-right:9px;-webkit-border-radius:9px;-moz-border-radius:9px;border-radius:9px;}
.Pago {background-color:#468847;}
.Pago:before{content:"\0024";}
.Asignación{background-color:#299be4;}
.Asignación:before{font-family: FontAwesome; content:"\f217";}
.Anular{background-color:#b94a48;}
.Anular:before{font-family: FontAwesome;content:"\f014";}
.dxgvADDC {  
    overflow: hidden;  
    white-space:inherit;
}
.dxbs-gridview > .card > .dxgvHSDC:first-child, .dxbs-gridview > .card > .dxgvHSDC + .dxgvCSD, .dxbs-gridview > .card > .dxgvCSD:first-child, .dxbs-gridview > .card > .dxgvCSD + .dxgvFSDC {
    /* border-top: 0; */
    margin-top:0px;
}

.dxbs-gridview .dxbs-fixed > thead > tr > th, .dxbs-gridview .dxbs-fixed > tbody > tr > td, .dxbs-gridview .dxbs-fixed > tfoot > tr > td {  
    overflow: hidden;  
    white-space:normal ;  
}

.dxbs-gridview > .card {
    display: block;
    margin-top: 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container-fluid w3-animate-opacity" style="padding-top: 1%;">
        <!--START CONTAINER-->

        <!--CARD COLORES-->
        <div class="row" style="display:none;">
            <div class="col-md-3">
                <div class="card-counter primary">
                    <i class="fa fa-code-fork"></i>
                    <span  class="count-numbers">2</span>
                    <span class="count-name">Proyectos</span>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card-counter danger animate-delay-2">
                    <i class="fa fa-ticket"></i>
                    <span class="count-numbers">750</span>
                    <span class="count-name">Lotes</span>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card-counter success  animate-delay-3">
                    <i class="fa fa-users"></i>
                    <span class="count-numbers">125</span>
                    <span class="count-name">Clientes</span>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card-counter info">
                    <i>
                        <img src="Content/Imagenes/pagos.png" height="80" width="85" /></i>
                    <span class="count-numbers">35</span>
                    <span class="count-name">Ingresos del día</span>
                </div>
            </div>
        </div>
        <!--FIN CARD COLORES-->

        <!--CARD FLOTANTES-->
        <div class="row">
            <div class="col-md-3">
                <div class="card card-stats">
                    <div class="card-header card-header-warning card-header-icon">
                        <div class="card-icon">
                            <i class=" fa fa-map-marker fa-2x"></i>
                        </div>
                        <p class="card-category">Proyectos</p>
                        <h3 class="card-title" id="Proyectos">#
                    
                  </h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="fa fa-location-arrow"></i>
                            <a href="Ubicaciones/Ubicaciones.aspx">Mas Información...</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card card-stats">
                    <div class="card-header card-header-success card-header-icon">
                        <div class="card-icon">
                            <i class=" fa fa-map fa-2x"></i>
                        </div>
                        <p class="card-category">Lotes</p>
                        <h3 class="card-title" id="Lotes">#
                    
                  </h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="fa fa-location-arrow"></i>
                            <a href="Lotes/Lotes.aspx">Mas Información...</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card card-stats">
                    <div class="card-header card-header-danger card-header-icon">
                        <div class="card-icon">
                            <i class="fa fa-2x fa-users"></i>
                        </div>
                        <p class="card-category" >Clientes</p>
                        <h3 class="card-title" id="Clientes">#
                    
                  </h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="fa fa-location-arrow"></i>
                            <a href="Beneficiarios/Beneficiarios.aspx">Mas Información...</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card card-stats">
                    <div class="card-header card-header-info card-header-icon">
                        <div class="card-icon">
                            
                            <i><img src="Content/Imagenes/pagos.png" height="50" width="56" /></i>
                        </div>
                        <p class="card-category" >Ingresos del día</p>
                        
                        <h3 class="card-title" id="Pagos">#</h3>
                       
                        
                    </div>
                    <div class="card-footer" style="margin-top:0;">
                        <div class="stats">
                            <i class="fa fa-location-arrow"></i>
                            <a href="Reportes/PagosFechas.aspx">Mas Información...</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--FIN CARD FLOTANTES-->

        <!--CARD GRAFICOS-->
        <div class="row" style="margin-top:-25px;">
            <div class="col-md-8">
                <div class="card card-chart">
                    <div class="card-header">
                        <h4 class="card-title">Pagos Diarios</h4>

                        <hr style="border: 0; border-bottom: 1px solid rgba(0,0,0,.1);" />
                    </div>
                    <div class="card-header card-header-white">
                        <div class="ct-chart" id="dailySalesChart">
                            <dx:BootstrapChart ID="Chart" runat="server" DataSourceID="SqlDataSource_PagosDiarios" EncodeHtml="True" ShowLoadingIndicator="True">
                                <CssClasses Control="ct-chart" />
                                <SettingsAnimation Enabled="true" Easing="EaseOutCubic" />
                                <SettingsLegend ColumnCount="1" HorizontalAlignment="Center" HoverMode="IncludePoints" Orientation="Horizontal" />
                                <SeriesCollection>
                                    <dx:BootstrapChartSplineSeries ArgumentField="Fecha" HoverMode="OnlyPoint" IgnoreEmptyPoints="True" Name="Ingresos diarios" SelectionMode="OnlyPoint" TagField="Moneda" ValueField="Pagado">
                                        <Label Position="Outside" Visible="false">
                                            <ArgumentFormat Type="Currency" />
                                        </Label>
                                        
                                    </dx:BootstrapChartSplineSeries>
                                </SeriesCollection>
                                <ArgumentAxis Label-DisplayMode="Stagger">
<Label DisplayMode="Stagger"></Label>
                                </ArgumentAxis>
                                <SettingsCommonAxis GridVisible="True" DiscreteAxisDivisionMode="CrossLabels" ></SettingsCommonAxis>
                                <SettingsZoomAndPan AllowTouchGestures="true" AllowMouseWheel="true"></SettingsZoomAndPan>
                                <SettingsToolTip Enabled="true" ZIndex="999999">
                                    <Format Type="Currency" Precision="1" />
                                </SettingsToolTip> 
                            </dx:BootstrapChart>
                            <asp:SqlDataSource ID="SqlDataSource_PagosDiarios" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="select top(7) sum(MontoPago+Interés+Mora) Pagado, convert(varchar,convert(date,FechaRecibo)) Fecha  from Pagos group by convert(date,FechaRecibo) order by convert(date,FechaRecibo) desc"></asp:SqlDataSource>
                        </div>
                    </div>


                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-chart">
                    <div class="card-header">
                        <h4 class="card-title">Recaudado por Proyecto</h4>
                        <p class="card-category">
                            <span class="text-success"><i class="fa fa-clock-o"></i>Actualizado al:</span><%: DateTime.Now.ToLongDateString() %>
                        </p>
                    </div>
                    <div class="card-header card-header-white">
                        <div class="ct-chart">
                            <dx:BootstrapPieChart ID="PieChart" runat="server" DataSourceID="SqlDataSource_GraficoPie" EncodeHtml="True" Palette="Office">
                                <SettingsLegend ColumnCount="2" HorizontalAlignment="Center" HoverMode="IncludePoints" Orientation="Horizontal" />
                                <SeriesCollection>
                                    <dx:BootstrapPieChartSeries ArgumentField="NombreProyecto" ValueField="Pagado">

                                        <Label Visible="true" Position="Inside">
                                            <ArgumentFormat Type="Currency" />

                                        </Label>
                                    </dx:BootstrapPieChartSeries>
                                </SeriesCollection>
                            </dx:BootstrapPieChart>
                            <asp:SqlDataSource ID="SqlDataSource_GraficoPie" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [NombreProyecto], SUM([Pagado]) Pagado FROM [View_GraficoPagos] GROUP BY NombreProyecto"></asp:SqlDataSource>
                            
                        </div>
                    </div>


                </div>
            </div>
        </div>
        <!--FIN CARD GRAFICOS-->

        <!--CARD GRIDS-->
        <div class="row">
             <div class="col-md-12">
              <div class="card">
                <div class="card-header card-header-success" style="background-color:#299be4;">
                  <h4 class="card-title ">Seguimientos</h4>
                  <p class="card-category"> Acciones realizadas en el sistema.</p>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                <dx:BootstrapGridView ID="GridSeguimientos" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="IdSeguimiento" DataSourceID="SqlDataSource_Seguimientos">
                    <CssClasses Control="table" HeaderRow="thead-light" Table="table table-hover" />
                    <SettingsBootstrap Striped="true" Sizing="Small" />
                    
                    <Settings ShowHeaderFilterButton="true" ShowFilterRow="false" HorizontalScrollBarMode="Auto" />
                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowHideDataCellsByColumnMinWidth="true" HideDataCellsAtWindowInnerWidth="Small">
                        <AdaptiveDetailLayoutProperties LayoutType="Vertical"></AdaptiveDetailLayoutProperties>
                    </SettingsAdaptivity>
                    <SettingsPager Mode="EndlessPaging"></SettingsPager>
                    <SettingsBehavior AllowSort="true" AllowHeaderFilter="true" FilterRowMode="Auto" AllowSelectByRowClick="true" />
                    <Columns>
                        <dx:BootstrapGridViewTextColumn FieldName="IdSeguimiento" Visible="false" Caption="IdSeguimiento" VisibleIndex="0">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewDataColumn FieldName="Tipo" Visible="true" Width="10%" MinWidth="80" Caption="Tipo" VisibleIndex="1">
                            <DataItemTemplate>
                              
                                <span class="label label-important  <%# Eval("Tipo") %>"><%#string.Concat(" ",Eval("Tipo"))%></span>
                            </DataItemTemplate>
                        </dx:BootstrapGridViewDataColumn>
                        <dx:BootstrapGridViewDateColumn FieldName="FAR" Width="10%" Caption="Fecha" PropertiesDateEdit-DisplayFormatString="" SortOrder="Descending" VisibleIndex="2">
<PropertiesDateEdit DisplayFormatString="" EditFormat="DateTime"></PropertiesDateEdit>

                            <SettingsHeaderFilter Mode="DateRangePicker"></SettingsHeaderFilter>
                        </dx:BootstrapGridViewDateColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="UAR" Width="15%" Caption="Usuario" Settings-FilterMode="DisplayText" VisibleIndex="3">
<Settings FilterMode="DisplayText"></Settings>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="Observaciones" MinWidth="600" AllowTextTruncationInAdaptiveMode="true" HorizontalAlign="Left" Width="65%" VisibleIndex="4">
                            
                        </dx:BootstrapGridViewTextColumn>
                    </Columns>
                   
                </dx:BootstrapGridView>
                     </div>
                <asp:SqlDataSource ID="SqlDataSource_Seguimientos" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT IdSeguimiento,[FAR], [UAR], [Observaciones],[Tipo] FROM [Seguimientos]"></asp:SqlDataSource>
                    </div>
                  </div>
                 
            </div>
        </div>
        
        <!--FIN CARD GRIDS-->



        <!--END CONTAINER-->
    </div>




</asp:Content>
