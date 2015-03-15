<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndividualType2View.ascx.vb"
    Inherits="UIControls_Profile_IndividualType2View" %>
<%@ Register src="SendMessageButton.ascx" tagname="SendMessageButton" tagprefix="uc2" %>   
<div class="prf_wrap">
    <div class="prf_itm">
        UNIonVERSE ID: <span class="prf_itm_val" runat="server" ID="lblUnionverid"></span></div>
    <div class="prf_itm_nb">
        User Name: <span class="prf_itm_val" runat="server" ID="lblUserName"></span></div>
    <div class="prf_itm_nb">
        Full Name: <span class="prf_itm_val" runat="server" ID="lblFullName"></span></div>        
    <div class="prf_itm_nb">
        Religious Sanctuary: <span class="prf_itm_val" runat="server" ID="lblGroupType1"></span></div>          
    <div class="prf_itm_nb">
        Address: <span class="prf_itm_val" runat="server" ID="lblAddress"></span></div>
    <div class="prf_itm_nb">
        City: <span class="prf_itm_val" runat="server" ID="lblCity"></span></div>                
    <div class="prf_itm_nb" runat="server" id="divState">
        State: <span class="prf_itm_val" runat="server" ID="lblState"></span></div>   
    <div class="prf_itm_nb">
        Country: <span class="prf_itm_val" runat="server" ID="lblCountry"></span></div>  
    <div class="prf_itm_nb">
        Zip Code: <span class="prf_itm_val" runat="server" ID="lblZipCode"></span></div>
    <div class="prf_itm_nb">
        Level Of Education: <span class="prf_itm_val" runat="server" ID="lblLevelOfEducation"></span></div>
    <div class="prf_itm_nb">
        College Attended: <span class="prf_itm_val" runat="server" ID="lblCollegeAttended"></span></div>        
    <div class="prf_itm_nb">
        Degree In: <span class="prf_itm_val" runat="server" ID="lblDegreeIn"></span></div>                
    <div class="prf_itm_nb">
        Employer Name: <span class="prf_itm_val" runat="server" ID="lblEmployerName"></span></div>   
    <div class="prf_itm_nb">
        Current Position: <span class="prf_itm_val" runat="server" ID="lblCurrentPosition"></span></div>           
    <div class="prf_itm_nb">
        Type Of Agent: <span class="prf_itm_val" runat="server" ID="lblTypeOfAgent"></span></div> 
    <div class="prf_itm_nb">
        Years of Experience: <span class="prf_itm_val" runat="server" ID="lblYearsOfExperience"></span></div> 
    <div class="prf_itm_nb">
        Business Address: <span class="prf_itm_val" runat="server" ID="lblBusinessAddress"></span></div>        
    <div class="prf_itm_nb">
        City: <span class="prf_itm_val" runat="server" ID="lblBusinessCity"></span></div>  
    <div class="prf_itm_nb" runat="server" id="divBusinessState">
        State: <span class="prf_itm_val" runat="server" ID="lblBusinessState"></span></div>  
    <div class="prf_itm_nb">
        Country: <span class="prf_itm_val" runat="server" ID="lblBusinessCountry"></span></div>  
    <div class="prf_itm_nb">
        Zip Code: <span class="prf_itm_val" runat="server" ID="lblBusinessZipCode"></span></div>          
    <div class="prf_itm_nb">
        Gender: <span class="prf_itm_val" runat="server" ID="lblGender"></span></div>                                                                  
    <div class="prf_itm_nb">
        About: <span class="prf_itm_val" runat="server" ID="lblAbout"></span></div>                                                                  
    <div class="cb">
    </div>
</div>
<div class="btn_holder">
<asp:PlaceHolder runat="server" ID="phButtons">
<span class="btn_yelo"><asp:HyperLink runat="server" ID="hlAddFriend" Text="Link me as an 'Orb'"></asp:HyperLink></span>
<uc2:SendMessageButton ID="SendMessageButton1" runat="server" />
</asp:PlaceHolder>
</div>
