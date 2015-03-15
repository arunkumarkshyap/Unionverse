<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FranchiseAddEdit.ascx.vb"
    Inherits="UIControls_Registration_FranchiseAddEdit" %>
<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" />
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" ForeColor="Red" />
    <table runat="server" id="tblForm">
        <tr>
            <td class="FieldLabel">
                Franchise Address Line 1:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress1" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Franchise Address 2:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress2" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                State:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtState" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Zip Code:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtZipCode" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Telephone Number:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Email Address:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Number of Employees:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNumberOfEmployees" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Website Address:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtWebsiteAddress" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button runat="server" ID="btnOk" Text="Save" CssClass="ContentButton" />
            </td>
        </tr>
    </table>
</div>
