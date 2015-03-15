<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndustrySpecific.ascx.vb"
    Inherits="UIControls_Registration_IndustrySpecific" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            Consultants
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb1" GroupName="IndSpecific" Checked="true" />
        </td>
    </tr>
    <tr>
        <td>
            Distributors
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb2" GroupName="IndSpecific" />
        </td>
    </tr>
    <tr>
        <td>
            Invention Development (R & D)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb3" GroupName="IndSpecific" />
        </td>
    </tr>
    <tr>
        <td>
            Machinery & Equipment
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb4" GroupName="IndSpecific" />
        </td>
    </tr>
    <tr>
        <td>
            Marketing & Advertising
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb5" GroupName="IndSpecific" />
        </td>
    </tr>
    <tr>
        <td>
            Raw Materials
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb6" GroupName="IndSpecific" />
        </td>
    </tr>
    <tr>
        <td>
            Processed Materials
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb7" GroupName="IndSpecific" />
        </td>
    </tr>
    <tr>
        <td>
            Product Development (Post R & D)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb8" GroupName="IndSpecific" />
        </td>
    </tr>
</table>
<asp:Button runat="server" ID="btnGeographical" Text="Select" />