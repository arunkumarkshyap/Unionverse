<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BOrderShipping.ascx.vb" Inherits="UIControls_BOrderShipping" %>
<table>
    <tr>
        <td>(Name):</td>
        <td>
            <asp:TextBox runat="server" ID="txtShipName"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Email:</td>
        <td>
            <asp:TextBox runat="server" ID="txtShipEmail"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Phone:</td>
        <td>
            <asp:TextBox runat="server" ID="txtShipPhone"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Company</td>
        <td>
            <asp:TextBox runat="server" ID="txtShipCompany"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Address:</td>
        <td>
            <asp:TextBox runat="server" ID="txtShipAddress"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Country/State:</td>
        <td>
            <asp:DropDownList runat="server" ID="ddCountry" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddState">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>City:</td>
        <td>
            <asp:TextBox runat="server" ID="txtShipCity"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Zip Code:</td>
        <td>
            <asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button runat="server" ID="btnBack" Text="Back" />
            <asp:Button runat="server" ID="btnContinue" Text="Save & Continue" />
            <asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>
        </td>
    </tr>
</table>
