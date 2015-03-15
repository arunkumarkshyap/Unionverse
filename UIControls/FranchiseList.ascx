<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FranchiseList.ascx.vb" Inherits="UIControls_FranchiseList" %>
<asp:Repeater runat="server" ID="rpFranchise">
    <ItemTemplate>
        <li><a href='<%#UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUserName(CInt(Eval("UserID"))) & ".aspx"%>'><%#Eval("CompanyName") %></a><li>
    </ItemTemplate>
</asp:Repeater>
