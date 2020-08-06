<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PayLots.Dashboard" %>
<%@ Register Assembly="DevExpress.Dashboard.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <script type="text/javascript">
    function onBeforeRender(sender) {
        var control = sender.GetDashboardControl();
        /*control.registerExtension(new DevExpress.Dashboard.DashboardPanelExtension(control, { dashboardThumbnail: "./Content/DashboardThumbnail/{0}.png" }));*/
    }
</script>
    <div class="container-fluid" style="height:98vh">
       <dx:ASPxDashboard ID="ASPxDashboard1" WorkingMode="Viewer" ImageExportOptions-ExportFilters="true" UseCardLegacyLayout="true" runat="server" Width="100%" Height="100%" ColorScheme="light.compact" UseNeutralFilterMode="true">
        <ClientSideEvents BeforeRender="onBeforeRender" />
    </dx:ASPxDashboard>
           </div>
</asp:Content>
