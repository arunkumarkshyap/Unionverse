<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Unionversal.ascx.vb"
    Inherits="UIControls_Registration_Unionverse" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
           Consultants
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb1" GroupName="Unionversal" Checked="true" />
        </td>
    </tr>
    <tr>
        <td>
            Credit-Loans-Collections
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb2" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
            IT (Web) Services
        </td>
        <td>
             <asp:RadioButton runat="server" ID="rb3" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
           Employee Incentives
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb4" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
            Energy-Utilities
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb5" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
           Office Electronics (Computers, Phones, Etc)
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb6" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
            Office Supplies
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb7" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
            OfficeWare
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb8" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
            Marketing & Advertising
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb9" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
           Telecommunication Installation
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb10" GroupName="Unionversal" />
        </td>
    </tr>
    <tr>
        <td>
           Travel, Hotel, and Transportation
        </td>
        <td>
            <asp:RadioButton runat="server" ID="rb11" GroupName="Unionversal" />
        </td>
    </tr>
   </table>
<asp:Button runat="server" id="btnUnionversal" Text="Select" />