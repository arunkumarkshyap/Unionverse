<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ErrMsg.ascx.vb" Inherits="ErrMsg" %>
<div class="msg">
    <div class="tit" runat="server" id="divtit">
        <asp:Label runat="server" ID="lblhead"></asp:Label>
    </div>
    <p runat="server" id="pErr">
        <asp:Label ID="lblError" CssClass="Error" runat="server" Text=""></asp:Label></p>
</div>
