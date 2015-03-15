<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollUserAdd.ascx.vb" Inherits="UIControls_PollUserAdd" %>
<h1 runat="server" id="hPollQuestion"></h1>
<asp:RadioButtonList runat="server" ID="rblQuestion">

</asp:RadioButtonList>
<asp:Button runat="server" ID="btnSave" Text="Submit" />
<asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>