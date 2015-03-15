<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SearchPollResultsByFilter.ascx.vb" Inherits="UIControls_Poll_SearchPollResultsByFilter" %>
<%@ Register Src="~/UIControls/Poll/PollViewOnly.ascx" TagPrefix="uc1" TagName="PollView" %>
<asp:Repeater runat="server" ID="rpPolls">
    <HeaderTemplate>
        <table width="100%">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <uc1:PollView runat="server" ID="PollView" PollID='<%#Eval("PollID") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
