<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UserMessages.ascx.vb" Inherits="UIControls_UserMessages" %>
<style type="text/css">
    .TabControlTable {
        height: 25px;
        padding: 0;
        margin: 0;
        border-collapse: collapse;
        background: none;
        border: solid 1px #906de1;
        margin: 0 0 0px 0;
    }

    .TabControlLeft, .TabControlSelectedLeft {
        display: none;
    }

    .TabControl {
        background: none;
        padding: 5px 15px 5px 15px;
        border: solid 1px #906de1;
    }

    .TabsHeader, .TabsWhite {
        width: 627px;
        border-bottom: solid 0px #906de1;
    }

    .IE6 .TabsHeader, .IE6 .TabsWhite {
        height: 25px;
    }

    a.TabControlLink {
        color: #8d0288;
    }

    .TabControlLinkSelected {
        color: #fff;
    }

    .TabControlSelected {
        background-color: #906de1;
        padding: 0px 10px 0px 10px;
        color: #fff;
    }

        .TabControlSelected a {
            color: #fff;
        }

        .TabControlSelected .TabControlLinkSelected {
            color: #fff;
        }

    .TabControlRight, .TabControlSelectedRight {
        width: 0px;
        padding: 0px;
        font-size: 0px;
        display: none;
    }

    .TabControlTable a {
        text-decoration: none;
        font-size: 12px;
    }

    .SubscriptionsGroup {
        padding: 8px;
    }

    .SubscriptionsPanel {
        padding-top: 22px;
    }

    .TabsContent {
        border: 1px solid #906de1;
        padding: 15px;
        width: 585px;
    }

    .IE6 .TabsContent {
        background: white;
    }

    .TabsContent .Error {
        color: Red;
    }

    .TabsContent .Grid {
        width: 100%;
        border: 1px solid #906de1;
    }

    .TabsContent .OddRow {
        background-color: #eee;
    }

    .TabsRight, .TabsLeft {
        display: none;
    }

    .myAccMenu .ForumDiscussionButtons, .MessagingBox .ForumDiscussionButtons {
        padding-left: 10px;
    }

    .myAccMenu {
        width: 585px;
    }

    .TabsContent input[type=text], .TabsContent input[type=password], .TabsContent input[type=file], .TabsContent textarea, .MyProfileFileUpload {
        width: 300px;
    }
</style>
<div class="TabsHeader">
    <div class="TabsLeft">
    </div>
    <div class="TabsTabs">

        <div class="TabsWhite">

            <table cellspacing="0" class="TabControlTable">
                <tr>
                    <td class="TabControlSelectedLeft">&nbsp;</td>
                    <td class="TabControlSelected" runat="server" id="trInbox">
                        <asp:LinkButton runat="server" ID="lbtInbox" Text="Inbox"></asp:LinkButton>
                    </td>
                    <td class="TabControlSelectedRight">&nbsp;</td>
                    <td class="TabControl" runat="server" id="trOutbox">
                        <asp:LinkButton runat="server" ID="lbtOutbox" Text="Outbox"></asp:LinkButton>
                    </td>
                    <td class="TabControlRight">&nbsp;</td>
                </tr>
            </table>

        </div>

    </div>
    <div class="TabsRight">
    </div>
</div>

<div class="TabsContent">
    <asp:Repeater runat="server" ID="rpMessages">
        <HeaderTemplate>
            <table width="100%" class="CartContentTable" >
                <tr>
                    <th>Action</th>
                    <th align="left">From</th>
                    <th align="left">Subject</th>
                    <th align="left">Date</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a Visible="<%#IsVisible() %>"  runat="server" ID="lbtReply" Text="Reply" href='<%#UIHelper.GetBasePath() & "/MessageSend.aspx?mid=" & Eval("MessageID") & "&suid=" & Eval("SenderUserID") %>' >Reply</a>
                    <asp:LinkButton runat="server" ID="lbtDelete" Text="Delete" CommandName="DELETE" CommandArgument='<%#EVal("MessageID") %>'></asp:LinkButton>
                </td>
                <td><%#Eval("SenderNickName") %></td>
                <td><a href='<%# UIHelper.GetBasePath() & "/Message.aspx?mid=" & Eval("MessageID") %>'><%#Eval("Subject")%></a></td>
                <td><%#Eval("DateSent") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>


