<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GroupType1Connections.ascx.vb"
    Inherits="CMSWebParts_Membership_GroupType1Connections" %>
<%@ Register Src="UserType1Planets.ascx" TagName="UserType1Planets"
    TagPrefix="uc1" %>

<%@ Register src="GravitationalPlanetsII.ascx" tagname="GravitationalPlanetsII" tagprefix="uc2" %>
<asp:PlaceHolder runat="server" ID="phGRoupType" Visible="false">
<table cellpadding="4" cellspacing="4" width="100%">
    <tr>
        <td>
            <b>Planets I</b>
        </td>
        <td>
            <b>Planets II</b>
        </td>
        <td>
            <b>Gravitational II Planets</b>        
        </td>
    </tr>
    <tr>
        <td>
            <uc1:UserType1Planets ID="UserType1Planets1" runat="server" />
        </td>
        <td>
            <uc1:UserType1Planets ID="UserType1Planets2" runat="server" />
            
        </td>
        <td>
            <uc2:GravitationalPlanetsII ID="GravitationalPlanetsII1" runat="server" />
        </td>
    </tr>
</table>
</asp:PlaceHolder>
