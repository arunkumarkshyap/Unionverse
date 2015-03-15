<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UserType1Planets.ascx.vb"
    Inherits="CMSModules_Membership_Controls_UserType1Planets" %>
<asp:Repeater runat="server" ID="rpPlanets">
    <ItemTemplate>
        <div class="pbox_itm">
            <div class="pbox_itm_cnt">
                <%#GetUserHTML(Eval("FriendID"))%>              
            </div>
            <div class="pbox_itm_ft">
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:Label runat="server" ID="lblNoRecord" Text="No registered/approved planet"></asp:Label>
<div class="cb">
</div>
