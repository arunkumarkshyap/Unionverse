<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollView.ascx.vb" Inherits="UIControls_PollView" %>
<style>
    .ct_rating { background-color: #d0d0d0; width: 500px; height: 15px; margin: 0px; padding: 0px; float: left; margin-bottom:10px;}
    .rating { background-color: #040962; width: 250px; height: 15px; margin: 0px; padding: 0px; }
    .Poll_Heading {font-size:16px; font-weight:bold;}
</style>
<div style="margin-bottom:5px; padding:10px; padding-top:2px; background-color:#f8f8f8; border:solid 1px #EFEFEF;">
<a href="<%=UIHelper.GetBasePath() & "/Electrons/Electron.aspx?PollID=" & PollID.ToString %>"><h1 runat="server" id="hPollQuestion" class="Poll_Heading"></h1></a>
<div style="padding-left:20px;">
<asp:Repeater runat="server" ID="rpQuestion">
    <HeaderTemplate>
        <table cellspacing="0" cellpadding="0" border="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td colspan="2">
                <%#Eval("OptionText") %>
            </td>
        </tr>
        <tr>
            <td>
                <div class="ct_rating">
                    <div class="rating" style='width:<%#GetWidth(Eval("TotalResponse"), Eval("TotalPollResponse"))%>'></div>
                </div>
            </td>
            <td valign="top">&nbsp;<%#GetPerecentage(CDbl(Eval("TotalResponse")),CDbl(Eval("TotalPollResponse")))%></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</div>
</div>