<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusinessUsersView.ascx.vb"
    Inherits="UIControls_Profile_BusinessUsersView" %>
<%@ Register src="StarShipVouagerButton.ascx" tagname="StarShipVouagerButton" tagprefix="uc1" %>
<%@ Register src="SendMessageButton.ascx" tagname="SendMessageButton" tagprefix="uc2" %>
<%@ Register src="ChatButton.ascx" tagname="ChatButton" tagprefix="uc1" %>
<div class="prf_wrap">
    <div class="prf_itm">
        UNIonVERSE ID: <span class="prf_itm_val" runat="server" ID="lblUnionverid"></span></div>
    <div class="prf_itm_nb">
        Full Name: <span class="prf_itm_val" runat="server" ID="lblUserName"></span></div>
    <div class="prf_itm_nb">
        Company Name: <span class="prf_itm_val" runat="server" ID="lblCompanyName"></span></div>
    <div class="prf_itm_nb">
        Website Address: <span class="prf_itm_val" runat="server" ID="lblWebsiteAddress"></span></div>
    <div class="prf_itm_nb">
        Business Address: <span class="prf_itm_val" runat="server" ID="lblBusinessAddress"></span></div>
    <div class="prf_itm_nb">
        City: <span class="prf_itm_val" runat="server" ID="lblCity"></span></div>
    <div class="prf_itm_nb" runat="server" id="divState">
        State: <span class="prf_itm_val" runat="server" ID="lblState"></span></div>
    <div class="prf_itm_nb" runat="server" id="div1">
        Country: <span class="prf_itm_val" runat="server" ID="lblCountry"></span></div>
    <div class="prf_itm_nb" runat="server" id="div2">
        Zip Code: <span class="prf_itm_val" runat="server" ID="lblZipCode"></span></div>        
    <div class="prf_itm_nb" runat="server" id="div3">
        Industry: <span class="prf_itm_val" runat="server" ID="lblIndustry"></span></div>                            
    <div class="prf_itm_nb" runat="server" id="div6">
        Type of Company: <span class="prf_itm_val" runat="server" ID="lblCompanyType"></span></div> 
    <div class="prf_itm_nb" runat="server" id="div7">
        Store Type: <span class="prf_itm_val" runat="server" ID="lblStoreType"></span></div> 

    <div class="prf_itm_nb" runat="server" id="div4">
        About: <span class="prf_itm_val" runat="server" ID="lblAbout"></span></div> 
    
   <%-- <asp:PlaceHolder runat="server" ID="phFranshiseLink">
    <div class="prf_itm_nb" runat="server" id="div5">
        Franchise Registraion Link: <span class="prf_itm_val" runat="server" ID="spnFranchiseLinik"></span></div> </asp:PlaceHolder>
--%>
    <div class="cb">
    </div>
</div>
<div class="btn_holder">
    <uc1:ChatButton ID="ChatButton1" runat="server" />
    <asp:PlaceHolder runat="server" ID="phButtons">
    <uc1:StarShipVouagerButton ID="StarShipVouagerButton1" runat="server" />
    <uc2:SendMessageButton ID="SendMessageButton1" runat="server" />
    </asp:PlaceHolder>
</div>

