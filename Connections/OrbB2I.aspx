<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OrbB2I.aspx.vb" Inherits="Connections_OrbB2I" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/OrbitB2I.ascx" TagPrefix="uc1" TagName="OrbitB2I" %>


<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1>Orbit (B2I)</h1>
    <uc1:OrbitB2I runat="server" ID="OrbitB2I" />
</asp:Content>