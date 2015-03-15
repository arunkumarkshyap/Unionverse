<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MessageView.ascx.vb" Inherits="UIControls_MessageView" %>
<table cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td width="70px"><b>From:</b></td>
        <td runat="server" id="tFrom"></td>
    </tr>
    <tr>
        <td><b>Date:</b></td>
        <td runat="server" id="tDate"></td>
    </tr>
    <tr>
        <td><b>Subject:</b></td>
        <td runat="server" id="tSubject"></td>
    </tr>
    <tr>
        <td runat="server" id="tBody" colspan="2" style="border: solid 5px #eaeaea; padding:10px;"></td>
    </tr>
</table>
<br clear="all" />
<div class="btn_holder">
    <span class="btn_move">
        <asp:LinkButton runat="server" ID="lbtReply" Text="Reply"></asp:LinkButton></span>&nbsp; 
            <span class="btn_move">
                <asp:LinkButton runat="server" ID="lbtForward" Text="Forward"></asp:LinkButton></span>
</div>
