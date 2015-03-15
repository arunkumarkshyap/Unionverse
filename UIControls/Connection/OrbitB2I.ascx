<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OrbitB2I.ascx.vb"
    Inherits="UIControls_OrbitB2I" %>
<div class="pbox_wrap">
    <asp:Repeater runat="server" ID="rpPlanets">
        <ItemTemplate>
            <div class="pbox_itm">
                <div class="pbox_itm_cnt">
                    <%#GetUserHTML(CInt(Eval("FriendRequestedUserID")), CInt(Eval("FriendUserID")))%>
                </div>
                <div class="pbox_itm_ft">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Label runat="server" ID="lblNoRecord" Text="No Connection"></asp:Label>
    <div class="cb">
    </div>
</div>
