<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GravityPlanetsII.ascx.vb"
    Inherits="CMSWebParts_Membership_GravityPlanetsII" %>
<%@ Register Src="GravityPlanetsByType.ascx" TagName="GravityPlanetsByType" TagPrefix="uc2" %>
<asp:Repeater runat="server" ID="rpAgentType">
    <ItemTemplate>
        <uc2:GravityPlanetsByType ID="GravityPlanetsByType1" runat="server" UserID='<%#GetUser().UserID%>'
            Attorney='<%#EVal("Attorney") %>' Doctor='<%#EVal("Doctor") %>' InsuranceBroker='<%#EVal("InsuranceBroker") %>'
            TypeOfAgent='<%#EVal("TypeOfAgent") %>' />
    </ItemTemplate>
</asp:Repeater>
<div class="cb">
</div>
<div>
    <b><a href="" runat="server" id="aModerator">Contact Moderator (Solar System)</a></b><br />
    <b><a href="" runat="server" id="aUnionverse">UNIonVERSE</a></b>
</div>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<span>
    <small>*For other Individuals who have used your Religious Sales Agent's services, please
    visit each Sales Agent's Orb Connection Page.<br />
    **Sales Agents, to add, and receive credit for, an Individual as an Orn Connection
    click on the "Link me as an Orb" button on that Individual's profile page, and follow
    the navigation path provided.</small>
</span>
