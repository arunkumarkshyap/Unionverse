<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelectCharity.ascx.vb"
    Inherits="CMSModules_Membership_Controls_SelectCharity" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            Advocacy Groups for Human Rights and Civil Liberties
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb1" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Animal Rights
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb2" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Children and Youth
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb3" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Education, Research and Cultural Preservation Groups
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb4" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Feeding the Hungry
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb5" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             General Emergency Relief
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb6" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Health: Cancer Support and Research
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb7" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Health: Support for Chronic Illnesses and Diseases
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb8" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Health: Support for Physical and Cognitive Disabilities
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb9" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Impoverished Children
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb10" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Land Conservation and the Environment
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb11" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Medical Assistance
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb12" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Other (Non-Profit)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb13" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Poverty
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb14" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Promoting Self-Sufficiency
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb15" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Refugees
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb16" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Sanctity of Life
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb17" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Senior Citizens
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb18" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Supporting Fire Fighters and Police
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb19" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Supporting Military and Veterans
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb20" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Watchdog Groups
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb21" GroupName="Charity" />
        </td>
    </tr>
    <tr>
        <td>
             Women
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb22" GroupName="Charity" />
        </td>
    </tr>
</table>
<asp:Button runat="server" ID="btnCharitySelected" Text="Select" />