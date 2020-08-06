<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="RegistroErrores.aspx.cs" Inherits="PayLots.Auditoria.RegistroErrores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="card ">
      <div class="card-header main">AUDITORIA</div>
      <div class="card-body">
          <div class="col-md-1"></div>
          <div class="col-md-10">
    <dx:BootstrapPageControl ID="BootstrapPageControl1" EnableTheming="true" Width="100%" runat="server" ActiveTabIndex="1">
        <TabPages>
            <dx:BootstrapTabPage Text="Errores Sistema">
                <ContentCollection>
                    <dx:ContentControl>
                         <dx:ASPxGridView ID="GridViewErroresSistema" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_ErroresSistema" KeyFieldName="IdErrorSistema">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="Error" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="Fecha" VisibleIndex="1">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Usuario" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Pantalla" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CodError" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IdErrorSistema" ReadOnly="True" VisibleIndex="5">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource_ErroresSistema" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [Error], [Fecha], [Usuario], [Pantalla], [CodError], [IdErrorSistema] FROM [ErroresSistema]"></asp:SqlDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapTabPage>
            <dx:BootstrapTabPage Text="Errores SQL">
                <ContentCollection>
                    <dx:ContentControl>
                         <dx:ASPxGridView ID="GridViewErroresSQL" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_ErroresSQL" KeyFieldName="IdErrorSQL">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="IdErrorSQL" VisibleIndex="0" ReadOnly="True">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ErrorSQL" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IdentityUser" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="Fecha" VisibleIndex="3">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
                         <asp:SqlDataSource ID="SqlDataSource_ErroresSQL" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [IdErrorSQL], [ErrorSQL], [IdentityUser], [Fecha] FROM [ErrorSQL]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [Error], [Fecha], [Usuario], [Pantalla], [CodError], [IdErrorSistema] FROM [ErroresSistema]"></asp:SqlDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:BootstrapTabPage>
        </TabPages>
    </dx:BootstrapPageControl>
              </div>
          <div class="col-md-1"></div>
   </div>
         </div>
</asp:Content>
