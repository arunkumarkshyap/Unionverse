<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GroupType4View.ascx.vb"
    Inherits="UIControls_Profile_GroupType4View" %>
<%@ Register src="ShowMap.ascx" tagname="ShowMap" tagprefix="uc3" %>
<h1>Group Type 4</h1>
<div style="text-align:right;">
Click <asp:HyperLink runat="server" ID="hlAddFriend" Text="'My WhiteWhole'"></asp:HyperLink> to add as Connection
</div> 
<table cellpadding="2" cellspacing="2">
    <tr>
        <td colspan="2">
            <img runat="server" id="UserImage" />
        </td>
    </tr>
    <tr>
        <td>
            Company Name:
        </td>
        <td>
            <asp:Label runat="server" ID="lblCompanyName" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            UNIonVERSE ID:
        </td>
        <td>
            <asp:Label runat="server" ID="lblUnionverid"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Website Address:
        </td>
        <td>
            <asp:Label runat="server" ID="lblWebsiteAddress"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Description:
        </td>
        <td>
            <asp:Label runat="server" ID="lblDescription"></asp:Label>
        </td>
    </tr>
      <tr>
        <td>
            Telephone Number:
        </td>
        <td>
            <asp:Label runat="server" ID="lblTelephoneNumber"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Address:
        </td>
        <td>
            <asp:Label runat="server" ID="lblAddress"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            City:
        </td>
        <td>
            <asp:Label runat="server" ID="lblCity"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            State:
        </td>
        <td>
            <asp:Label runat="server" ID="lblState"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Country:
        </td>
        <td>
            <asp:Label runat="server" ID="lblCountry"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Zip Code
        </td>
        <td>
            <asp:Label runat="server" ID="lblZipCode"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Type of Group Type 4
        </td>
        <td>
            <asp:Label runat="server" ID="lblTypeOfGroupType4" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Number of Employees
        </td>
        <td>
            <asp:Label runat="server" ID="lblNumerOfEmployees" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            About
        </td>
        <td>
            <asp:Label runat="server" ID="lblAbout"></asp:Label>
        </td>
    </tr>
</table>
<table cellpadding="4" cellspacing="4">
    <tr>
        <td>
            <b>Google Map</b>
        </td>
    </tr>
    <tr>
        <td>
            <uc3:ShowMap ID="ShowMap1" runat="server" />
        </td>
    </tr>
</table>