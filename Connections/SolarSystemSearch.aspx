<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SolarSystemSearch.aspx.vb" Inherits="Connections_SolarSystemSearch" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/SolarSystemSearch.ascx" TagPrefix="uc1" TagName="SolarSystemSearch" %>


<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">Solar System Search
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:SolarSystemSearch runat="server" ID="SolarSystemSearch" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
