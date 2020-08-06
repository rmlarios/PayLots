<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ReportDesigner.aspx.cs" Inherits="PayLots.Reportes.ReportDesigner" %>

<%@ Register Assembly="DevExpress.XtraReports.v18.2.Web.WebForms, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxReportDesigner ID="ASPxReportDesigner1" runat="server" AllowMDI="true" ValidateRequestMode="Disabled" SettingsWizard-UseMasterDetailWizard="true">
    </dx:ASPxReportDesigner>
</asp:Content>
