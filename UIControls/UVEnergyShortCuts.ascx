<%@ Control Language="VB" AutoEventWireup="false" CodeFile="~/UIControls/UVEnergyShortCuts.ascx.vb"
    Inherits="UIControls_UVEnergyShortCuts" %>
<asp:PlaceHolder runat="server" ID="phUsers">
<div class="mnu_wrap">
    <div class="mnu_hd">
        <span class="mhd_tit">UV Energy Shortcuts</span>
    </div>
    <div class="mnu_bd">
        <ul class="mnu_nav">
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">UV Energy Order Form</a></li>
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uehistory.aspx"%>">Order History</a></li>
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uecontactus.aspx"%>">Contact Us</a></li>
            <li><a href='<%=UIHelper.GetBasePath() %>'>UNIonVERSE Home Page</a></li>
        </ul>
    </div>
    <div class="mnu_ft">
    </div>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phUserAdmin">
<div class="mnu_wrap">
    <div class="mnu_hd">
        <span class="mhd_tit">U Matter Shortcuts</span>
    </div>
    <div class="mnu_bd">
        <ul class="mnu_nav">
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">UV Energy Order Form</a></li>
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uehistory.aspx"%>">Order History</a></li>
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uecontactus.aspx"%>">Contact Us</a></li>
            <li><a href='<%=UIHelper.GetBasePath() %>'>UNIonVERSE Home Page</a></li>
        </ul>
    </div>
    <div class="mnu_ft">
    </div>
</div>
</asp:PlaceHolder>