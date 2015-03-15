<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Geographical.ascx.vb"
    Inherits="CMSModules_Membership_Controls_Geographical" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            Convenience Store/General Store
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb1" GroupName="Grographical" Checked="true" />
        </td>
    </tr>
    <tr>
        <td>
            Newsagent
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb2" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Local Community:
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp;1. Amusement (Entertainment)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb4" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp;2. Venue (Entertainment)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb5" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp;3. Social (Entertainment)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb6" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Supermarket
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb7" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Warehouse Club
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb8" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Restaurant & Eateries:
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp;1. Restaurant
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb10" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp;2. Quick Services:
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;a. Cultural
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb12" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;b. Franchise
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb13" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;c. Health Conscious
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb14" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;d. Take-out (General)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb15" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Spa, Salon, Nails, Barbers
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb16" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Car (Repair or Collision)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb17" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Gas Station
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb18" GroupName="Grographical" />
        </td>
    </tr>
    <tr>
        <td>
            Cable TV, Radio Services (Services)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb19" GroupName="Grographical" />
        </td>
    </tr>
</table>
<asp:Button runat="server" id="btnGeographical" Text="Select" />