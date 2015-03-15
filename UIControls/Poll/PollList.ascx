<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollList.ascx.vb" Inherits="UIControls_Poll_PollList" %>

<div class="btn_holder">
    <span class="btn_move" style="">
        <asp:LinkButton ID="btnAddNew" runat="server" Text="Add New" EnableViewState="true"></asp:LinkButton></span>
</div>

<asp:Repeater runat="server" ID="rpPolls">
    <HeaderTemplate>
        <table class="CartContentTable" width="100%" cellspacing="0">
            <tr>
                <th style="font-size:14px; text-align:left;">Poll Heading</th>
                <th style="font-size:14px; text-align:left;">Parent Category Name</th>
                <th style="font-size:14px; text-align:left;">Category Name</th>
                <th style="font-size:14px; text-align:left;">Zip Code</th>
                <th></th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("PollQuestion") %></td>
            <td><%#Eval("ParentCategoryName")%></td>
            <td><%#Eval("CategoryName") %></td>
            <td><%#Eval("ZipCode") %></td>
            <td>
                <asp:LinkButton runat="server" ID="lbtEdit" Text="Edit" CommandArgument='<%#Eval("PollID") %>' CommandName="EDIT"></asp:LinkButton>&nbsp;|&nbsp;
                <asp:LinkButton runat="server" ID="lbtDelete" Text="Delete" CommandArgument='<%#Eval("PollID") %>' CommandName="DELETE"></asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
