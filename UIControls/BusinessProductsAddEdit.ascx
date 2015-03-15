<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusinessProductsAddEdit.ascx.vb" Inherits="UIControls_BusinessProductsAddEdit" %>
<table>
    <tr>
        <td>User Name:</td>
        <td>
            <asp:Label runat="server" ID="lblUserName"></asp:Label></td>
    </tr>
    <tr>
        <td>Type:</td>
        <td>
            <asp:DropDownList runat="server" ID="ddProductType">
                <asp:ListItem Text="Product" Value="Product"></asp:ListItem>
                <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Select:</td>
        <td>
            <asp:DropDownList runat="server" ID="ddStoreType">
                <asp:ListItem Text="Geographical" Value="1"></asp:ListItem>
                <asp:ListItem Text="Non-Geographical" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Product Title:</td>
        <td>
            <asp:TextBox runat="server" ID="txtProductTitle"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Orginal Price:</td>
        <td>
            <asp:TextBox runat="server" ID="txtOrginalPrice"></asp:TextBox> UNI
        </td>
    </tr>
    <tr>
        <td>Current Price:</td>
        <td>
            <asp:TextBox runat="server" ID="txtCurrentPrice"></asp:TextBox> UNI
        </td>
    </tr>
    <tr>
        <td>Percentage Savings:</td>
        <td>
            <asp:Label runat="server" ID="lblPercentageSaving"></asp:Label>%
        </td>
    </tr>
    <tr>
        <td>Website URL:</td>
        <td>
            <asp:TextBox runat="server" ID="txtWebsiteURL"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Description:</td>
        <td>
            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Total Number Available:</td>
        <td>
            <asp:TextBox runat="server" ID="txtTotalAvailable"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Product Image:</td>
        <td>
            <asp:FileUpload ID="fuProductImage" runat="server" /><br />
            <img src='' runat="server" id="imgProduct" width="50" height="50" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button runat="server" ID="btnSave" Text="Save" />&nbsp;
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
            <asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>
        </td>
    </tr>
</table>
