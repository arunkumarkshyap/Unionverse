<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LogonMiniForm.ascx.vb" Inherits="UIControls_LogonMiniForm" %>

<div class="logn_cnt">
    <span>
        <asp:TextBox ID="UserName" runat="server" CssClass="LogonField" EnableViewState="false" />
    </span>
    <span class="spn2">
        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="LogonField"
            EnableViewState="false" />
    </span>
    <div>
        <span class="logn_ctrl"><a href="<%=UIHelper.GetUnionVerseBasePathURL() + "/forget-password.aspx" %>">Forgot Password</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lbtLogon" runat="server" Text="Login&amp;nbsp;&amp;#187;" EnableViewState="true"></asp:LinkButton>
        </span>
        <asp:ImageButton ID="btnImageLogon" runat="server" Visible="false" EnableViewState="true" />
    </div>
</div>
<asp:Label ID="lblError" CssClass="err_box" runat="server" EnableViewState="true" Visible="false" />
