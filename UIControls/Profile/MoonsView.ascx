<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MoonsView.ascx.vb" Inherits="UIControls_Profile_MoonsView" %>
<%@ Register Src="SendMessageButton.ascx" TagName="SendMessageButton" TagPrefix="uc2" %>
<div class="prf_wrap">
    <div class="prf_itm">
        UNIonVERSE ID: <span class="prf_itm_val" runat="server" id="lblUnionverid"></span>
    </div>
    <div class="prf_itm_nb">
        User Name: <span class="prf_itm_val" runat="server" id="lblUserName"></span>
    </div>
    <div class="prf_itm_nb">
        <span runat="server" id="spnSchoolLabel"></span><span class="prf_itm_val" runat="server" id="lblSchoolName"></span>
    </div>
    <div class="prf_itm_nb">
        Type: <span class="prf_itm_val" runat="server" id="spType"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="phSubType">
        <span runat="server" id="spnSubType"></span> <span class="prf_itm_val" runat="server" id="lblSubType"></span>
    </div>
    <div class="prf_itm_nb">
        Industry: <span class="prf_itm_val" runat="server" id="lblIndustry"></span>
    </div>
    <div class="prf_itm_nb">
        Website Address: <span class="prf_itm_val" runat="server" id="lblWebsiteAddress"></span>
    </div>
    <div class="prf_itm_nb">
        Telephone Number: <span class="prf_itm_val" runat="server" id="lblTelephoneNumber"></span>
    </div>
    <div class="prf_itm_nb">
        Address: <span class="prf_itm_val" runat="server" id="lblAddress"></span>
    </div>
    <div class="prf_itm_nb">
        City: <span class="prf_itm_val" runat="server" id="lblCity"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="divState">
        State: <span class="prf_itm_val" runat="server" id="lblState"></span>
    </div>
    <div class="prf_itm_nb">
        Country: <span class="prf_itm_val" runat="server" id="lblCountry"></span>
    </div>
    <div class="prf_itm_nb">
        Zip Code: <span class="prf_itm_val" runat="server" id="lblZipCode"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="tr1AlternateAddress">
        Alternate Address: <span class="prf_itm_val" runat="server" id="lblAlternateAddress"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="tr1AlternateState">
        Alternate State: <span class="prf_itm_val" runat="server" id="lblAlternateState"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="tr1AlternateZipCode">
        Alternate Zip Code: <span class="prf_itm_val" runat="server" id="lblAlternateZipCode"></span>
    </div>
    <div class="prf_itm_nb">
        Hours of Operation: <span class="prf_itm_val" runat="server" id="lblHoursOfOperation"></span>
    </div>
    <div class="prf_itm_nb">
        Status: <span class="prf_itm_val" runat="server" id="lblStatus"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="trGovernmentLevel">
        Government (Level): <span class="prf_itm_val" runat="server" id="lblGovenmentLevel"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="trMediaType">
        Media Type: <span class="prf_itm_val" runat="server" id="lblMediaType"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="Div2">
        About: <span class="prf_itm_val" runat="server" id="lblAbout"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="Div1">
        Description: <span class="prf_itm_val" runat="server" id="lblDescription"></span>
    </div>
    <div class="cb"></div>
</div>
<div class="btn_holder">
    <asp:PlaceHolder runat="server" ID="phButtons">
        <span class="btn_yelo">
            <asp:HyperLink runat="server" ID="hlAddFriend" Text="Add me as a 'Moon'"></asp:HyperLink></span>
        <uc2:SendMessageButton ID="SendMessageButton1" runat="server" />
    </asp:PlaceHolder>
</div>
