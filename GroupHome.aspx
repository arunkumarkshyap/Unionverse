<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupHome.aspx.vb" Inherits="GroupHome"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="UIControls/Registration/UserType1Regis.ascx" TagName="UserType1Regis"
    TagPrefix="uc1" %>
<%--<%@ Register src="UIControls/Registration/PlanetsPendingApproval.ascx" tagname="PlanetsPendingApproval" tagprefix="uc2" %>--%>
<%@ Register src="UIControls/Registration/UserType1Planets.ascx" tagname="UserType1Planets" tagprefix="uc3" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cpGroupType1" runat="server">
    <h1 runat="server" id="hGroupName">
    </h1>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>
                UNIonVERSE ID:
            </td>
            <td>
                <asp:Label runat="server" ID="lblUnionVerseUserID" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Individual User Type 1 Registration:
            </td>
            <td>
                <asp:HyperLink runat="server" ID="hlIndividualregistration"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                Individual User Type 2 Registration:
            </td>
            <td>
                <asp:HyperLink runat="server" ID="hlIndividualregistration2"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2">
               <%-- <uc2:PlanetsPendingApproval ID="PlanetsPendingApproval1" runat="server" />--%>
                <uc3:UserType1Planets ID="UserType1Planets1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
