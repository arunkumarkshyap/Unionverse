<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ChatMessages.ascx.vb"
    Inherits="CMSWebParts_Membership_ChatMessages" %>
 <asp:UpdatePanel UpdateMode="Always" runat="server" ID="UpdatePanel1">
                                <ContentTemplate>
<asp:PlaceHolder runat="server" ID="phContents">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Indt2Conn" onclick="javascript:mnuCall(this.id);">
<span runat="server" id="spnMessages"></span>
</a>
    <ul class="mnu_snav" id="sIndt2Conn" style="display: none;">
  
                            <span runat="server" id="spnUsers"></span>
    </ul>
  <span class="dyn_mnu_ft"></span>
</div>
</asp:PlaceHolder>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="UpdatePanel2">
        <ContentTemplate>
            <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="5000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>  