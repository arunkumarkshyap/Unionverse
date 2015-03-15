<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollsSearch.ascx.vb" Inherits="UIControls_Poll_PollsSearch" %>
<table cellpadding="2" cellspacing="2">
    <tr>
        <td>Poll</td>
        <td>
            <asp:TextBox runat="server" ID="txtPollQuestion"></asp:TextBox>
        </td>
        <td>
            <asp:Button runat="server" ID="btnSearch" Text="Search" />
        </td>
    </tr>
</table>
<asp:Repeater runat="server" ID="rpPolls">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <a href='<%#UIhelper.GetBasePath() & "/Electrons/Electron.aspx?PollID=" & Eval("PollID")%>'><%#Eval("PollQuestion") %></a>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
