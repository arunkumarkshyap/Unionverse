<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SolarSystemPlanets.aspx.vb" Inherits="Connections_SolarSystemPlanets" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/SolarSystemPlanets.ascx" TagPrefix="uc1" TagName="SolarSystemPlanets" %>


<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1>Solar System Planets</h1>
    <uc1:SolarSystemPlanets runat="server" ID="SolarSystemPlanets" />
</asp:Content>
