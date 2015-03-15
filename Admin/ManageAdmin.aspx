<%@ Page Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="ManageAdmin.aspx.vb" Inherits="Admin_ManageAdmin" title="Untitled Page" %>

<%@ Register Src="~/Admin/AdminControls/AdministratorsList.ascx" TagName="AdministratorsList" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/AdminControls/AdministratorsAddEdit.ascx" TagName="AdministratorsAddEdit" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<uc1:AdministratorsList id="AdministratorsList" runat="server" />
<uc2:AdministratorsAddEdit id="AdministratorsAddEdit" runat="server"/>
    
</asp:Content>

