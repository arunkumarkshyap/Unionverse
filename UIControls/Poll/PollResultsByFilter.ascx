<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollResultsByFilter.ascx.vb" Inherits="UIControls_Poll_PollResultsByFilter" %>
<%@ Register Src="~/UIControls/Poll/PollView.ascx" TagPrefix="uc1" TagName="PollView" %>
<div class="btn_holder" runat="server" id="divAddNewPoll">
    <span class="btn_move" style="">
        <asp:LinkButton ID="btnAddNew" runat="server" Text="Add New" EnableViewState="true"></asp:LinkButton></span>
</div>
<asp:Repeater runat="server" ID="rpPolls">
    <HeaderTemplate>
        <table width="100%">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>

            <td>
                <uc1:PollView runat="server" ID="PollView" PollID='<%#Eval("PollID") %>' />
            </td>
          <%--  <td runat="server" id="tdPoll" valign="top" width="100px" visible='<%#ISEditAble(Eval("ByUserID")) %>'>
                <div style="padding-top: 10px;">
                    <asp:LinkButton runat="server" ID="lbtEdit" Text="Edit" CommandArgument='<%#Eval("PollID") %>' CommandName="EDIT"></asp:LinkButton>&nbsp;|&nbsp;
                <asp:LinkButton runat="server" ID="lbtDelete" Text="Delete" CommandArgument='<%#Eval("PollID") %>' CommandName="DELETE"></asp:LinkButton>
                </div>
            </td>--%>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
