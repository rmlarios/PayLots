<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ConsolidadoPagos.aspx.cs" Inherits="PayLots.Pagos.ConsolidadoPagos" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        cellWidthConcat {
            width: 300px;
            max-width: 300px;
            min-width: 300px;
            background-color: blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
   
           
    <dx:ASPxFloatingActionButton ID="ASPxFloatingActionButton1" InitialActionContext="Exportar" VerticalPosition="Top" ClientInstanceName="fab" TextVisibilityMode="Always" ContainerElementID="pivot" runat="server" EnableTheming="True" Theme="MaterialCompact">
        <ClientSideEvents ActionItemClick="function(s,e){if (e.actionName=='ExportXLSX') btnExportarXLSX.DoClick(); else if (e.actionName=='ExportPDF') btnExportarPDF.DoClick();
            }" />
        <Items>
            <dx:FABActionGroup ContextName="Exportar" Text="Exportar">
                <Items>
                    <dx:FABActionItem ActionName="ExportXLSX" Text="Exportar XLSX">
                        <Image Height="32px" Url="~/Content/Imagenes/xlsx-icon-7.png" Width="32px">
                        </Image>
                    </dx:FABActionItem>
                    <dx:FABActionItem ActionName="ExportPDF" Text="Exportar PDF">
                        <Image Height="32px" Url="~/Content/Imagenes/adobe-acrobat-pdf-file-512.png" Width="32px">
                        </Image>
                    </dx:FABActionItem>
                </Items>

            </dx:FABActionGroup>
        </Items>
    </dx:ASPxFloatingActionButton>
       
    <dx:ASPxButton runat="server" ClientInstanceName="btnExportarXLSX" ID="Btn_ExportarXLSX" AutoPostBack="false" ClientVisible="false" OnClick="Btn_ExportarXLSX_Click"></dx:ASPxButton>
    <dx:ASPxButton runat="server" ClientInstanceName="btnExportarPDF" ID="Btn_ExportarPDF" AutoPostBack="false" ClientVisible="false" OnClick="Btn_ExportarPDF_Click"></dx:ASPxButton>
     
    <dx:ASPxPivotGridExporter ID="Exporter" OptionsPrint-MergeColumnFieldValues="True" runat="server"></dx:ASPxPivotGridExporter>

    <asp:UpdatePanel ID="UdpPivot" runat="server">
        <ContentTemplate>




            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" ClientInstanceName="pivot" runat="server" Width="100%" ClientIDMode="AutoID" DataSourceID="SqlDataSource_Pivot" EnableTheming="True" Theme="Moderno" OnCustomFieldSort="ASPxPivotGrid1_CustomFieldSort">
                
                <Fields>


                    <dx:PivotGridField ID="fieldTotalRecibo" Area="DataArea" AreaIndex="0" FieldName="TotalRecibo" Name="fieldTotalRecibo">
                    </dx:PivotGridField>

                    <dx:PivotGridField ID="fieldNombreCompleto" Area="RowArea" AreaIndex="1" FieldName="Concat" Caption="Lote/Propietario" CellStyle-CssClass="cellWidthConcat" Name="fieldNombreCompleto" Width="650">
                        <ValueTemplate>
                            <dx:ASPxLabel runat="server" ID="lblConcat" ClientInstanceName="lblConcat" Width="300px" OnDataBinding="lblConcat_DataBinding"></dx:ASPxLabel>
                        </ValueTemplate>
                    </dx:PivotGridField>
                    <dx:PivotGridField ID="fieldNombreLote" Area="RowArea" Visible="False" AreaIndex="0" FieldName="NombreLote" Name="fieldNombreLote">
                    </dx:PivotGridField>
                    <dx:PivotGridField ID="fieldNombreProyecto" AreaIndex="0" FieldName="NombreProyecto" Name="fieldNombreProyecto">
                    </dx:PivotGridField>
                    <dx:PivotGridField ID="fieldMesPagado" Area="ColumnArea" SortMode="Custom" AreaIndex="0" FieldName="MesPagado" Name="fieldMesPagado">
                    </dx:PivotGridField>






                </Fields>
                <Styles>

                    <RowFieldValuesAreaStyle Wrap="true" CssClass="cellWidthConcat"></RowFieldValuesAreaStyle>
                </Styles>
                <OptionsView ColumnTotalsLocation="Near" HorizontalScrollBarMode="Visible" ShowRowHeaders="true" />
                <OptionsPager RowsPerPage="10"></OptionsPager>
            </dx:ASPxPivotGrid>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSource_Pivot" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT IdAsignacion,NombreLote + ' - ' +ISNULL(Grupo,'') + ' ' + NombreCompleto AS Concat ,  NombreCompleto, NombreLote + ' - ' +ISNULL(Grupo,'') as NombreLote, MesPagado, TotalRecibo, NombreProyecto, IdPago FROM View_Pagos_Asignaciones WHERE (MesPagado IS NOT NULL)"></asp:SqlDataSource>

</asp:Content>
