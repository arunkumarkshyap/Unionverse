<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollsListByFilters.ascx.vb" Inherits="UIControls_Poll_PollsListByFilters" %>
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
