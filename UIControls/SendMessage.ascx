<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SendMessage.ascx.vb" Inherits="UIControls_SendMessage" %>
<table cellpading="4" cellspacing="4">
    <tr>
        <td>
            <b>From:</b>
        </td>
        <td>
            <asp:Label runat="server" ID="lblFromUserName" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td><b>To:</b></td>
        <td>
            <asp:TextBox runat="server" ID="txtToUser"  Text=""></asp:TextBox>
            <asp:Button runat="server" ID="btnUsers" Text="Select" Visible="false" />
        </td>
    </tr>
    <tr>
        <td>
            <b>Subject</b>
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtSubject" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <b>Body</b>
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtBody" TextMode="MultiLine" Width="550px" Height="200px"></asp:TextBox>
        </td>
    </tr>
</table>
<asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>
<div class="btn_holder">
    <span class="btn_move">
        <asp:Button runat="server" ID="btnSend" Text="Send" />
    </span>
</div>
