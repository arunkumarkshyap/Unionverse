<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelectNonProfit.ascx.vb"
    Inherits="CMSModules_Membership_Controls_SelectNonProfit" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            Aid to Families with Dependent Children
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb1" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Alcohol, Drug Abuse, and Mental Health
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb2" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Child and Adult Care Food Program
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb3" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Community Development 
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb4" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Conservation Reserve Program
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb5" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Crime Prevention and Local Law Enforcement Efforts
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb6" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Education
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb7" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Health and Nutrition
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb8" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Home and Shelter
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb9" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Other (Non-Specific)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb10" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Parent Involvement
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb11" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Unemployment Aid
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb12" GroupName="Charity" />
        </td>
    </tr>
</table>
<asp:Button runat="server" ID="btnCharitySelected" Text="Select" />