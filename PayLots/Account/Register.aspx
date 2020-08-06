<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Register.aspx.cs" Inherits="PayLots.Register" %>

<asp:content id="ClientArea" contentplaceholderid="Content" runat="server">
    <div class="card ">
      <div class="card-header main">Administrar Usuarios</div>
      <div class="card-body">
   
                    <asp:UpdatePanel ID="UdpGrid" runat="server"><ContentTemplate>
    <dx:ASPxGridView ID="GridView_Usuarios" Caption="Usuarios del Sistema" ClientInstanceName="gridUsuarios" EnableCallBacks="False" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_Usuarios" KeyFieldName="UserId" EnableTheming="True" Theme="MaterialCompact" Width="100%"
      OnRowInserting="GridView_Usuarios_RowInserting" OnRowUpdating="GridView_Usuarios_RowUpdating" OnRowDeleting="GridView_Usuarios_RowDeleting">
        <ClientSideEvents RowDblClick="function(s,e){gridUsuarios.StartEditRow(e.visibleIndex);}" />
        <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true"/>
        <SettingsBehavior AutoFilterRowInputDelay="500" FilterRowMode="Auto" ConfirmDelete="True" />
        
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
        <SettingsAdaptivity AdaptivityMode="HideDataCells">
            <AdaptiveDetailLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" />
            </AdaptiveDetailLayoutProperties>
        </SettingsAdaptivity>
        <SettingsPager PageSize="10">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowHeaderFilterButton="true" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" />
        <SettingsText SearchPanelEditorNullText="Buscar..." />
        <SettingsSearchPanel Visible="True" />
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        
        <SettingsPopup EditForm-MinWidth="200px" EditForm-CloseOnEscape="False" EditForm-SettingsAdaptivity-Mode="OnWindowInnerWidth" HeaderFilter-SettingsAdaptivity-Mode="OnWindowInnerWidth" EditForm-Modal="true" EditForm-VerticalAlign="WindowCenter" EditForm-HorizontalAlign="WindowCenter">
            <EditForm MinWidth="200px" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="True" CloseOnEscape="False">
                <SettingsAdaptivity Mode="OnWindowInnerWidth"></SettingsAdaptivity>
            </EditForm>
        </SettingsPopup>
        <EditFormLayoutProperties SettingsAdaptivity-AdaptivityMode="SingleColumnWindowLimit" ColumnCount="2" ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="UserName" ColSpan="1"></dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="Email">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="IsLockedOut">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="IsApproved">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Perfil" ColumnSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right" Width="100%" ColumnSpan="2"></dx:EditModeCommandLayoutItem>
            </Items>

            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
            </SettingsAdaptivity>

        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="10%">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="UserId" VisibleIndex="1" Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UserName" Caption="Nombre Usuario" VisibleIndex="2" Width="20%">
                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="3" Width="15%">
                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RoleId" VisibleIndex="4" Visible="False">
            </dx:GridViewDataTextColumn>
             <dx:GridViewDataCheckColumn FieldName="IsLockedOut" Caption="Bloqueado" Width="10%" VisibleIndex="7">
             </dx:GridViewDataCheckColumn>
             <dx:GridViewDataDateColumn FieldName="CreateDate" VisibleIndex="9" Width="15%">
             </dx:GridViewDataDateColumn>
             <dx:GridViewDataDateColumn FieldName="LastLoginDate" VisibleIndex="10" Visible="False">
             </dx:GridViewDataDateColumn>
             <dx:GridViewDataCheckColumn FieldName="IsApproved" Caption="Activo" VisibleIndex="8" Width="10%">
             </dx:GridViewDataCheckColumn>
             <dx:GridViewDataComboBoxColumn Caption="Perfil" FieldName="RoleName" VisibleIndex="5" Width="20%">
                 <PropertiesComboBox TextField="RoleName" ValueField="RoleName" ValueType="System.String" ValidationSettings-RequiredField-IsRequired="true" DataSourceID="SqlDataSource_Roles">
                     <Columns>
                         <dx:ListBoxColumn FieldName="RoleName" Caption="Perfiles" Visible="true"></dx:ListBoxColumn>
                     </Columns>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesComboBox>
             </dx:GridViewDataComboBoxColumn>
          
        </Columns>
        <Styles>
            <Header Wrap="true" ForeColor="#1d3757" HorizontalAlign="Center"></Header>
            

        </Styles>
    </dx:ASPxGridView>
        
                        <asp:SqlDataSource ID="SqlDataSource_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT * FROM [View_Usuarios_Sistema]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource_Roles" runat="server" ConnectionString="<%$ ConnectionStrings:PayLotsConnectionString %>" SelectCommand="SELECT [RoleName] FROM [vw_aspnet_Roles]"></asp:SqlDataSource>
        
        </ContentTemplate></asp:UpdatePanel>
              </div>
        </div>
              
</asp:content>