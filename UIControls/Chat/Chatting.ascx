<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Chatting.ascx.vb" Inherits="UIControls_Chat_Chatting" %>
<style type="text/css">
    .frame { font: 12px arial; width: 550px; height: 270px; border: none; overflow: auto; padding: 10px; background-color: White; }
    .msgsent { width: 500px; border: solid 1px #EEEEEE; float: left; background-color: #F8F8F8; margin: 1px; padding:3px; }
    .msgrec { width: 500px; border: solid 1px #EEEEEE; float: right; background-color: #EAEAFF; margin: 1px; padding:3px; }
</style>


<table cellpadding="4" cellspacing="0">
    <tr>
        <td>
            <table>
                <tr>
                    <td valign="top">
                        <img src="" alt="" width="70" height="70" runat="server" id="imgProfile" />
                    </td>
                    <td valign="top" style="padding-top: 2px;">
                        <span runat="server" id="spnUserName" style="font-size:16px;"></span>
                        <br />
                        <span runat="server" id="pAdmin"><small>*Planets(Individuals) please contact your Solar System (Religious Sanctuary) Moderator before contacting the UNIonVERSE Site Administrator.</small><br /></span>
                        <asp:UpdatePanel UpdateMode="Always" runat="server" ID="UpdatePanel3">
                            <ContentTemplate>
                                <span runat="server" id="pOnline"></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <div id="news" class="frame">
             <asp:UpdatePanel UpdateMode="Always" runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <div runat="server" id="divChat"></div>
<asp:Panel ID="iii" runat="server">
<script language="javascript" type="text/javascript">
function scroll() 
{
  var div = document.getElementById("news");
  var h=div.scrollHeight - 160;
  div.scrollTop = h;
 // t1=setTimeout("scroll()",4000);

}
scroll();
</script>

</asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="up1">
                <ContentTemplate>
                <asp:Panel runat="server" ID="pnlChat" DefaultButton="btn_Send">
                    <div style="width:550px; display:block; margin-left:10px;">
                        <div style="width:495px; float:left;"><asp:TextBox runat="server" TextMode="MultiLine" Height="40" ID="txtMessage" Text="" Width="490"></asp:TextBox></div>
                        <div style="width:50px; float:right;"><span class="btn_gren">
                                    <asp:LinkButton runat="server" ID="btn_Send" Text="Send"></asp:LinkButton></span></div>
                    </div>
                </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="UpdatePanel2">
    <ContentTemplate>
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="5000">
        </asp:Timer>
    </ContentTemplate>
</asp:UpdatePanel>

