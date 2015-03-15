<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ChatButton.ascx.vb"
    Inherits="UIControls_Chat_ChatButton" %>
<asp:PlaceHolder runat="server" ID="phSendFeedBack">
<script type="text/javascript" language="javascript">
function gravity()
{
    location.href='<%=GetChatURL()%>';
    //window.open('<%=GetChatURL()%>','','height=350,width=300');
}
</script>
<span class="btn_movl"><a href="javascript:gravity();">Chat</a></span>
</asp:PlaceHolder>
