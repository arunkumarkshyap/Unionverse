<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AddEditAlbum.ascx.vb"
    Inherits="UIControls_Album_AddEditAlbum" %>
<%@ Register Src="~/UIControls/Album/AddPhotos.ascx" TagName="AddPhotos" TagPrefix="uc1" %>
<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" ForeColor="Green"
        Font-Bold="true" />
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" ForeColor="Red" />
</div>
<fieldset>
    <legend><b>Album information</b></legend>
    <table>
        <tr>
            <td class="FieldLabel">
                <b>Title:</b><br />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTitle" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Description:</b><br />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription" CssClass="TextBoxField" TextMode="MultiLine"
                    Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Access:</b><br />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlAcess">
                    <asp:ListItem Value="1">Public</asp:ListItem>
                    <asp:ListItem Value="2">Friends</asp:ListItem>
                    <asp:ListItem Value="3">Private</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</fieldset>
<br />
<fieldset>
    <legend><b>Add Photos</b></legend>
    <table>
        <tr>
            <td colspan="2">
                <uc1:AddPhotos runat="server" ID="AddPhotos" />
            </td>
        </tr>
    </table>
</fieldset>
<div class="btn_holder">
    <span class="btn_move">
        <asp:LinkButton runat="server" ID="lbtSav1" Text="Save"></asp:LinkButton></span>
</div>
