<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StarshipVoyager.aspx.vb" Inherits="Connections_StarshipVoyager" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/StarshipVoyager.ascx" TagPrefix="uc1" TagName="StarshipVoyager" %>


<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1>StarShip Voyager</h1>
    <uc1:StarshipVoyager runat="server" ID="StarshipVoyager" />
</asp:Content>
