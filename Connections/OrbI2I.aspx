<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OrbI2I.aspx.vb" Inherits="Connections_OrbI2I" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/OrbitI2I.ascx" TagPrefix="uc1" TagName="OrbitI2I" %>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContents">
    <h1>Orb (I2I)</h1>
    <uc1:OrbitI2I runat="server" ID="OrbitI2I" />
</asp:Content>
