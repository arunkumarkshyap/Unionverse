<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupType4.aspx.vb" Inherits="GroupType4"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="UIControls/Registration/GroupType4Regis.ascx" TagName="GroupType4Regis"
    TagPrefix="uc2" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cpGroupType1" runat="server">
    <h1>
        Group Type 4</h1>
    <uc2:GroupType4Regis ID="GroupType4Regis1" runat="server" />
</asp:Content>
