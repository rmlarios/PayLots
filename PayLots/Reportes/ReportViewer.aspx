<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ReportViewer.aspx.cs" Inherits="PayLots.Reportes.ReportViewer" %>

<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta name="viewport" content="width=device-width,inicial-scale=1,user-scalabe=0" />
    <script type="text/javascript">
        function onInit(s, e) {  
    var previewModel = s.GetPreviewModel();  
    previewModel.tabPanel.collapsed(false);  
    previewModel.tabPanel.tabs[0].active(true);  
}
    </script>
</asp:Content>
    



    <asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
         <dx:ASPxWebDocumentViewer ID="WebDocumentViewer" runat="server" AllowURLsWithJSContent="True" ColorScheme="darkmoon">
             <ClientSideEvents Init="onInit" />
         </dx:ASPxWebDocumentViewer>
    

        </asp:Content>

