<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GravitationalPlanetsII.ascx.vb"
    Inherits="CMSModules_Membership_Controls_GravitationalPlanetsII" %>
<asp:Repeater runat="server" ID="rpGravirational">
    <ItemTemplate>
        <div class="pbox_itm">
            <div class="pbox_itm_cnt">
            <span class='pbox_itm_img'><a href='<%# UIHelper.GetBasePath() & "/Members/" & Eval("FriendUserName") & ".aspx" %>'><img src='<%#GetUserImage(CInt(Eval("FriendAvatarID")))%>' /></a></span>
            <span class='pbox_inf'><a href='<%# UIHelper.GetBasePath() & "/Members/" & Eval("FriendUserName") & ".aspx" %>'><%#Eval("FriendUserName")%></a></span>
            </div>
            <div class="pbox_itm_ft">
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="cb">
</div>
