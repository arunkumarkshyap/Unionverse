<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GroupType1View.ascx.vb"
    Inherits="UIControls_Profile_GroupType1View" %>
<%@ Register Src="StarShipVouagerButton.ascx" TagName="StarShipVouagerButton" TagPrefix="uc1" %>
<%@ Register Src="SendMessageButton.ascx" TagName="SendMessageButton" TagPrefix="uc2" %>
<%@ Register Src="ChatButton.ascx" TagName="ChatButton" TagPrefix="uc1" %>
<%@ Register Src="UserSendMessageButton.ascx" TagName="UserSendMessageButton" TagPrefix="uc2" %>
<div class="prf_wrap">
    <div class="prf_itm">
        UNIonVERSE ID: <span class="prf_itm_val" runat="server" id="lblUnionverid"></span>
    </div>
    <div class="prf_itm_nb">
        User Name: <span class="prf_itm_val" runat="server" id="lblUserName"></span>
    </div>
    <div class="prf_itm_nb">
        Religious Sanctuary Leader (Star of Solar System): <span class="prf_itm_val" runat="server"
            id="lblGroupType1Leader"></span>
    </div>
    <div class="prf_itm_nb">
        Galaxy: <span class="prf_itm_val" runat="server" id="lblGalaxy"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="divFaith" visible="false">
        Faith: <span class="prf_itm_val" runat="server" id="lblFaith"></span>
    </div>
    <div class="prf_itm_nb">
        Sub-Denomination: <span class="prf_itm_val" runat="server" id="lblSub"></span>
    </div>
    <div class="prf_itm_nb">
        Website Address: <span class="prf_itm_val" runat="server" id="lblWebsiteAddress">
        </span>
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
    <div class="prf_itm_nb" runat="server" id="div1">
        Country: <span class="prf_itm_val" runat="server" id="lblCountry"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="div2">
        Zip Code: <span class="prf_itm_val" runat="server" id="lblZipCode"></span>
    </div>
    <div class="prf_itm_nb" runat="server" id="div3">
        Telephone Number: <span class="prf_itm_val" runat="server" id="lblTelephoneNumber">
        </span>
    </div>
    <div class="prf_itm_nb" runat="server" id="div4">
        Individual Users Registration Link: <span class="prf_itm_val" runat="server" id="lblURL">
        </span>
    </div>
    <div class="prf_itm_nb" runat="server" id="div5">
        About: <span class="prf_itm_val" runat="server" id="lblAbout"></span>
    </div>
    <div class="cb">
    </div>
</div>
<div class="btn_holder">
    <uc2:UserSendMessageButton ID="UserSendMessageButton1" runat="server" />
    <uc1:ChatButton ID="ChatButton1" runat="server" />
    <asp:PlaceHolder runat="server" ID="phButtons"><span class="btn_yelo" runat="server"
        id="spnAddConnection">
        <asp:HyperLink runat="server" ID="hlAddFriend"></asp:HyperLink></span> <span class="btn_gren">
            <a href="#" id="aSendUNI" runat="server">Send UNI</a></span> </asp:PlaceHolder>
    <uc1:StarShipVouagerButton ID="StarShipVouagerButton1" runat="server" />
    <uc2:SendMessageButton ID="SendMessageButton1" runat="server" />
</div>
